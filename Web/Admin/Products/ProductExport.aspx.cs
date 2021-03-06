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
    bool needInsertImage = true;
    string message;
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
                (tbxPs.Text,out message).OrderBy(x=>x.SupplierCode).OrderBy(x=>x.ModelNumber).ToList();

            return productToExport;
        }
    }
    IList<Product> supplierProducts;
    private IList<Product> SupplierProducts
    {
        get {
           if (supplierProducts != null) return supplierProducts;
            supplierProducts = new List<Product>();
            string[] supplierCodes = tbxSupplierNames.Text.Split(new string[]{ Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in supplierCodes)
            {
               IList<Product> pos=  bizProduct.GetListBySupplierCode(s);
               supplierProducts = supplierProducts.Union(pos).ToList();
            }
            //为什么要加 下面这个限制条件呢? 
            return supplierProducts;
          //  return supplierProducts.Where(x => x.ProductImageList.Count > 0).ToList();

        }
    }
    IList<Product> productFromNtsCodeList
    {
        get
        {
            return bizProduct.GetListByNTSCodeList(tbxCodeList.Text.Split(Environment.NewLine.ToCharArray()))
                .OrderBy(x => x.SupplierCode).OrderBy(x => x.ModelNumber).ToList();

        }
    }
   
    protected void btnCustomListImage_Click(object sender, EventArgs e) {
        NLogger.Logger.Debug("--开始导出图片--产品数量-->");

        imageExporter.Export(ProductsCustomList, Server.MapPath("/productImagesExport/") + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "\\",

      Server.MapPath("/ProductImages/original/"), NModel.Enums.ImageOutPutStratage.Category_NTsCode);

        lblMsg.Text = "操作完成. 产品图片已保存于 \\192.168.1.44\\导出图片\\ ";
        NLogger.Logger.Debug("--导出结束--");
    }
    protected void btnCustomListExcel_Click(object sender, EventArgs e)
    {
        //string name = tbxExportName.Text.Trim();
        //if (string.IsNullOrEmpty(name))
        //{
        //    name = DateTime.Now.ToString("yyyyMMdd-hh-ss-mm");
        //}
       // ExcelExport export = new ExcelExport("产品资料" + DateTime.Now.ToString("yyyyMMdd-HHmmss"), cbxNeedInertImage.Checked);
        needInsertImage = cbxNeedInertImage_CustomList.Checked;
     
        ExportExcel(ProductsCustomList);
      //  new ExcelExport(name).ExportProductExcel(ProductsCustomList,cbxNeedInertImage.Checked);
    }
  
   
    
    protected void btnExport_NoImage_Click(object sender, EventArgs e)
    {
        //ExcelExport export = new ExcelExport("没有图片的产品" + DateTime.Now.ToString("yyyyMMdd-HHmmss"), cbxNeedInertImage.Checked);
        //export.ExportProductExcel(ProductsNoImages);
        //lblMsg.Text = "操作完成";
        
        ExportExcel(ProductsNoImages);
       
    }
 
    protected void btnExportCodeListExcel_Click(object sender, EventArgs e)
    {
        needInsertImage = cbxNeedInertImage_NTSCode.Checked;
        ExportExcel(productFromNtsCodeList);
      
    }
    protected void btnExportCodeListImage_Click(object sender, EventArgs e)
    {
        ExportImage(productFromNtsCodeList);
    }
    protected void btnSupplierExportExcel_Click(object sender, EventArgs e)
    {
    //    ExcelExport export = new ExcelExport("供应商产品" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
    //    export.ExportProductExcel(SupplierProducts);
    //   lblMsg.Text = "操作完成";
           needInsertImage = cbxNeedInertImage_Supplier.Checked;
     
        ExportExcel(SupplierProducts);
    }


    protected void btnSupplierExportImage_Click(object sender, EventArgs e)
    {

        //  NLogger.Logger.Debug("--开始导出图片--产品数量" + SupplierProducts.Count);

        //  imageExporter.Export(SupplierProducts, Server.MapPath("/productImagesExport/") + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "\\",

        //Server.MapPath("/ProductImages/original/"), NModel.Enums.ImageOutPutStratage.Supplier_OriginalName);

        //  lblMsg.Text = "操作完成. 产品图片已保存于 \\192.168.1.44\\导出图片\\ ";
        //  NLogger.Logger.Debug("--导出结束--");
       
        ExportImage(SupplierProducts);
    }
    private void ExportExcel(IList<Product> productList)
    {
        ExcelExport export = new ExcelExport("NTS_" + DateTime.Now.ToString("yyyyMMdd-HHmmss"), needInsertImage);
       // IList<Product> pss = bizProduct.GetListByNTSCodeList(tbxCodeList.Text.Split(Environment.NewLine.ToCharArray()));
        export.ExportProductExcel(productList);
      //  NLibrary.Notification.Show(this, "操作完成", "操作已经完成", string.Empty);
    }
    private void ExportImage(IList<Product> productList)
    {
        string msg = "--开始导出图片--产品数量"+productList.Count+"-->";
        NLogger.Logger.Debug("--开始导出图片--产品数量" + productList.Count);

        imageExporter.Export(productList, Server.MapPath("/productImagesExport/") + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "\\",

      Server.MapPath("/ProductImages/original/"), NModel.Enums.ImageOutPutStratage.Category_NTsCode);

        msg += "操作完成. 产品图片已保存于[192.168.1.44-导出图片-]";
        NLogger.Logger.Debug("--导出结束--");
      //  lblMsg.Text = msg;
      //  NLibrary.Notification.Show(this, "", msg, string.Empty);
    }
  
}
