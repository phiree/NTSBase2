﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;

namespace NTest.NBizTest.InvoicingTDD
{
    /// <summary>
    /// 初始数据的导入
    /// </summary>
   public class InitImportTest
    {
       //库存初始化
       public void ImportFromExel()
       {
           string excelPath = string.Empty;
          // IList<ProductStock> stockList;
           StockManager stockmgr = new StockManager();
           IList<ProductStock> initStock= ExcelReader(excelPath);


       }
    }
}
