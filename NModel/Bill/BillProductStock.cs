using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    //进出库 单据
    public class BillStock : BillBase
    {
        //入库 还是出库
        public virtual StockActivityType StockType { get; set; }
        public virtual string Reason { get; set; }
        public virtual IList<ProductStock> Detail
        {
            get;
            set;
        }
    }
    public enum StockActivityType
    {
        Import,//入库
        Export//出库
    }
    //原因
    public enum StockActivityReason
    {
        Buy//购买入库 
        ,
        Return//归还入库,
        ,
        ReturnToSupplier//归还出库(还给供应商)
        ,
        Lost//丢失出库
        ,
        Damage//损毁出库
        , Borrow//外借出库
    }
}
