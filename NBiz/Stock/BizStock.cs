using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
namespace NBiz
{
    public class BizStock:BLLBase<ProductStock>
    {
        public IList<ProductStock> ImportProductFromExcel(System.IO.Stream stream, out string errMsg)
        {
            IDataTableConverter<ProductStock> productReader = new ProductStockDataTableConverter();
            ImportToDatabaseFromExcel<ProductStock> importor = new ImportToDatabaseFromExcel<ProductStock>(productReader, this);
            return importor.ImportXslData(stream, out  errMsg);
        }
    }
}
