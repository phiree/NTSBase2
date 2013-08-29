using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using System.Data;
using NLibrary;
using System.Text.RegularExpressions;
namespace NBiz
{
    /// <summary>
    /// 用excel的每一行数据 构建一个product Stock.对象
    /// </summary>

    public class StockRowPopulate
    {
        public ProductStock Populate(System.Data.DataRow row)
        {
            IRowPopulate populate = new RowPolulateBaojiandan();
            ProductStock stock = new ProductStock();
            Product p = populate.PopulateFromRow(row);
            stock.Product = p;
            //if (row["BillNo"] != null)
            //{
            //    string billNo = row["BillNo"].ToString();
            //    stock.BillRelative = new BizBill().GetOne(billNo);
            //}
            stock.Location = row["库位号"].ToString();
            stock.StockUnit = row["库存单位"].ToString();
            stock.Stock = decimal.Parse(row["库存数"].ToString());
            stock.UpdateTime = DateTime.Now;
            return stock;
        }

    }




}
