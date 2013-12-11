using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.Data;
public partial class BillProcesing : System.Web.UI.Page
{
    string type = "1";
    protected void Page_Load(object sender, EventArgs e)
    {
         type = Request["type"];
        string procedure = string.Empty;
        if (type == "1")
            procedure = "ERPService_BillProcess";
        else if(type=="2")
            procedure = "ERPService_BillCheckProcess";
        else if(type=="3")
            procedure = "ERPService_BillProcess_Finance";

        if (procedure == string.Empty)
        {
            Response.Write("No Procedure");
        }
        else
        {
            Bind(procedure);
        }
    }
    
    private void Bind(string procedureName)
    {
        string cacheKey = "cache_" + type;
        object obj = Cache.Get(cacheKey);
        DataSet ds = new DataSet();
        if (true)//obj == null)
        {
            ds = DataAccess.CommonSQL.ExcuteProcedureDataset(procedureName);

            Cache.Add(cacheKey, ds, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromHours(1), CacheItemPriority.Default, null);

        }
        else
        {
            ds = obj as DataSet;
        }

        gv.DataSource = ds;
        gv.DataBind();
    }
}