using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NModel;
using NBiz;
using System.Data;
using NLibrary;
using System.Web.Security;
public partial class Products_Cart : System.Web.UI.Page
{
    BizProduct bizProduct = new BizProduct();

    protected void Page_Load(object sender, EventArgs e)
    {
        //获取集合列表
       MembershipUser mu=  Membership.GetUser();
       
       Response.Write(Request.AnonymousID);
      // ucProList.ProductList = GetFromCookies();
        }
    private string MemberId {
        get { 
          //if(Page.Request.IsAuthenticated
            return string.Empty;
        }
    }
    private IList<Product> GetFromCookies()
    {
        IList<CartItem> items = new ProductCart().GetCartFromCookies();
        List<Product> productList = new List<Product>();
        foreach (CartItem item in items)
        {
            Product p = bizProduct.GetOne(new Guid(item.Code));
            productList.Add(p);
        }
        return productList;

    }
    DataExport transfer = new DataExport();
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //DataTable dtProductsHasImage = ObjectConvertor.ToDataTable<Product>(GetFromCookies());
        //transfer.CreateXslFromDataTable(dtProductsHasImage, 1,  Guid.NewGuid().ToString()+".xls");

        ExcelExport export = new ExcelExport("产品导出_" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        export.ExportProductExcel(GetFromCookies());
    }
    
}