using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    /// <summary>
    /// 总帐
    /// </summary>
    public class GeneralAccount
    {
        public virtual Guid Id { get; set; }
        //表内唯一
        public virtual SettleTarget SettleTarget { get; set; }
        //余额
        public virtual decimal Balance { get; set; }
        public virtual DateTime LastUpdateTime { get; set; }
        //该总帐下面的流水帐
        public virtual IList<RuningAccount> RuningList { get; set; }
    }
}
