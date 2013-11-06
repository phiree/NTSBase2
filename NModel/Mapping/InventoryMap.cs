using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NModel.Mapping
{
    public class InventoryMap : ClassMap<Inventory>
    {
        public InventoryMap()
        {
            Id(x => x.Id);
            References<Product>(x => x.Product);
            
            
            Map(x => x.StockQuantity);
            Map(x => x.CheckQuantity);
         

        }
    }
}
