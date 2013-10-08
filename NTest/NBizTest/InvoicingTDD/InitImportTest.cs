using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using NBiz;
using System.IO;
using NUnit.Framework;
namespace NTest.NBizTest.InvoicingTDD
{
    
    /// <summary>
    /// 初始数据的导入
    /// </summary>
   [TestFixture]
   public class InitImportTest
    {

       BizStock bizStock = new BizStock();
       //库存初始化
       [Test]
       public void ImportFromExel()
       {
           string excelPath = Environment.CurrentDirectory + @"\TestFiles\NBizTest\InvoicingTDD\库存清单模板.xls"; 
          // IList<ProductStock> stockList;
          // StockManager stockmgr = new StockManager();
          // IList<ProductStock> initStock= ExcelReader(excelPath);
           FileStream fs=new FileStream(excelPath, FileMode.Open);
           string msg;
           
          IList<ProductStock> stocks= bizStock.ImportProductFromExcel(fs, out msg);
          Assert.AreEqual(19, stocks.Count);
       }
    }
}
