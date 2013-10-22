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
     

        //excel内存对象
        public HSSFWorkbook Book { get; set; }

        public DataSet DataToExport { get; set; }
        public DataExport()
        {
            HeaderRows = 1;
        }
        public DataExport(DataSet ds)
            : this(ds, 1)
        {
            
        }  
        public DataExport(DataSet ds, int headerRows)
        {
            if (headerRows < 0)
                throw new Exception("dataStartRowNumber必须大于等于0");
            HeaderRows = headerRows;
            DataToExport = ds;
        }
        IDrawing patriarch;
        public void CreateWorkBook()
        {
            if (string.IsNullOrEmpty(XSLFilePath))
            {
                Book = new HSSFWorkbook();
            }
            else
            {
                Book = new HSSFWorkbook(new FileStream(XSLFilePath, FileMode.OpenOrCreate));
            }
            for (int i = 0; i < DataToExport.Tables.Count; i++)
            {
                FillSheet(i, DataToExport.Tables[i]);
            }
            //   FillSheet(0);
        }
        private void FillSheet(int tableIndex,DataTable dataToFill)
        {


            if (string.IsNullOrEmpty(dataToFill.TableName))
            {
                dataToFill.TableName = "table" + tableIndex;
            }
            ISheet sheet;
            if (tableIndex < Book.NumberOfSheets)
            {
                sheet = Book.GetSheetAt(tableIndex);
            }
            else
            {
                sheet = Book.CreateSheet(dataToFill.TableName);
            }
            patriarch = sheet.CreateDrawingPatriarch();
            DataColumnCollection cols = dataToFill.Columns;
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
            for (int i = 0; i < dataToFill.Rows.Count; i++)
            {
                var dataRow = dataToFill.Rows[i];
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

                    //该地址是图片
                    if (Regex.IsMatch(cellValue, @"\.jpg|\.png|\.tiff", RegexOptions.IgnoreCase))
                    {
                        string filePath = System.Web.HttpContext.Current.Server.MapPath("/ProductImages/original/" + cellValue);
                        if (File.Exists(filePath))
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
                            System.Drawing.Bitmap targetImage = ThumbnailMaker.DrawThumbnail(image, ThumbnailType.GeometricScalingByWidth, 150, 0);
                            excelRow.Sheet.SetColumnWidth(i, MSExcelUtil.pixel2WidthUnits(targetImage.Width - 2));
                            excelRow.HeightInPoints = (float)((targetImage.Height - 2) * 0.75);
                            MemoryStream ms = new MemoryStream();
                            targetImage.Save(ms, image.RawFormat);
                            InsertImageToCell(ms, i, excelRow.RowNum);
                        }
                    }
                    else
                    {
                        cell.SetCellValue(cellValue);
                    }
                }
            }
        }

        private void InsertImageToCell(MemoryStream imageStream, int left, int top)
        {

            //store the coordinates of which cell and where in the cell the image goes
            HSSFClientAnchor anchor = new HSSFClientAnchor(1, 1, 0, 0, left, top, left + 1, top + 1);
            //types are 0, 2, and 3. 0 resizes within the cell, 2 doesn't
            anchor.AnchorType = 2;
            //add the byte array and encode it for the excel file
            int index = Book.AddPicture(imageStream.ToArray(), PictureType.PNG);
            IPicture signaturePicture = patriarch.CreatePicture(anchor, index);
        }
    }
}
