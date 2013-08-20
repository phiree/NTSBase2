using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace NModel
{
    //单据抽象基类
    public abstract class BillBase
    {
        public Guid Id { get; set; }
        public string BillNo { get; set; }
        public string CreatedDate { get; set; }
        //创建者
        public string CreateMemberName { get; set; }
        
        
    }
}
