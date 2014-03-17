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
        else if(type=="4")
          procedure="ERP_CunHuoHeSuan";
        if (procedure == string.Empty)
        {
            Response.Write("No Procedure");
        }
        else
        {
            Bind(procedure);
        }
        gv.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    
    private void Bind(string procedureName)
    {
        string cacheKey = "cache_" + type;
        object obj = Cache.Get(cacheKey);
        DataSet ds = new DataSet();
        if (true)//obj == null)
        {
            ds = DataAccess.CommonSQL.ExcuteProcedureDataset(procedureName);
            //Cache.Add(cacheKey, ds, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(1), CacheItemPriority.Default, null);
Cache.Add(cacheKey, ds, null, DateTime.Now.AddMinutes(1d), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

        }
        else
        {
            ds = obj as DataSet;
        }

        gv.DataSource = ds;
        gv.DataBind();
    }
}