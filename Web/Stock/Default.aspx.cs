using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NModel;
using NBiz;
public partial class Stock_StockList : System.Web.UI.Page
{
    BizStock bizStock = new BizStock();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList(bizStock.GetAll<ProductStock>());
        }
    }

    private void BindList(IList<ProductStock> stocks)
    {
        rpt.DataSource = stocks.OrderByDescending(x=>x.UpdateTime);
        rpt.DataBind();
    }
}