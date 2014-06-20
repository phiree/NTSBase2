using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDAL;
using NUnit.Framework;
namespace NTest.NDALTest
{
    [TestFixture]
   public class ProductDALTest
    {
        [Test]
       public void QueryWithPhoto()
       {
           DalBase<NModel.Product> dalProduct = new DalBase<NModel.Product>();
           string query = "select p from Product p where p.ProductImageUrls.size>0";
           var pl= dalProduct.GetList(query);
           Console.WriteLine(pl.Count);

           
       }
         [Test]
       public void QueryOrderList()
       {
           DalBase<NModel.Product> dalProduct = new DalBase<NModel.Product>();
           string query = @"select p from Product p where p.NTSCode in('02.001.0007700492',
'02.001.0007700439',
'02.001.0007700929',
'02.001.0007700684',
'02.001.0007700685',
'02.001.0007700688',
'02.001.0007700689',
'02.001.0007701004',
'02.001.0007700888',
'02.001.0007700890',
'02.001.0007701005',
'02.001.0007700951',
'02.001.0007701008',
'02.001.0007701040',
'02.001.0007701014',
'02.001.0007700993',
'02.001.0007700940',
'02.001.0007701026',
'02.001.0007700097',
'02.001.0007701029',
'02.001.0007701030',
'02.001.0007701031',
'02.001.0007700083',
'02.001.0007701035',
'02.001.0007700930',
'02.001.0007701037')
                            order by field(NTSCode,'02.001.0007700492',
'02.001.0007700439',
'02.001.0007700929',
'02.001.0007700684',
'02.001.0007700685',
'02.001.0007700688',
'02.001.0007700689',
'02.001.0007701004',
'02.001.0007700888',
'02.001.0007700890',
'02.001.0007701005',
'02.001.0007700951',
'02.001.0007701008',
'02.001.0007701040',
'02.001.0007701014',
'02.001.0007700993',
'02.001.0007700940',
'02.001.0007701026',
'02.001.0007700097',
'02.001.0007701029',
'02.001.0007701030',
'02.001.0007701031',
'02.001.0007700083',
'02.001.0007701035',
'02.001.0007700930',
'02.001.0007701037')
";
           var pl = dalProduct.GetList(query);
           Assert.AreEqual(pl[0].NTSCode, "02.001.0007700492");
           Assert.AreEqual(pl[24].NTSCode, "02.001.0007700930");

              Assert.AreEqual(pl[10].NTSCode, "02.001.0007701005");

                        Assert.AreEqual(pl[4].NTSCode,"02.001.0007700685");


           Console.WriteLine(pl.Count);

       }
    }
}
