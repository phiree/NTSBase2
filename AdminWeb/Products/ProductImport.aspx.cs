using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBiz;
public partial class Admin_Products_ProductImport : System.Web.UI.Page
{
    BizProduct bizProduct = new BizProduct();
    BizImportLog bizLog = new BizImportLog();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.InnerHtml = string.Empty;
    }
    
    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {
            string errMsg;
            NModel.ImportOperationLog importLog = new NModel.ImportOperationLog();
            
           IList<NModel.Product> productImported= bizProduct.ImportProductFromExcel(fuProduct.PostedFile.InputStream,out errMsg);
           importLog.FileFrom = tbxSource.Text.Trim();
           importLog.FinishTime = DateTime.Parse(tbxFinishTime.Text);
           importLog.ImportedFileName = fuProduct.FileName;
           importLog.ImportedItems = productImported;
           importLog.ImportMember = tbxOperator.Text.Trim();
           importLog.ImportResult = errMsg;
           importLog.ImportTime = DateTime.Now;
          // bizLog.Save(importLog);
            lblMsg.Attributes["class"] = "success";
            lblMsg.InnerHtml = errMsg;
        }
        catch (Exception ex){
            lblMsg.Attributes["class"] = "error";
            string innerException = ex.InnerException==null ?"": ex.InnerException.Message;
            lblMsg.InnerHtml = ex.Message+"<br/>"+innerException;
        }

    }
}