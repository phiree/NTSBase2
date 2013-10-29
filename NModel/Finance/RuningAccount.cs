using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    /// <summary>
    ///  财务流水明细
    /// </summary>
    public class RuningAccount
    {
        public virtual Guid Id { get; set; }
        //结算对象
        public virtual SettleTarget SettleTarget { get; set; }
        //关联单据
        public virtual BillBase Bill { get; set; }
        //总金额
        public virtual decimal Amount { get; set; }
        //是->收入,否->支出.
        public virtual bool IsIncome { get; set; }
       
    }
}
