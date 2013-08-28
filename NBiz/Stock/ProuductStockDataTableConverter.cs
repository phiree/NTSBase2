using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using System.Data;
using System.Text.RegularExpressions;
using NLibrary;

namespace NBiz
{
    /// <summary>
    /// DataTable转换成IList<T>
    /// </summary>

    public class ProductStockDataTableConverter : IDataTableConverter<ProductStock>
    {
        //如果出错,则抛出异常.
        public IList<ProductStock> Convert(DataTable dt)
        {
            List<ProductStock> StockList = new List<ProductStock>();
            StockRowPopulate per = new StockRowPopulate();

            foreach (DataRow row in dt.Rows)
            {
                ProductStock ps = per.Populate(row);
                StockList.Add(ps);
            }
            return StockList;
        }

    }
}
