using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    //单据基类
    public class BillBase
    {
        public BillBase()
        {
            CreatedDate = DateTime.Now;
            BillNo = CreatedDate.ToString("yyyyMMddhhmmss");

        }
        public virtual Guid Id { get; set; }
       
        public virtual string BillNo { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        //创建者
        public virtual NTSMember CreateMember { get; set; }
        public virtual string Memo { get; set; }
        public virtual BillState BillState { get; set; }
        //单据类型
        public virtual BillType BillType { get; set; }
    }
    public enum BillType
    {
        Stock,//出入库单据
        Inventory //盘点单.
    }
    public enum BillState
    {
        草稿,//草稿
        未审核,//未审核
        已审核,//已审核
        已撤销
    }
    
}
