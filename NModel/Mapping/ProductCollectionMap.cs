using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NModel.Mapping
{
    public class ProductCollectionMap : ClassMap<ProductCollection>
    {
        public ProductCollectionMap()
        {
            Id(x => x.Id);
            Map(x => x.CollectionName);
            Map(x => x.CreateTime);
            Map(x => x.IsDefault);
            Map(x => x.LastUpdateTime);
            Map(x => x.UserId);
            HasManyToMany<Product>(x => x.Products)

                .Table("Product_Collection")
                
                ;

        }
    }
   
}
