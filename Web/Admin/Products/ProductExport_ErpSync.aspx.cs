using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBiz;
using NModel;
public partial class Products_ProductExport_ErpSync : System.Web.UI.Page
{
    ProductSync ps = new ProductSync();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ps.CreatExcelForImport(Server.MapPath("/Content/files/"), Server.MapPath("/Product_ErpSyncExcel/"));

        lblResult.Text = "导出完成." + DateTime.Now;
    }
}