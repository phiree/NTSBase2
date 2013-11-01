using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{

    //出入库 产品列表中的条目.
    public class StockBillDetail
    {
        public virtual Guid Id { get; set; }
        //产品
        public virtual Product Product { get; set; }
        //数据冗余
        public virtual string ProductName { get; set; }
        //库位号
        public virtual string Location { get; set; }
        //库存
        public virtual decimal Stock { get; set; }
        //单位
        public virtual string StockUnit { get; set; }
        //入库价格
        public virtual decimal Price_Import { get; set; }
        //展示价
        public virtual decimal Price_Display { get; set; }
        //该库存状态的更新时间
        public virtual DateTime UpdateTime { get; set; }
        //此操作对应的单据

        public virtual BillBase Bill { get; set; }
        //该单据的总价格 默认等于 数量*单价.
        public virtual decimal TotalMoney { get; set; }
        //产品初始化入库:如果此细节中的产品还没有入库.
        public virtual ProductStock InitProductStock()
        {
            ProductStock newStock = new ProductStock();
            newStock.UpdateTime = this.UpdateTime;
            newStock.StockUnit = this.StockUnit;
            newStock.Stock = 0;
            newStock.ProductName = this.ProductName;
            newStock.Product = this.Product;
            newStock.Price_Import = this.Price_Import;
            newStock.Price_Display = this.Price_Display;
            newStock.Location = this.Location;
            return newStock;
            
        }
    }
}
