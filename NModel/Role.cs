using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
   public class Role
    {
       public virtual Guid Id { get; set; }
       public virtual string Name { get; set; }
       public virtual string Description { get; set; }
    }
}
