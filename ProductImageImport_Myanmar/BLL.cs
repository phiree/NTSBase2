using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
namespace ProductImageImport_Myanmar
{
    public class BLL
    {
        DAL dal = new DAL();
        public void ReadImageDataToBytes()
        { }
        public void BuildBulkInsert(string foldPath)
        {
            string sql = string.Empty;
            DirectoryInfo dir = new DirectoryInfo(foldPath);
         //   FileInfo[] imageFiles = dir.GetFiles(foldPath);
            string[] fileNames=Directory.GetFiles(foldPath);

            dal.BulkUpdateImage(fileNames);
        }
    }
}
