using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BillProcesing : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = Request["type"];
        string procedure = string.Empty;
        if (type == "1")
            procedure = "ERPService_BillProcess";
        else if(type=="2")
            procedure = "ERPService_BillCheckProcess";
        if (procedure == string.Empty)
        {
            
        }
        else
        {
            Bind(procedure);
        }
    }
    private void Bind(string procedureName)
    {
        gv.DataSource = DataAccess.CommonSQL.ExcuteProcedureDataset(procedureName);
        gv.DataBind();
    }
}