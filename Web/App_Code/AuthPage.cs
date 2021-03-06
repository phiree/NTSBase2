﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
/// <summary>
/// 需要验证身份的基页面
/// </summary>
public class AuthPage:Page
{
    public MembershipUser CurrentMember { get; private set; }
    NBiz.NTSMembershipProvider bizNtsMember = new     NBiz.NTSMembershipProvider ();
    protected NModel.NTSMember NtsMember=null;
	public AuthPage()
	{
        CurrentMember = Membership.GetUser();
        if (CurrentMember != null)
        {
          NtsMember=  bizNtsMember.NM_GetUser(CurrentMember.UserName);
        }
	}
    protected override void OnPreLoad(EventArgs e)
    {
        if (CurrentMember == null)
        {
            FormsAuthentication.RedirectToLoginPage();
            Response.End();
        }
    }
}