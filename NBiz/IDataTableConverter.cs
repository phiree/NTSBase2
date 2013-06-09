using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NModel;
namespace NBiz
{

    public class ExcelReader_Product:IExcelReader<NModel.Product>
    {

        public IList<NModel.Product> Read(Stream stream, IDataTableConverter<NModel.Product> convertor, out string readResult)
        {
            throw new NotImplementedException();
        }
    }

    public interface IExcelReader<T>
    {
        IList<T> Read(Stream stream,IDataTableConverter<T> convertor, out string readResult);
    }
    public interface IDataTableConverter<T> {
        IList<T> Convert(System.Data.DataTable table);
    }
}
