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
    /// 数据导成excel文件
    /// </summary>
    public class DataExport
    {
        /// <summary>
        /// 顶部留空的行数
        /// </summary>
        public int HeaderRows { get; set; }
        /// <summary>
        /// 目标Excel文件
        /// </summary>
        public string XSLFilePath { private get; set; }
        /// <summary>
        /// 需要導出的數據
        /// </summary>
        public DataTable DataToExport { get; set; }

        //excel内存对象
        public HSSFWorkbook Book { get; set; }
        public DataExport()
        {
            HeaderRows = 1;
        }
        public DataExport(DataTable datatable)
            : this(datatable, 1)
        {
        }
        public DataExport(DataTable datatable, int headerRows)
        {
            if (headerRows < 0)
                throw new Exception("dataStartRowNumber必须大于等于0");
            HeaderRows = headerRows;
            DataToExport = datatable;
        }
        public void CreateWorkBook()
        {
            FillSheet(0);
        }
        private void FillSheet(int tableIndex)
        {

            if (string.IsNullOrEmpty(XSLFilePath))
            {
                Book = new HSSFWorkbook();
            }
            else
            {
                Book = new HSSFWorkbook(new FileStream(XSLFilePath, FileMode.OpenOrCreate));
            }
            if (string.IsNullOrEmpty(DataToExport.TableName))
            {
                DataToExport.TableName = "table" + tableIndex;
            }
            ISheet sheet;
            if (tableIndex < Book.NumberOfSheets)
            {
                sheet = Book.GetSheetAt(tableIndex);
            }
            else
            {
                sheet = Book.CreateSheet(DataToExport.TableName);
            }

            DataColumnCollection cols = DataToExport.Columns;
            //创建表头
            for (int h = 0; h <= HeaderRows; h++)
            {
                IRow headrow = sheet.CreateRow(h);
                if (h == HeaderRows)
                {
                    CreateCellForRow(headrow, cols, null, true);
                }
                else
                {
                    CreateCellForRow(headrow, cols, null, false);
                }
            }
            //填充内容
            for (int i = 0; i < DataToExport.Rows.Count; i++)
            {
                var dataRow = DataToExport.Rows[i];
                var excelRow = sheet.CreateRow(HeaderRows + 1 + i);
                CreateCellForRow(excelRow, cols, dataRow, false);
            }
        }

        /// <summary>
        /// 根据datatable
        /// </summary>
        /// <param name="dataStartRowNumber">Excel文件顶部可能需要写入其他数据</param>
        /// <param name="dt"></param>
        /// <param name="xslTemplate"></param>
        /// <param name="saveNtsNumber"></param>
        /// <param name="savePath">保存位置</param>
        public void SaveWorkBook(string savePath)
        {
            CreateWorkBook();
            IOHelper.EnsureFile(savePath);
            FileStream fsOut = new FileStream(savePath, FileMode.Create);
            Book.Write(fsOut);
            fsOut.Close();
        }

        /// <summary>
        /// 根据datarow 创建 cells. 
        /// </summary>
        /// <param name="excelRow"></param>
        /// <param name="columns"></param>
        /// <param name="row">如果为null 则该行所有cell的值为空</param>
        /// <param name="isHead">如果是true 则创建表头.</param>
        private void CreateCellForRow(IRow excelRow, DataColumnCollection columns, DataRow row, bool isHead)
        {
            for (int i = 0; i < columns.Count; i++)
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
