<%@ WebHandler Language="C#" Class="ProductCollectionService" %>

using System;
using System.Web;
using System.Collections.Generic;
using NBiz;
using NModel;
/// <summary>
/// 产品集 ajax服务. 增加,删除,
/// </summary>
public class ProductCollectionService : IHttpHandler
{

    BizCategory bizCate = new BizCategory();
    public void ProcessRequest (HttpContext context) {

        var request = context.Request;
        string userid = request["userid"];

        string parentCode = request["productid"];
        IList<Category> cates = bizCate.GetChildren(parentCode);
        string json = NLibrary.JosnHelper.GetJson<IList<Category>>(cates);
        context.Response.ContentType = "application/json";
        context.Response.Write(json);
    }

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}