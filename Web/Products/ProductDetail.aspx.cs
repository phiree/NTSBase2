using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NModel;
using NBiz;
public partial class Products_ProductDetail : System.Web.UI.Page
{
    BizSupplier bizSupplier = new BizSupplier();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDetail(GetProduct());
        }
    }
    BizProduct bizProduct = new BizProduct();
    private Product  GetProduct()
    {
        Guid id;
        if (!Guid.TryParse(Request["id"], out id))
        {
            Response.Redirect("/err.aspx",true);
        }
        Product p = bizProduct.GetOne(id);
        return p;

    }
    private void BindDetail(Product p)
    {
        dv.DataSource = new Product[] { p };
        dv.DataBind();
    }
    protected void dv_DataBound(object sender, EventArgs e)
    {
        Product p = dv.DataItem as Product;
        Repeater rpt = dv.FindControl("rptImages") as Repeater;
        rpt.DataSource = p.ProductImageList;
        rpt.DataBind();

        Supplier supplier = bizSupplier.GetByCode(p.SupplierCode);
        Label lblSupplierName = dv.FindControl("lblSupplierName") as Label;
        lblSupplierName.Text = supplier.Name;
        if (!string.IsNullOrEmpty(supplier.NickName))
        {
            lblSupplierName.Text += "  (" + supplier.NickName + ")";
        }
    }
    protected void dv_ItemCreated(object sender, EventArgs e)
    {
        
    }
    protected void dv_Load(object sender, EventArgs e)
    {
        

    }
}