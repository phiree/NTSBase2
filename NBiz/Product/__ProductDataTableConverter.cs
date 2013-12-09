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

    public class ProductDataTableConverter : IDataTableConverter<Product>
    {
        //如果出错,则抛出异常.
        public IList<Product> Convert(DataTable dt)
        {
             IRowPopulate irp = RowPopulateFactory.CreatePopulator(dt);
            foreach (DataColumn col in dt.Columns)
            {
                ColumnNameMatch(dt, col.ColumnName);
            }
            List<Product> productList = new List<Product>();
            string supplierName = string.Empty;
            StringBuilder sbError = new StringBuilder();
            bool isError = false;
            foreach (DataRow row in dt.Rows)
            {

                Product p = irp.PopulateFromRow(row);
                IList<Product> listp = productList.Where(x => x.SupplierCode == p.SupplierCode && x.ModelNumber == p.ModelNumber).ToArray();
                if (listp.Count > 0)
                {
                    
                    if (listp.Count == 1)
                    {
                        //如果已经存在该语言的信息,则是异常数据
                        Product existedP = listp[0];

                        foreach (ProductLanguage pl in p.ProductMultiLangues)
                        {
                            if (existedP.ProductMultiLangues.Where (x => x.Language == pl.Language).Count()>0)
                            {
                                isError = true;
                                sbError.AppendLine("该产品已经有这种语言的信息:型号_"+p.ModelNumber+",语言:"+pl.Language);
                            }
                        }

                        existedP.UpdateByNewVersion(p);
                    }
                    else
                    { 
                     isError = true;
                    //读取Excel时不允许重复
                     sbError.AppendLine("错误: 有" + listp.Count + "条 供应商 和 型号相同的数据" + p.SupplierCode + "," + p.ModelNumber);
                    }
                   
                   continue;
                }
                productList.Add(p);

            }
            if (isError)
            {
                throw new Exception(sbError.ToString());
            }

            return productList;
        }
        /// <summary>
        /// 列名容错
        /// </summary>
        private void ColumnNameMatch(DataTable dt, string columnName)
        {
            Dictionary<string, string> columnsEasyToSpellWrong = new Dictionary<string, string>();
            columnsEasyToSpellWrong.Add("生产周期", ".*生产周期.*");
            columnsEasyToSpellWrong.Add("最小起订量", ".*最小起订量.*|最小起定量");
            columnsEasyToSpellWrong.Add("规格参数", ".*规格.*参数.*");
            columnsEasyToSpellWrong.Add("产地", "产地|开票地");
         //   columnsEasyToSpellWrong.Add("产品名称", "名称|产品名称");
            //英文列名匹配
            //  columnsEasyToSpellWrong.Add("生产周期", ".*生产周期.*");
            // {"*生产周期*","*最小起定量*" };
            foreach (KeyValuePair<string, string> columnNamePatern in columnsEasyToSpellWrong)
            {
                if (Regex.IsMatch(columnName, columnNamePatern.Value))
                {
                    dt.Columns[columnName].ColumnName = columnNamePatern.Key;
                }
            }
        }

    }
}
