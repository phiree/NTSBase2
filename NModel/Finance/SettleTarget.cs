using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    /// <summary>
    /// 结算对象 供应商/客户/职员等对象都属于此类. 
    /// </summary>
   public class SettleTarget
    {
       public virtual Guid Id { get; set; }

    }
}
