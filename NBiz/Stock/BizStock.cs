using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
namespace NBiz
{
    public class BizStock:BLLBase<ProductStock>
    {
        BizProduct bizProduct = new BizProduct();
        public IList<ProductStock> ImportProductFromExcel(System.IO.Stream stream, out string errMsg)
        {
            IDataTableConverter<ProductStock> productReader = new ProductStockDataTableConverter();
            ImportToDatabaseFromExcel<ProductStock> importor = new ImportToDatabaseFromExcel<ProductStock>(productReader, this);
            return importor.ImportXslData(stream, out  errMsg);
        }
        public override IList<ProductStock> SaveList(IList<ProductStock> list, out string errMsg)
        {
            errMsg = string.Empty;
            IList<Product> products = list.Select(x => x.Product).ToList();


            IList<Product> savedProducts = bizProduct.SaveList(products, out errMsg);

            foreach (ProductStock ps in list)
            {
                Product p = savedProducts.SingleOrDefault(x => x.SupplierCode == ps.Product.SupplierCode && x.ModelNumber == ps.Product.ModelNumber);
                ps.Product = p;
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       


             base.SaveList(list);
             return list;
        }
    }
}
