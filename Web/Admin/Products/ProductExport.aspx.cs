﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBiz;
using NModel;
using NLibrary;
public partial class Admin_Products_ProductExport : System.Web.UI.Page
{
    ProductImagesExport imageExporter = new ProductImagesExport();
    BizProduct bizProduct = new BizProduct();
    IList<Product> productToExport;
    string message;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private IList<Product> ProductsWithEnglish
    {
        get {
           
                productToExport = bizProduct.GetProducts_English(Convert.ToDateTime(tbxBeginDate.Text ));
           
                return productToExport;
        }
    }
    private IList<Product> ProductsNoImages
    {
        get
        {
            if (productToExport == null)
            {
                productToExport = bizProduct.GetProductsNoImages();
            }
            return productToExport;
        }
    }
    private IList<Product> ProductsCustomList
    {
        get
        {

            productToExport = bizProduct.GetListByProvidedModelNumberSupplierNameList
                (tbxPs.Text,out message);

            return productToExport;
        }
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {

        ExcelExport export = new ExcelExport("产品资料" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        export.ExportProductExcel(ProductsWithEnglish);
  
    }
    protected void btnCustomListImage_Click(object sender, EventArgs e) {
        NLogger.Logger.Debug("--开始导出图片--产品数量" + ProductsCustomList.Count);

        imageExporter.Export(ProductsCustomList, Server.MapPath("/productImagesExport/") + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "\\",

      Server.MapPath("/ProductImages/original/"), NModel.Enums.ImageOutPutStratage.Category_NTsCode);

        lblMsg.Text = "操作完成. 产品图片已保存于 \\192.168.1.44\\导出图片\\ ";
        NLogger.Logger.Debug("--导出结束--");
    }
    protected void btnCustomListExcel_Click(object sender, EventArgs e)
    {
        string name = tbxExportName.Text.Trim();
        if (string.IsNullOrEmpty(name))
        {
            name = DateTime.Now.ToString("yyyyMMdd-hh-ss-mm");
        }
        new ExcelExport(name).ExportProductExcel(ProductsCustomList);
    }
  
    protected void btnExportImage_Click(object sender, EventArgs e)
    {

        NLogger.Logger.Debug("--开始导出图片--产品数量"+ProductsWithEnglish.Count);

        imageExporter.Export(ProductsWithEnglish, Server.MapPath("/productImagesExport/") + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "\\",

      Server.MapPath("/ProductImages/original/"), NModel.Enums.ImageOutPutStratage.Category_NTsCode);

        lblMsg.Text = "操作完成. 产品图片已保存于 \\192.168.1.44\\导出图片\\ ";
        NLogger.Logger.Debug("--导出结束--");
    }

    protected void btnExport_NoImage_Click(object sender, EventArgs e)
    {
        ExcelExport export = new ExcelExport("没有图片的产品" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        export.ExportProductExcel(ProductsNoImages);
        lblMsg.Text = "操作完成";
       
    }
}
