using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    /// <summary>
    /// 库存轨迹, 此类对象都是计算得出 不需要map
    /// </summary>
   public class StockTrace
    {
       public Product Product { get; set; }
       public decimal QuantityChange { get; set; }
       public DateTime ChangeTime { get; set; }
       public BillBase Bill { get; set; }
    }
}
