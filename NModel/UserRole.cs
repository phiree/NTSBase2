﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
   public class UserRole
    {
     public virtual  Guid Id { get; set; }
     public virtual string MemberName { get; set; }
     public virtual string RoleName { get; set; }
    }
}