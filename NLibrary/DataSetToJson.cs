using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace NLibrary
{
   public  class DataSetToJson
    {
       public static string ConvertDataSetToJson(DataSet ds)
       {
           string result = string.Empty;
           result = JosnHelper.GetJson<DataSet>(ds);
           return result;
       }

    }
}
