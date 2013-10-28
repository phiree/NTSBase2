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
            References<NTSMember>(x => x.CreateMember);
          
        }
    }
    public class BillStockMap : SubclassMap<BillStock>
    {
        public BillStockMap()
        {
            HasMany(x => x.Detail).Cascade.All();
        }
    }
}
