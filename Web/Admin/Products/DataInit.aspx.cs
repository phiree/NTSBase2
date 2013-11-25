using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NModel;
using NBiz;
using NLibrary;
public partial class Admin_Products_DataInit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCreateProductCode_Click(object sender, EventArgs e)
    {
        NBiz.BizProduct bizProduct = new BizProduct();
        IList<Product> product_all = bizProduct.GetAll<Product>();

        foreach (Product p in product_all)
        {
            if (string.IsNullOrEmpty(p.ProductCode))
            {
                string proCate = p.CategoryCode;
                string topCateForProductCode = BizHelper.GetFirstCateCode(proCate);
                p.ProductCode = bizProduct.SerialNoUnit.GetFormatedSerialNo(topCateForProductCode);
                bizProduct.SaveOrUpdate(p);
            }
        }
        Notification.Show(this, "", "done", string.Empty);
    }
}