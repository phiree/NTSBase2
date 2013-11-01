using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    //进出库 单据
    public class BillStock : BillBase
    {
        public BillStock()
        {
            Detail = new List<StockBillDetail>();
        }
        public BillStock(StockActivityType type):this()
        {
            switch (type)
            {
                case NModel.StockActivityType.Export:
                    BillNo = "CK" + BillNo;
                    break;
                case NModel.StockActivityType.Import:
                    BillNo = "RK" + BillNo;
                    break;
            }
            this.StockActivityType = type;
        }
        //入库 还是出库
        public virtual StockActivityType StockActivityType { get; set; }
        public virtual StockActivityReason Reason { get; set; }
        //结算对象.该单据的财务结算对象.应收/应付
        //public virtual SettleTarget SettleTarget { get; set; }
        public virtual IList<StockBillDetail> Detail
        {
            get;
            set;
        }
        public virtual decimal TotalAmount {
            get {
                return Detail.Sum(x => x.Price_Import);
            }
        }
        //public Dictionary<Guid, decimal> CalculateMoney()
        //{
        //    Dictionary<Guid, decimal> dicts = new Dictionary<Guid, decimal>();
        //    foreach (StockBillDetail detail in Detail)
        //    {
        //        string supplierCode=detail.Product.SupplierCode;
        //        if (dicts.ContainsKey(supplierCode))
        //        {

        //            dicts[supplierCode] += detail.TotalMoney;

        //        }
        //        else
        //        {
        //            dicts.Add(supplierCode, detail.TotalMoney);
        //        }
        //    }
        //    return dicts;
        //}
    }
    public enum StockActivityType
    {
        Import,//入库
        Export//出库
    }
    //原因
    public enum StockActivityReason
    {
       IN_购买入库 
        ,
       IN_Return归还入库
        ,
        IN_找回入库
        ,
        OUT_返还给供应商
        ,
        OUT_丢失出库
        ,
        OUT_损毁出库
        ,
        OUT_外借出库
        ,
        OUT_销售出库
    }
}
