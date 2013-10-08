using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NModel.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.CategoryCode);
            Map(x => x.CreateTime);
            Map(x => x.LastUpdateTime);

            Map(x => x.ModelNumber).UniqueKey("UN_Product");
            Map(x => x.SupplierCode).UniqueKey("UN_Product");
            Map(x => x.NTSCode).Unique();

            Map(x => x.OrderAmountMin);

            Map(x => x.PriceOfFactory);

            HasMany(x => x.ProductImageList).Cascade.AllDeleteOrphan();
         
            Map(x => x.ProductionCycle);
            Map(x => x.State).CustomType<int>();

            Map(x => x.TaxRate);
            Map(x => x.PriceDate);
            Map(x => x.PriceValidPeriod);
            Map(x => x.MoneyType);
            Map(x => x.ImageState);
            Map(x => x.SyncState).CustomType<int>();
            Map(x => x.SyncTime).Nullable();
            References<ImportOperationLog>(x => x.ImportOperationLog);
            HasMany<ProductLanguage>(x => x.ProductMultiLangues).Cascade.AllDeleteOrphan();
        }
    }
}
