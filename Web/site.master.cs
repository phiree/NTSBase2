using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBiz;
using NModel;
public partial class site : System.Web.UI.MasterPage
{

    BizProductCollection bizProductCollection = new BizProductCollection();
    protected void Page_Load(object sender, EventArgs e)
    {
        ProductCollection pc= bizProductCollection.GetDefaultCollection(GlobalVarible.GetUserId());
        sumCart.InnerText = pc.Products.Count.ToString();
    }
}
