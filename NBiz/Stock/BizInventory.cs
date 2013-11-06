using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using NDAL;
namespace NBiz
{
    /// <summary>
    /// 库存数量管理(暂时不考虑财务问题)
    /// </summary>
    public class BizBillInventory : BLLBase<BillInventory>
    {
        DALProduct dalProduct = new DALProduct();
        DALProductStock dalProductStock = new DALProductStock();
        public void AddInventoryFromNtsCodeList(BillInventory bill, string[] ntsCodeList)
        {
        
            IList<ProductStock> ps = dalProductStock.GetListByNtsCodeList(ntsCodeList);
            foreach (ProductStock stock in ps)
            {
                IEnumerable<Inventory> existedProduct=bill.InventoryList.Where(x => x.Product.Id == stock.Product.Id);
                if (existedProduct.Count() == 0)
                {
                    Inventory item = new Inventory();
                    item.StockQuantity = stock.Stock;
                    item.Product = stock.Product;
                    bill.InventoryList.Add(item);
                }
            }
            

        }
    }
}
