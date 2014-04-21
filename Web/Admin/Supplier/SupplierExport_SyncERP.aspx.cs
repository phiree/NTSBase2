using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBiz;
public partial class Admin_Supplier_SupplierExport_SyncERP : System.Web.UI.Page
{
    SupplierSync ss = new SupplierSync();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ss.CreatExcelForImport(Server.MapPath("/Content/files/"), Server.MapPath("/Product_ErpSyncExcel/"));

        lblResult.Text = "导出完成." + DateTime.Now;
       
    }
}