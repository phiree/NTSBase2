using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using NBiz;
using NDAL;
public partial class Products_Default : System.Web.UI.Page
{
    BizProduct bizProduct = new NBiz.BizProduct();
  protected  BizSupplier bizSupplier = new BizSupplier();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            InitBind();
            LoadParameters();
            if (Membership.GetUser() != null)
            {
                dgProduct.Columns[9].Visible = true;
            }    
            BindProduct();
           
        }
        
    }
    BizCategory bizCate = new BizCategory();
    public void InitBind()
    {
        ddlCate.DataSource = bizCate.GetChildren("0");
        
        ddlCate.DataBind();
       
        ddlCate.Items.Insert(0, new ListItem {Text="全部",Value="-1" });
       
    }
    //搜索关键字回显
    private void LoadParameters()
    {
        string supplierName =Server.UrlDecode( Request["sname"]);
        tbxSupplierName.Text =  supplierName;
        tbxModel.Text = Server.UrlDecode(Request["model"]);
        string hasPhoto = Request["hasPhoto"];
        ddlHasPhoto.SelectedValue = hasPhoto;
        tbxCode.Text =Server.UrlDecode( Request["categoryCode"]);
        tbxName.Text = Request["name"];
        tbxNTSCode.Text = Request["ntscode"];
        tbxDelivery.Text = Request["delivery"];
        tbxOriginal.Text = Request["original"];
        ddlImageQuanlity.SelectedValue = Request["imagequality"];
        
        string cateCode = Request["categoryCode"];
        if (!string.IsNullOrEmpty(cateCode))
        {
            string topCate = cateCode.Substring(0, 2);
            if (!string.IsNullOrEmpty(topCate))
            {
                ddlCate.SelectedValue = topCate;
                ddlCateChild.DataSource = bizCate.GetChildren(topCate);
                ddlCateChild.DataBind();
                ddlCateChild.Items.Insert(0, new ListItem { Text = "全部", Value = "-1" });
            }
            if (cateCode.Length == 6)
            {
                string childCate = cateCode.Substring(3, 3);

                ddlCateChild.SelectedValue = childCate;
                hiCateChildValue.Value = childCate;
            }


        }
        else
        {
            hiCateChildValue.Value = string.Empty;
        }
    }

    private int GetPageIndex()
    {
        int pageIndex=0;
        string paramPageIndex = Request[pager.UrlPageIndexName];
        if (!int.TryParse(paramPageIndex, out pageIndex))
        {
            pageIndex = 0;
        }
        return pageIndex;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string cateCode = string.Empty;
        if (ddlCate.SelectedValue != "-1")
        {
            cateCode = ddlCate.SelectedValue;
        }
        if (ddlCateChild.SelectedValue != "-1")
        {
           // cateCode += "." + ddlCateChild.SelectedValue;
        }
        if (!string.IsNullOrEmpty(hiCateChildValue.Value)&&hiCateChildValue.Value!="-1")
        {
            cateCode += "." + hiCateChildValue.Value;
        }
        string targetUrl =string.Format( "Default.aspx?sname={0}&model={1}&hasphoto={2}&name={3}&categorycode={4}&ntscode={5}&imagequality={6}&original={7}&delivery={8}"
            , Server.UrlEncode(tbxSupplierName.Text)
            ,Server.UrlDecode(tbxModel.Text)
            ,ddlHasPhoto.SelectedValue
            ,tbxName.Text.Trim()
            , cateCode
            ,tbxNTSCode.Text.Trim()
            ,ddlImageQuanlity.SelectedValue
            ,tbxOriginal.Text.Trim()
            ,tbxDelivery.Text.Trim()
            );
        Response.Redirect(targetUrl, true);
       // BindProduct();
    }
    private void BindProduct()
    {
        string cateCode = string.Empty;
        if (ddlCate.SelectedValue != "-1")
        {
            cateCode = ddlCate.SelectedValue;
        }
        if (!string.IsNullOrEmpty(ddlCateChild.SelectedValue)&& ddlCateChild.SelectedValue != "-1")
        {
            cateCode += "." + ddlCateChild.SelectedValue;
        }
        //if (!string.IsNullOrEmpty(hiCateChildValue.Value))
        //{
        //    cateCode += "." + hiCateChildValue.Value;
        //}
        bool? hasPhoto=null;
        string strHasPhotoValue = ddlHasPhoto.SelectedValue;
        if (strHasPhotoValue == "yes") hasPhoto = true;
        else if(strHasPhotoValue=="no") hasPhoto = false;

        string imageQuality = ddlImageQuanlity.SelectedValue;
       
        int pageIndex = GetPageIndex();
        int totalRecords;
        var product = bizProduct.Search(tbxSupplierName.Text.Trim()
            ,tbxModel.Text.Trim()
            , hasPhoto
            ,tbxName.Text.Trim()
            , cateCode
            ,tbxNTSCode.Text.Trim()
            ,imageQuality
            ,tbxDelivery.Text.Trim()
            ,tbxOriginal.Text.Trim()
            , pager.PageSize
            , pageIndex, out totalRecords)
            .OrderBy(x=>x.CategoryCode);  // bizProduct.GetAll<NModel.Product>();
        pager.RecordCount = totalRecords;
        dgProduct.DataSource = product;
        dgProduct.DataBind();
       
    }

    protected void ddlCate_SelectedChanged(object sender, EventArgs e)
    {
        if (ddlCate.SelectedValue == "-1")
        {
            ddlCateChild.Items.Clear();
        }
        else {
            ddlCateChild.DataSource = bizCate.GetChildren(ddlCate.SelectedValue);
            ddlCateChild.DataBind();
            ddlCateChild.Items.Insert(0, new ListItem { Text="全部",Value="-1"});
        }

    }

    protected void dgProduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            NModel.Product p = e.Row.DataItem as NModel.Product;
            Repeater rptImages = e.Row.FindControl("rptImages") as Repeater;
            rptImages.DataSource = p.ProductImageList;
            rptImages.DataBind();

            //供应商
             NModel.Supplier supplier= bizSupplier.GetByCode(p.SupplierCode);
             Literal liSupplierName = e.Row.FindControl("liSupplierName") as Literal;
             liSupplierName.Text = supplier.Name + "<br/>" + supplier.EnglishName;

        }
    }

    protected void rptImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Footer)
        {
            if (((Repeater)sender).Items.Count == 0)
            {
                Image img = e.Item.FindControl("imgNoPic") as Image;
                img.Visible = true;
                img.ImageUrl = "~/content/images/no-image.gif";
            }
        }
    }
}