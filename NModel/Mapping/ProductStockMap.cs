using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NModel.Mapping
{
    public class ProductStockMap : ClassMap<ProductStock>
    {
        public ProductStockMap()
        {
            Id(x => x.Id);
         
            Map(x => x.Location);
            References<Product>(x => x.Product).Unique();
            Map(x => x.Stock);
            Map(x => x.StockUnit);
            Map(x => x.UpdateTime);

        }
    }
}
