using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NModel;
using NBiz;
using NLibrary;
using System.Data;
using NPOI.HSSF.UserModel;
using System.IO;
/// <summary>
///ExcelExport 的摘要说明
/// </summary>
public class ExcelExport
{
    string saveFileName;
	public ExcelExport(string saveFileName)
	{
        this.saveFileName=saveFileName;
	}
    string[] languages = {"zh","en"};
    private IList<Product> BuildProductsByLanguage(IList<Product> originalProductList)
    {
        List<Product> products = new List<Product>();

        Dictionary<string, IList<Product>> ds_Products = new Dictionary<string, IList<Product>>();

        foreach (Product p in originalProductList)
        {
            foreach (string lan in languages)
            {
                Product pInLang = p.GetProductOfSpecialLanguage(lan);
                if (pInLang != null)
                {
                    products.Add(pInLang);
                }
            }
        }
        return products;
    }
    private Dictionary<string, IList<Product>> BuildProductsDictByLanguage(IList<Product> originalProductList)
    {
        Dictionary<string, IList<Product>> ds_Products = new Dictionary<string, IList<Product>>();
        foreach (Product p in originalProductList)
        {
            foreach (string lan in languages)
            {
                Product pInLang = p.GetProductOfSpecialLanguage(lan);
                if (pInLang != null)
                {
                    if (ds_Products.Keys.Contains(lan))
                    {
                        ds_Products[lan].Add(pInLang);
                    }
                    else
                    {
                        ds_Products.Add(lan,new List<Product>(){pInLang});
                    }
                }
            }
        }
        return ds_Products;
    }
    public void ExportProductExcel(IList<Product> products)
    {
     //   DataTable dt = ObjectConvertor.ToDataTable<Product>(BuildProductsByLanguage(products));
        DataSet ds_products = ObjectConvertor.ToDataSet<Product>(BuildProductsDictByLanguage(products));
        ExportProductExcel(ds_products);
    }
    private void ExportProductExcel(DataSet ds)
    {
        DataExport tt = new DataExport(ds.Tables[0]);
       tt.CreateWorkBook();
        DownLoadXslFile(tt.Book);
    }
    private void DownLoadXslFile(HSSFWorkbook workbook)
    {
        // Save the Excel spreadsheet to a MemoryStream and return it to the client
        using (var exportData = new MemoryStream())
        {
            HttpResponse Response = HttpContext.Current.Response;
            workbook.Write(exportData);
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}",HttpUtility.UrlEncode(saveFileName) ));
            //Response.Clear();
            Response.BinaryWrite(exportData.GetBuffer());
           // Response.End();
        }
    }
}