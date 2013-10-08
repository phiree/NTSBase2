using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace NModel
{
    //单据抽象基类
    public class BillProductStock : BillBase
    {

        public virtual IList<ProductStock> Detail
        {
            get;
            set;
        }
    }
}
