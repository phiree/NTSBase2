using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NModel;
using NBiz;
public partial class Stock_InventoryList : System.Web.UI.Page
{
    BizBillInventory bizBillInventory = new BizBillInventory();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }
    private void BindList()
    {
        rpt.DataSource = bizBillInventory.GetAll<BillInventory>().OrderByDescending(x=>x.CreatedDate);
        rpt.DataBind();
    }
}