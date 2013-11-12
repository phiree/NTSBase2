using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using NLibrary;
namespace NBiz
{
    public class BizBill : BLLBase<NModel.BillBase>
    {
        NDAL.DALBillBase DalStockBill = new NDAL.DALBillBase();
        NDAL.DALProductStock DalProductStock = new NDAL.DALProductStock();
        NDAL.DALProduct DalProduct = new NDAL.DALProduct();
        public IList<BillBase> GetStockBill(StockActivityType type, int pageIndex, int pageSize, out int totalRecord)
        {
            return DalStockBill.GetStockBill(type, pageIndex, pageSize, out totalRecord);
        }
        //单据状态 控制
        public bool StockBillStateChange(BillStock bill, BillState targetState, out string errMsg, out QuantityChangeDirecrion changeDirection)
        {
            bool isValidOperation = false;
            changeDirection = QuantityChangeDirecrion.None;
            errMsg = "禁止的操作:" + bill.BillState + "-->" + targetState;
            switch (bill.BillState)
            {
                case BillState.已审核:
                    //已经审核的状态下,只能进行驳回操作
                    isValidOperation = targetState == BillState.草稿;

                    break;
                case BillState.草稿:
                    //草稿状态下,可以申请审核
                    isValidOperation = targetState == BillState.未审核;
                    break;
                //待审核状态下,可以驳回 也可以通过审核.
                case BillState.未审核:
                    isValidOperation = targetState == BillState.草稿 || targetState == BillState.已审核;
                    break;


            }
            if (bill.StockActivityType == StockActivityType.Export)
            {
                if (bill.BillState == BillState.已审核 && targetState == BillState.草稿)
                {
                    changeDirection = QuantityChangeDirecrion.Add;
                }
                else if (bill.BillState == BillState.未审核 && targetState == BillState.已审核)
                {
                    changeDirection = QuantityChangeDirecrion.Minus;
                }
            }
            else
            {
                if (bill.BillState == BillState.已审核 && targetState == BillState.草稿)
                {
                    changeDirection = QuantityChangeDirecrion.Minus;
                }
                else if (bill.BillState == BillState.未审核 && targetState == BillState.已审核)
                {
                    changeDirection = QuantityChangeDirecrion.Add;
                }
            }

            return isValidOperation;
        }
        public void ApplyStockChange(BillStock billStock, QuantityChangeDirecrion direction)
        {
            /*
             1 在 productstock 列表中查找 是否已经包含此商品 如果包含
             * 断言: 单据里的产品id是唯一的.
             */
            foreach (StockBillDetail detail in billStock.Detail)
            {
                ProductStock ps = DalProductStock.GetByProductId(detail.Product.Id);
                if (ps == null)
                {
                    ps = detail.InitProductStock();
                   
                }
                if (direction == QuantityChangeDirecrion.Minus)
                {
                    ps.Stock -= detail.Stock;
                }
                else if (direction == QuantityChangeDirecrion.Add)
                {
                    ps.Stock += detail.Stock;
                }
                ps.UpdateTime = DateTime.Now;
                ps.Location = detail.Location;
                ps.Price_Display = detail.Price_Display;
                ps.Price_Import = detail.Price_Import;
                DalProductStock.SaveOrUpdate(ps);

            }

            //todo 财务结算

        }

        //增加一个产品到入库/出库单.
        public bool AddStockDetail(BillStock billStock, string ntsCode, string position, decimal quantity, decimal priceDisplay, decimal priceImport, out string errMsg)
        {
            errMsg = string.Empty;
            //1 检查是否有该产品
            Product product = DalProduct.GetOneByNTSCode(ntsCode);
            if (product == null)
            {
                errMsg = "错误.没有对应的产品,请检查NTS编码:" + ntsCode;
                return false;
            }
            //是否需要检查 该单据里面的产品唯一性?
            StockBillDetail detail = new StockBillDetail();
            detail.Product = product;
            detail.Location = position;
            detail.Price_Display = priceDisplay;
            detail.Price_Import = priceImport;
            detail.Stock = quantity;
            detail.UpdateTime = DateTime.Now;
            detail.Bill = billStock;
            billStock.Detail.Add(detail);
            Save(billStock);
            return true;
        }


    }

    public enum QuantityChangeDirecrion
    {
        None//不需要修改数量
         ,
        Add//需要增加数量
            , Minus//需要减少数量
    }
}
