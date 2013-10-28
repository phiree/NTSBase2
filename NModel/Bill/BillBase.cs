using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    //单据基类
    public class BillBase
    {
        public virtual Guid Id { get; set; }
        public virtual string BillType { get; set; }
        public virtual string BillNo { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        //创建者
        public virtual NTSMember CreateMember { get; set; }
        public virtual string Memo { get; set; }
    }
    public enum BillType
    {
        Import,//入库单
        Export,//出库单
        Inventory //盘点单.
    }
}
