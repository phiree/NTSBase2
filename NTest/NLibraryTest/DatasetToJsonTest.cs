using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data;
using NLibrary;
namespace NTest.NLibraryTest
{
    public class DatasetToJsonTest
    {
        /// <summary>
        /// 传入参数:dataset
        /// 返回值: dataset的json格式字符串,包含信息:表名,列名,行值
        /// </summary>
        public void ConvertDatasetToJsonString()
        {
            string expected = "[{dt1:[{col11:valueofcol11}],dt2:[{col21:valueofcol21}]}]";
            DataSet ds = BuildTestDataset();
            string actual = new NLibrary.JosnHelper().Serialize(ds);
           // string actual = BuildTestDataset().Tables.
            Console.Write(actual);
            Assert.AreEqual(expected, actual);

        }
        private DataSet BuildTestDataset()
        {
            DataTable dt1 = new DataTable("dt1");
           // DataColumn col11 = new DataColumn("col11");
            dt1.Columns.Add(new DataColumn("表格1列名1"));
            dt1.Rows.Add("表格1列1行1的值");

            DataTable dt2 = new DataTable("dt2");
            // DataColumn col11 = new DataColumn("col11");
            dt2.Columns.Add(new DataColumn("表格2列名1"));
            dt2.Columns.Add(new DataColumn("表格2列名2"));
            dt2.Rows.Add("表格2列名1行1的值", "表格2列名2行1的值");
            dt2.Rows.Add("表格2列名1行2的值", "表格2列名2行2的值");

            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            return ds;
        }
    }
}
