using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLibrary;
namespace NBiz
{
    //业务帮助类,简单通用方法的集合
   public class BizHelper
    {
       public static string GetFirstCateCode(string cateCode)
       {
           if (string.IsNullOrEmpty(cateCode))
           {
               throw new Exception("传入代码有误");
           }
           string[] catecodeArray = cateCode.Split('.');
           string firstCate = catecodeArray[0];
           firstCate = StringHelper.FullFillWidth(firstCate, "00", 2, true);
           return firstCate;
       }
    }
}
