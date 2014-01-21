using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
public partial class Admin_Membership_UserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }

    private void BindList()
    { 
        int pageIndex=pagerUserList.CurrentPageIndex;
        int totalRecord;
        var userlist = Membership.GetAllUsers(pageIndex, pagerUserList.PageSize, out totalRecord);
        rptUserList.DataSource = userlist;
        rptUserList.DataBind();
        pagerUserList.RecordCount = totalRecord;
    }
}