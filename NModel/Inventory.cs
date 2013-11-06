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
    /// 盘点详情
    /// </summary>
    public class Inventory
    {
        public Inventory()
        {
            CheckQuantity = 0;
        }
        public virtual Guid Id { get; set; }
        //产品
        public virtual Product Product { get; set; }
        //数据冗余
        public virtual decimal StockQuantity { get; set; }
        //库位号
        public virtual decimal CheckQuantity { get; set; }
             

    }
}
