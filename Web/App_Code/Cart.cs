using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// 产品集合
/// </summary>
public class ProductCart
{

    public IList<CartItem> GetCartFromCookies()
    {
        IList<CartItem> CartItems = new List<CartItem>();
        HttpRequest Request = HttpContext.Current.Request;
        HttpResponse Response = HttpContext.Current.Response;
        HttpServerUtility Server = HttpContext.Current.Server;
        string cookieName = "_cart";
        HttpCookie cookie = Request.Cookies[cookieName];
        if (cookie == null)
        {
            cookie = new HttpCookie(cookieName, "[]");
            Response.Cookies.Add(cookie);
            return CartItems;
        }
        string cartJson = Server.UrlDecode(cookie.Value);
        Newtonsoft.Json.Linq.JArray arrya = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(cartJson);
        if (CartItems == null)
        {
            cookie.Value = "[]";
            Response.Cookies.Add(cookie);
            return CartItems;
        }
        CartItems = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<CartItem>>(cartJson);
        return CartItems;
    }

}
public class CartItem
{
    public string Code;
    public int Qty;
}
