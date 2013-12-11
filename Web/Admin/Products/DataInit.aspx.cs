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
        IList<Product> product_all = bizProduct.GetAll<Product>().Where(x=>string.IsNullOrEmpty(x.ProductCode)).OrderBy(x=>x.NTSCode).ToList();

        foreach (Product p in product_all)
        {
            
                string proCate = p.CategoryCode.Replace(".",string.Empty);
              //  string topCateForProductCode = BizHelper.GetFirstCateCode(proCate);
                p.ProductCode = bizProduct.SerialNoUnit.GetFormatedSerialNo(proCate);
                bizProduct.SaveOrUpdate(p);
                bizProduct.SerialNoUnit.Save();
        }
       
        Notification.Show(this, "", "done",this.Request.RawUrl);
    }
}