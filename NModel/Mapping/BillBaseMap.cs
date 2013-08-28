using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NModel.Mapping
{
    public class BillBaseMap : ClassMap<BillBase>
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
}
