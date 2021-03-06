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
    log4net.ILog log = log4net.LogManager.GetLogger("NTS.Web");
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
    private IList<Product> ProductListForNtscodeList
    {
        get
        {
            if (cbxAll.Checked)
            {
                productToExport = bizProduct.GetAll<Product>() ;
            }
            else
            { 
            string[] ntsCodeList = tbxNtscodeList.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            log.Debug("ProductListForNtscodeList 总数:" + ntsCodeList.Length);
            productToExport = bizProduct.GetListByNTSCodeList(ntsCodeList);
            }
            

            return productToExport;
        }
    }
    private IList<Product> SupplierProducts
    {
        get {
            if (productToExport != null) return productToExport;
            productToExport = new List<Product>();
            string[] supplierCodes = tbxSupplierNames.Text.Split(new string[]{ Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in supplierCodes)
            {
               IList<Product> pos=  bizProduct.GetListBySupplierCode(s);
               productToExport = productToExport.Union(pos).ToList();
            }
            return productToExport.Where(x => x.ProductImageList.Count > 0).ToList();

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

    protected void btnSupplierExportExcel_Click(object sender, EventArgs e)
    {
        ExcelExport export = new ExcelExport("供应商产品" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        export.ExportProductExcel(SupplierProducts);
        lblMsg.Text = "操作完成";
    }
    protected void btnSupplierExportImage_Click(object sender, EventArgs e)
    {

        NLogger.Logger.Debug("--开始导出图片--产品数量" + SupplierProducts.Count);

        imageExporter.Export(SupplierProducts, Server.MapPath("/productImagesExport/") + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "\\",

      Server.MapPath("/ProductImages/original/"), NModel.Enums.ImageOutPutStratage.Supplier_OriginalName);

        lblMsg.Text = "操作完成. 产品图片已保存于 \\192.168.1.44\\导出图片\\ ";
        NLogger.Logger.Debug("--导出结束--");
    }

    protected void btnNtscodeExportExcel_Click(object sender, EventArgs e)
    {
        ExcelExport export = new ExcelExport("NTSCode列表" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        //foreach (Product p in ProductListForNtscodeList)
        //{
        //    tbxNtscodeList.Text += p.Name + Environment.NewLine;
        //}
       
        export.ExportProductExcel(ProductListForNtscodeList);
        lblMsg.Text = "操作完成";
         
    }
    protected void btnNtscodeExportImage_Click(object sender, EventArgs e)
    {
        NLogger.Logger.Debug("--开始导出图片--产品数量" + ProductListForNtscodeList.Count);

        imageExporter.Export(ProductListForNtscodeList, Server.MapPath("/productImagesExport/") + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "\\",

      Server.MapPath("/ProductImages/original/"), NModel.Enums.ImageOutPutStratage.Category_NTsCode);

        lblMsg.Text = "操作完成. 产品图片已保存于 \\192.168.1.44\\导出图片\\ ";
        NLogger.Logger.Debug("--导出结束--");
    }
}
