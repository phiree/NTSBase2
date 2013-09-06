﻿using System;
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
            References<BillBase>(x => x.BillRelative).Cascade.None();
            Map(x => x.Location);
            References<Product>(x => x.Product).Cascade.None();
            Map(x => x.Stock);
            Map(x => x.StockUnit);
            Map(x => x.UpdateTime);

        }
    }
}