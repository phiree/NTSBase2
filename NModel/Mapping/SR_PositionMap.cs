using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NModel;
namespace NModel.Mapping
{
    public  class SR_PositionMap: ClassMap<SR_Position>
    {
        public SR_PositionMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.PositionCode);
            HasMany<SR_Position>(x => x.ChildrenPosition);
            References<SR_Position>(x => x.ParentPosition);
          
        }
    }
}
