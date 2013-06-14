﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NLibrary;
using NUnit.Mocks;
using Rhino.Mocks;
namespace NTest.NLibraryTest
{
    [TestFixture]
    public class StringHelperTest
    {
        [Test]
        public void BuidCountQueryCount()
        {
            string query = 
                "select p from Product p where p.SupplierCode in (select s.Code from Supplier s where s.Name like '%深圳%')";

            Assert.AreEqual(
                "select count(*) from Product p where p.SupplierCode in (select s.Code from Supplier s where s.Name like '%深圳%')",
                StringHelper.BuildCountQuery(query));
        }
    }
}
