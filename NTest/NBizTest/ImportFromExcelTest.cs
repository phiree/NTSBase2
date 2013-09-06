using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NModel;
using NBiz;
namespace NTest.NBizTest
{
    [TestFixture]
    public class ImportFromExcelTest
    {
        BizProduct bizProduct = new BizProduct();
        BizSupplier bizSupplier = new BizSupplier();
        BizCategory bizCategory = new BizCategory();
        string errMsg;
        [Test]
        public void ReadProductFromExcelTest()
        {
            /*
             文件末尾有空白行
             */
            string filePath = Environment.CurrentDirectory + @"\TestFiles\NTS 产品报价单   哈慈 20130306.xls";
                                
            IList<Product> products = bizProduct.ReadListFromExcel(new System.IO.FileStream(filePath, System.IO.FileMode.Open)
                ,out errMsg);

            Assert.AreEqual(19,products.Count);
            Assert.AreEqual("zh", products[0].ProductMultiLangues[0].Language);
            Assert.AreEqual("en", products[0].ProductMultiLangues[1].Language);
            Assert.AreEqual("zh", products[1].ProductMultiLangues[0].Language);

        }
        [Test]
        public void ReadProductFromExcel_供应商名称异常Test()
        {
            /*
             文件末尾有空白行
             */
            string filePath = Environment.CurrentDirectory + @"\TestFiles\FormatCheck\俊能\NTS产品报价单俊能08-30.xls";

            IList<Product> products = bizProduct.ReadListFromExcel(new System.IO.FileStream(filePath, System.IO.FileMode.Open)
                , out errMsg);

            Assert.AreEqual(19, products.Count);
            Assert.AreEqual("zh", products[0].ProductMultiLangues[0].Language);
            Assert.AreEqual("en", products[0].ProductMultiLangues[1].Language);
            Assert.AreEqual("zh", products[1].ProductMultiLangues[0].Language);

        }
        [Test]
        public void ReadProductFromExcelTest2()
        {
            /*
             文件末尾有空白行
             */
            string filePath = Environment.CurrentDirectory + @"\TestFiles\英文版——NTS产品报价单 佛山富丰西厨具制造厂.xls";

            IList<Product> products = bizProduct.ReadListFromExcel(new System.IO.FileStream(filePath, System.IO.FileMode.Open)
                , out errMsg);

            Assert.AreEqual(127, products.Count);
            Assert.AreEqual("en", products[0].ProductMultiLangues[0].Language);
            Assert.AreEqual("en", products[0].ProductMultiLangues[0].Language);
            Assert.AreEqual("en", products[1].ProductMultiLangues[0].Language);

        }
        [Test]
        public void ReadSupplierFromExcelTest()
        {

            string filePathSupplier = Environment.CurrentDirectory + @"\TestFiles\供应商193.xls";
       
            IList<Supplier> Supplier = bizSupplier.ReadSupplierListFromExcel(new System.IO.FileStream(filePathSupplier, System.IO.FileMode.Open)
                ,out errMsg
                );

            Assert.AreEqual(193, Supplier.Count);
        }

       
        //导入Erp格式
        [Test]
        public void ReadProductFromErpExcelTest()
        {
            string filePath = Environment.CurrentDirectory + @" \TestFiles\吧台设备及用具.XLS";

            IList<Product> products = bizProduct.ReadListFromExcel(new System.IO.FileStream(filePath, System.IO.FileMode.Open)
                   , out errMsg);

            Assert.AreEqual(40, products.Count);
            Assert.AreEqual("01.001", products[0].CategoryCode);

        }
        //导入分类列表
        [Test]
        public void ReadCategoryFromExcel()
        {
            string filePath = Environment.CurrentDirectory + @"\TestFiles\分类表.xls";
           
            IList<Category> products = bizCategory.ReadListFromExcel(new System.IO.FileStream(filePath, System.IO.FileMode.Open),out errMsg);

            Assert.AreEqual(465, products.Count);
           
        }
        //英文ERP格式问题
        [Test]
        public void ReadProductErpEnglishFromExcel()
        {
            string filePath = Environment.CurrentDirectory + @"\TestFiles\英文——2013-3-26家具（brighthome）数据表.XLS";
            try
            {
                IList<Product> products = bizProduct.ReadListFromExcel(new System.IO.FileStream(filePath, System.IO.FileMode.Open)
                    , out errMsg);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("", ex.Message);
                
            }
            //Assert.AreEqual("01.001", products[0].CategoryCode);

        }
        //包含英文名的供應商列表
        [Test]
        public void ReadSupplierWithSupplierFromExcelTest()
        {

            string filePathSupplier = Environment.CurrentDirectory + @"\TestFiles\供应商196.xls";
            IList<Supplier> Supplier = bizSupplier.ReadSupplierListFromExcel(new System.IO.FileStream(filePathSupplier, System.IO.FileMode.Open)
               , out errMsg
               );

            Assert.AreEqual(196, Supplier.Count);
            Assert.AreEqual("美和", Supplier[0].NickName);
        }
    }
}
