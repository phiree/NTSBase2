using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NUnit.Framework;
namespace NTest.CodeSnippets
{
  public class DataTableTest
    {
      public void SelectTest()
      {
          DataTable dt = new DataTable();
          dt.Columns.Add(new DataColumn("name"));
          DataRow row = dt.NewRow();
          row["name"] = "水";
          dt.Rows.Add(row);

          Assert.AreEqual(1, dt.Rows.Count);

          DataSet ds = new DataSet();
          ds.Tables.Add(dt);

          DataView dv = new DataView(dt);
          //dv.
          //DataRowCollection rows = dt.

      }
    }
}
