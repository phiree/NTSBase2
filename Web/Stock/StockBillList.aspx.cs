using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBiz;
using NModel;
using NLibrary;
public partial class Stock_StockBillList : System.Web.UI.Page
{
    BizBill bizBill = new BizBill();
    StockActivityType stockActivityType =  StockActivityType.Export;
    protected void Page_Load(object sender, EventArgs e)
    {
        string paramType = Request["type"];
        if (string.IsNullOrEmpty(paramType))
        {
            Notification.Show(this, "错误", "传入参数有误", NotificationType.error,string.Empty,true,2000);
        }
        stockActivityType = (StockActivityType)Enum.Parse(typeof(StockActivityType), paramType);
        if (!IsPostBack)
        {
            BindList();
        }
    }
    private void BindList()
    { 
        int totalRecords;
        rpt.DataSource = bizBill.GetStockBill(stockActivityType, GetPageIndex(), pager.PageSize, out totalRecords);
        pager.RecordCount = totalRecords;
        rpt.DataBind();
    }
    private int GetPageIndex()
    {
        int pageIndex = 0;
        string paramPageIndex = Request[pager.UrlPageIndexName];
        if (!int.TryParse(paramPageIndex, out pageIndex))
        {
            pageIndex = 0;
        }
        return pageIndex;
    }
}