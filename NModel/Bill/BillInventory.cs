using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    //盘点单
    public class BillInventory : BillBase
    {
        public BillInventory()
        {
            BillNo = "PD" + BillNo;
            InventoryList = new List<Inventory>();
            StockBillList = new List<BillBase>();
        }
        public virtual IList<Inventory> InventoryList { get; set; }
        //如果系统库存和实际盘点数量有出入,会自动创建出入库单据
        public virtual IList<BillBase> StockBillList { get; set; }

        public virtual EnumInventoryStatus Status { get; set; }


    }
    public enum EnumInventoryStatus
    {
        未开始,
        已开始,
        已结束
    }

}
