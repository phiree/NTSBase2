using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBiz;
using NModel;
public partial class Stock_InventoryList :  AuthPage
{
    bool IsNew = true;
    BillInventory billInventory = null;
    BizBillInventory bizBillInventory = new BizBillInventory();
    protected void Page_Load(object sender, EventArgs e)
    {
        string paramId = Request["Id"];
        if (!string.IsNullOrEmpty(paramId))
        {
            IsNew = false;
            billInventory = bizBillInventory.GetOne(new Guid(paramId));
           
            
        }
        else
        {
            billInventory = new BillInventory();
            billInventory.CreateMember = NtsMember;

        }
        LoadForm();
    }
    protected void LoadForm()
    {
        tbxBillNo.Text = billInventory.BillNo;
        lblCreator.Text = CurrentMember.UserName;
        BindRepeater();
    }

    protected void btnAddToInventory_Click(object sender, EventArgs e)
    {
        string[] ntsCode=tbxNTSCodeList.Text.Split(Environment.NewLine.ToCharArray());
        bizBillInventory.AddInventoryFromNtsCodeList(billInventory, ntsCode);
        bizBillInventory.Save(billInventory);
        if (IsNew)
        {
            Response.Redirect(Request.RawUrl + "?id=" + billInventory.Id, true);
        }
        else
        {
            BindRepeater();
        }
    }
    private void BindRepeater()
    {
        rptProduct.DataSource = billInventory.InventoryList;
        rptProduct.DataBind();
    }
    protected void btnApply_Click(object sender, EventArgs e)
    { }
    protected void btnRefuse_Click(object sender, EventArgs e)
    { }
    protected void btnCheck_Click(object sender, EventArgs e)
    { 
    
    }
}