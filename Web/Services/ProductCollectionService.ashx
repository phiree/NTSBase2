<%@ WebHandler Language="C#" Class="ProductCollectionService" %>

using System;
using System.Web;
using System.Collections.Generic;
using NBiz;
using NModel;
public class ProductCollectionService : IHttpHandler
{

    //BizProductCollection bpc = new NBiz.BizProductCollection();
    BizProduct bizProduct = new NBiz.BizProduct();
    public void ProcessRequest(HttpContext context)
    {

        var request = context.Request;
        string productid = string.Empty;
        productid = request["pid"];
        string userId = GlobalVarible.GetUserId();
        string currentCollectionName = request["collectionName"];
        BizProductCollection bizPC = new NBiz.BizProductCollection(userId);
        ProductCollection pc = bizPC.GetDefaultCollection(userId);

        Product p = bizProduct.GetOne(new Guid(productid));
        if (!pc.Products.Contains(p))
        {
            pc.Products.Add(p);
        }
        else
        {
            pc.Products.Remove(p);
        }
        bizPC.Save(pc);
        context.Response.ContentType = "application/json";
        context.Response.Write(pc.Products.Count);
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}