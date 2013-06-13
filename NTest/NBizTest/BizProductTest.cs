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
            dalProduct.Expect(x => x.GetOneByModelNumberAndSupplierCode("BP-811", "008"))
           .Return(Builder<Product>.CreateNew().Build());
            var dalSupplier = MockRepository.GenerateMock<NDAL.DALSupplier>();
            dalSupplier.Expect(x => x.GetOneByCode("008"))
           .Return(Builder<Supplier>.CreateNew().With(x=>x.Name="百好").With(x=>x.EnglishName="brighthome"). Build());



            bizProduct.DalProduct = dalProduct;
            bizProduct.DalSupplier = dalSupplier;
            string list= @"008---BP-811
008---BP-823
008---BP-852
008---BP-227
008---BP-BC32
";
            string msg;
            IList<Product> products = bizProduct.GetListByProvidedModelNumberSupplierNameList(list, out msg);


            Assert.AreEqual(1, products.Count);
            
        }
    }
    
}
