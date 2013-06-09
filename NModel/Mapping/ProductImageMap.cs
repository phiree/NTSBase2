using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NModel.Mapping
{
    public class ProductImageMap : ClassMap<ProductImage>
    {
        public ProductImageMap()
        {
            Id(x => x.Id);
            Map(x => x.HashCode);
            Map(x => x.ImageName);
            Map(x => x.Tag);
        }
    }
}
