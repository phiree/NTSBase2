using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBiz;
using NModel;
public partial class Stock_StockTrace : System.Web.UI.Page
{
    BizStockBillDetail bizDetail = new BizStockBillDetail();
    protected void Page_Load(object sender, EventArgs e)
    {
        string paramId = Request["id"];
        BindList(new Guid(paramId));
    }

    protected void BindList(Guid productId)
    {
        gv.DataSource = bizDetail.GetListByProduct(productId).OrderByDescending(x => x.UpdateTime);
        gv.DataBind();
    }
}