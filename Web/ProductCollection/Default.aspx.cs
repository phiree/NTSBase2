using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBiz;
using NModel;
public partial class ProductCollection_Default : System.Web.UI.Page
{
    BizProductCollection bizPC = new BizProductCollection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCollection();
            LoadCollectionList();
        }
    }
    ProductCollection currentCollection = null;
    ProductCollection CurrentCollection
    {
        get {
            if (currentCollection == null)
            {
                string cid = Request["id"];

                if (!string.IsNullOrEmpty(cid))
                {
                    currentCollection = bizPC.GetOne(new Guid(cid));
                    
                }
                else
                {
                    currentCollection = bizPC.GetDefaultCollection(GlobalVarible.GetUserId());
                }
            }
            return currentCollection;
        }
    }
    private void LoadCollection()
    {


        tbxCollectionName.Text = CurrentCollection.CollectionName;

        ucProList.ProductList = CurrentCollection.Products;

    }

    private void LoadCollectionList()
    {
        rpt.DataSource = bizPC.GetCollectionList(GlobalVarible.GetUserId());
        rpt.DataBind();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExcelExport export = new ExcelExport("产品导出_" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        export.ExportProductExcel(bizPC.GetDefaultCollection(GlobalVarible.GetUserId()).Products);
    }
    protected void btnCreateNew_Click(object sender, EventArgs e)
    {
        ProductCollection pc = bizPC.CreateNew(tbxNewName.Text.Trim(), GlobalVarible.GetUserId());

        NLibrary.Notification.Show(this, "", "创建成功", "/productcollection/?id=" + pc.Id);

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        CurrentCollection.Products.Clear();
        bizPC.Save(CurrentCollection);
        NLibrary.Notification.Show(this, "", "清空完成",Request.Url.AbsoluteUri);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        bizPC.Delete(CurrentCollection);
        //需要指定一个默认集合
        bool deleteDefault = CurrentCollection.IsDefault;
        string  newDefault=string.Empty;
        if (CurrentCollection.IsDefault)
        {
            var list = bizPC.GetCollectionList(GlobalVarible.GetUserId());
            if (list.Count > 0)
            {
                list[0].IsDefault = true;
                bizPC.Save(list[0]);
                newDefault = list[0].CollectionName;
            }
            
            
        }
        string msg = "删除完成";
        if (deleteDefault&&!string.IsNullOrEmpty(newDefault))
        {
            msg += ",并且指定了新的默认集合:" + newDefault;
        }
        NLibrary.Notification.Show(this, "", msg, "/productcollection/");
    }
    protected void btnSaveName_Click(object sender, EventArgs e)
    {
        CurrentCollection.CollectionName = tbxCollectionName.Text;
        bizPC.Save(CurrentCollection);
        LoadCollectionList();
        NLibrary.Notification.Show(this, "", "修改名称完成", "");
    }
    protected void btnSetDefault_Click(object sender, EventArgs e)
    {
        bizPC.SetDefaultCollection(Request["id"], GlobalVarible.GetUserId());
        NLibrary.Notification.Show(this, "", "设置默认完成", "/productcollection/");
    }
}