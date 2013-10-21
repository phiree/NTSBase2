using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBiz;
public partial class ProductCollection_Default : System.Web.UI.Page
{
    BizProductCollection bizPC = new BizProductCollection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ucProList.ProductList = bizPC.GetDefaultCollection(GlobalVarible.GetUserId()).Products;
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExcelExport export = new ExcelExport("产品导出_" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        export.ExportProductExcel(bizPC.GetDefaultCollection(GlobalVarible.GetUserId()).Products);
    }
}