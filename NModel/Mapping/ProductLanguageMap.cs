using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NModel.Mapping
{
    /// <summary>
    /// 产品多语言
    /// </summary>
    public class ProductLanguageMap : ClassMap<ProductLanguage>
    {
        public ProductLanguageMap()
        {
            Id(x => x.Id);
            References<Product>(x => x.Product).UniqueKey("UQ_PL");
            Map(x => x.Memo);
            Map(x => x.Name);
            Map(x => x.PlaceOfDelivery);
            Map(x => x.PlaceOfOrigin);
            Map(x => x.ProductDescription);
            Map(x => x.ProductParameters);
            Map(x => x.Unit);
            Map(x => x.Language).UniqueKey("UQ_PL");
        }
    }
}
