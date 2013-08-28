<%@ WebHandler Language="C#" Class="SupplierList" %>

using System;
using System.Web;
using System.Collections.Generic;
using NBiz;
using NModel;
public class SupplierList : IHttpHandler {

    BizCategory bizCate = new BizCategory();
    public void ProcessRequest (HttpContext context) {

        var request = context.Request;
        string conditions = string.Empty;

        string parentCode = request["parentCode"];
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