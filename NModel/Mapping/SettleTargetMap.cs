using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NModel.Mapping
{
    public class SettleTargetMap : ClassMap<SettleTarget>
    {
        public SettleTargetMap()
        {

            Id(x => x.Id);

        }
    }
}
