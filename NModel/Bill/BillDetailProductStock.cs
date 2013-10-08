using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    //保存单据里的产品详情
    public class BillDetailStock
    {
        public virtual Guid ProductId { get; set; }

        public virtual string NTSCode { get; set; }

        public virtual string SupplierCode { get; set; }
        public virtual string ImageState { get; set; }
        public virtual string PriceDate { get; set; }
        public virtual string PriceValidPeriod { get; set; }
        public virtual string ModelNumber { get; set; }

        public virtual string CategoryCode { get; set; }

        public virtual string PriceOfFactory { get; set; }
        public virtual string MoneyType { get; set; }
        public virtual decimal TaxRate { get; set; }
        public virtual decimal OrderAmountMin { get; set; }
        public virtual decimal ProductionCycle { get; set; }

        //库位号
        public virtual string Location { get; set; }
        //库存
        public virtual decimal Stock { get; set; }
        //单位
        public virtual string StockUnit { get; set; }
        //该库存状态的更新时间
        public virtual DateTime UpdateTime { get; set; }
        //此操作对应的单据

        public void CloneFromProduct(Product p)
        {

            this.ProductId = p.Id;
            if (p.CategoryCode != this.CategoryCode)
            {
                this.CategoryCode = p.CategoryCode;
                this.NTSCode = null;
            }
            if (p.SupplierCode != this.SupplierCode)
            {
                this.SupplierCode = p.SupplierCode;
                this.NTSCode = null;
            }
            this.ImageState = p.ImageState;
            this.PriceDate = p.PriceDate;
            this.PriceOfFactory = p.PriceOfFactory;
            this.PriceValidPeriod = p.PriceValidPeriod;
            this.ProductionCycle = p.ProductionCycle;
            this.TaxRate = p.TaxRate;

        }

    }
}
