using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel.Enums;
using System.IO;
using System.ComponentModel;
using NLibrary;
namespace NModel
{
    /// <summary>
    /// 库存快照.
    /// </summary>
    public class ProductStock
    {
        public ProductStock()
        { }
        public virtual Guid Id { get; set; }
        //产品
        public virtual Product Product { get; set; }
        //库位号
        public virtual string Location { get; set; }
        //库存
        public virtual decimal Stock { get; set; }
        //单位
        public virtual string StockUnit { get; set; }
        //该库存状态的更新时间
        public virtual DateTime UpdateTime { get; set; }
        //此操作对应的单据

        public virtual BillBase Bill { get; set; }

    }
}
