using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using NLibrary;
/// <summary>
/// 角色列表
/// </summary>
public partial class Admin_Membership_Role_Default : System.Web.UI.Page
{
    NBiz.BizRole bizRole = new NBiz.BizRole();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRoleList();
        }
    }
    private void BindRoleList()
    {
        IList<NModel.Role> allRoles = bizRole.GetAll<NModel.Role>();
       // gvRole.DataSource = allRoles;
       // gvRole.DataBind();
    }
    protected void btnAddRole_Click(object sender, EventArgs e)
    {
        Roles.CreateRole(tbxRoleName.Text);
        BindRoleList();
        Notification.Show(this, "", "保存成功", string.Empty);
    }
}