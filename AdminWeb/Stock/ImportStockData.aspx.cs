using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NModel;
using NBiz;
public partial class Stock_ImportStockData : System.Web.UI.Page
{
    NBiz.BizStock bizStock = new BizStock();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        string errMsg;
        bizStock.ImportProductFromExcel(fuExcel.PostedFile.InputStream, out errMsg);
    }
}