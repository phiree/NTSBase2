using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NModel;
namespace NModel.Mapping
{
    public  class BillBaseMap: ClassMap<BillBase>
    {
        public BillBaseMap()
        {
            Id(x => x.Id);
            Map(x => x.BillNo);
            Map(x => x.BillType);
            Map(x => x.CreatedDate);
            Map(x => x.CreateMemberName);
          
        }
    }
    public class BillProductStockMap : SubclassMap<BillProductStock>
    {
        public BillProductStockMap()
        {
            HasMany(x => x.Detail);
        }
    }
    public class BillProductMap : SubclassMap<BillProduct>
    {
        public BillProductMap()
        {
            HasMany(x => x.Detail);
        }
    }
}
