using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Globalization;
using System.Text.RegularExpressions;
using NLibrary;
using NPOI.SS.UserModel;
namespace NBiz
{
    /// <summary>
    /// ExportToXsl
    /// </summary>
    public class TransferInDatatable
    {
       DataSet ds = new DataSet();

       public HSSFWorkbook CreateXslWorkBookFromDataSet(DataSet ds)
       {
           HSSFWorkbook book = new HSSFWorkbook();
           foreach (DataTable dt in ds.Tables)
           {
               FillSheet(dt, 1,book); 
           }
           return book;
       }

       private void FillSheet(DataTable dt,int dataStartRowNumber, HSSFWorkbook book)
       {
           if (dataStartRowNumber < 0)
               throw new Exception("dataStartRowNumber必须大于等于0");
           if (string.IsNullOrEmpty(dt.TableName))
           {
               dt.TableName = "sheet1";
           }
           var sheet = book.CreateSheet(dt.TableName);
       
       
           DataColumnCollection cols = dt.Columns;
           //创建表头
           for (int h = 0; h <= dataStartRowNumber; h++)
           {
               IRow headrow = sheet.CreateRow(h);
               if (h == dataStartRowNumber)
               {
                   CreateCellForRow(headrow, cols, null, true);
               }
               else
               {
                   CreateCellForRow(headrow, cols, null, false);
               }
          
             }
           //填充内容
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               var dataRow = dt.Rows[i];
               var excelRow = sheet.CreateRow(dataStartRowNumber + 1 + i);
               CreateCellForRow(excelRow, cols, dataRow, false);
           }
       }
       public HSSFWorkbook CreateXslWorkBookFromDataTable(DataTable dt,int dataStartRowNumber)
       {
           HSSFWorkbook book = new HSSFWorkbook();
           FillSheet(dt, dataStartRowNumber, book);
           return book;
       }

        public HSSFWorkbook CreateXslWorkBookFromDataTable(DataTable dt)
        {
            return CreateXslWorkBookFromDataTable(dt, 1);
        }
        /// <summary>
        /// 根据datatable
        /// </summary>
        /// <param name="dataStartRowNumber">Excel文件顶部可能需要写入其他数据</param>
        /// <param name="dt"></param>
        /// <param name="xslTemplate"></param>
        /// <param name="saveNtsNumber"></param>
        /// <param name="savePath">保存位置</param>
        public void CreateXslFromDataTable(DataTable dt,int dataStartRowNumber,string savePath)
        {
           
            HSSFWorkbook book = CreateXslWorkBookFromDataTable(dt, dataStartRowNumber);
            IOHelper.EnsureFile(savePath);
            FileStream fsOut=new FileStream(savePath,FileMode.Create);
            book.Write(fsOut);
            fsOut.Close();
            
        }

        /// <summary>
        /// 根据datarow 创建 cells. 
        /// </summary>
        /// <param name="excelRow"></param>
        /// <param name="columns"></param>
        /// <param name="row">如果为null 则该行所有cell的值为空</param>
        /// <param name="isHead">如果是true 则创建表头.</param>
        private void CreateCellForRow(IRow excelRow, DataColumnCollection columns, DataRow row,bool isHead)
        {
            for (int i=0;i<columns.Count;i++)
            {
                var cell = excelRow.CreateCell(i);
                if (isHead)
                {
                    cell.SetCellValue(columns[i].ColumnName);
                }
                else
                {
                    string cellValue = string.Empty;
                    if (row != null) { cellValue = row[i].ToString(); }
                    cell.SetCellValue(cellValue);
                }
            }
        }
    }
}
