using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    /// <summary>
    /// 购物车类.
    /// </summary>
    public class ProductCartItem
    {
        public virtual Guid Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Qty { get; set; }


    }
}
