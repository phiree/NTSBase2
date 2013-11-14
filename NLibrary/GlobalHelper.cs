using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLibrary
{
   public class GlobalHelper
    {
       public static int GetRandomId(bool hasGivenGuid, Guid guid,int lenth)
       {
           int result=Math.Abs(guid.GetHashCode());
              
           return result;
       }
    }
}
