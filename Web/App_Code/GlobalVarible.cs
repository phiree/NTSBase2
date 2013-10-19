using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
/// <summary>
/// 产品集合
/// </summary>
public class GlobalVarible
{
    public static string  GetUserId(){
        string userId = HttpContext.Current.Items["G_UserId"]==null?string.Empty:(string)HttpContext.Current.Items["G_UserId"];
        if (!(string.IsNullOrEmpty(userId))) { return userId; }
        MembershipUser mu= Membership.GetUser();
        if (mu != null)
        {
            userId = mu.ProviderUserKey.ToString();
        }
        else
        {
            userId = HttpContext.Current.Request.AnonymousID;
        }
        if (string.IsNullOrEmpty(userId))
        {
            throw new Exception("Userid can't be null");
        }
        HttpContext.Current.Items["G_UserId"] = userId;
        return userId;
    } 
}
