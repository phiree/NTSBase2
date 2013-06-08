using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using NBiz;
using NUnit.Framework;
using Rhino.Mocks;
using FizzWare.NBuilder;
namespace NTest.NBizTest
{
    [TestFixture]
    public class BizProductTest
    {
        BizProduct bizProduct = new BizProduct();
        /// <summary>
        /// 根据提供的供应商名称和型号,找出对应的产品
        /// </summary>
        [Test]
        public void GetListByProvidedModelNumberSupplierNameListTest()
        {

            var dalProduct = MockRepository.GenerateMock<NDAL.DALProduct>();
            dalProduct.Expect(x => x.GetOneByModelNumberAndSupplierName("BP-811","百好","brighthome"))
           .Return(Builder<Product>.CreateNew().Build());
            var dalSupplier = MockRepository.GenerateMock<NDAL.DALSupplier>();
            dalSupplier.Expect(x => x.GetOneByName("brighthome"))
           .Return(Builder<Supplier>.CreateNew().With(x=>x.Name="百好").With(x=>x.EnglishName="brighthome"). Build());



            bizProduct.DalProduct = dalProduct;
            bizProduct.DalSupplier = dalSupplier;
            string list= @"brighthome---BP-811
brighthome---BP-823
brighthome---BP-852
brighthome---BP-227
brighthome---BP-BC32
";
            string msg;
            IList<Product> products = bizProduct.GetListByProvidedModelNumberSupplierNameList(list, out msg);


            Assert.AreEqual(1, products.Count);
            
        }
    }
    
}
