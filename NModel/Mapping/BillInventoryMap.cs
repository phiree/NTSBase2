using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NModel.Mapping
{
    public class BillInventoryMap : SubclassMap<BillInventory>
    {
        public BillInventoryMap()
        {
            HasMany<Inventory>(x => x.InventoryList).Cascade.All();
         

        }
    }
}
