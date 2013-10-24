using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NModel;
public partial class Admin_Showroom_PositionManage : System.Web.UI.Page
{

    NBiz.BizPosition bizPos = new NBiz.BizPosition();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindList();
    }
    private void BindList()
    { 
        IList<SR_Position> positions=new List<SR_Position>();

        SR_Position p1 = new SR_Position { Name="展馆1"};
        SR_Position p11 = new SR_Position { Name="展厅1",ParentPosition=p1 };
        SR_Position p111 = new SR_Position { Name = "展位1", ParentPosition = p11 };

        p11.ChildrenPosition.Add(p111);
        p1.ChildrenPosition.Add(p11);
        positions.Add(p1);

        rpLv1.DataSource = bizPos.GetAll<SR_Position>();// positions;
        rpLv1.ItemDataBound += new RepeaterItemEventHandler(rpLv1_ItemDataBound);
        rpLv1.DataBind();
    }

    void rpLv1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item||e.Item.ItemType== ListItemType.AlternatingItem)
        {
            SR_Position p = e.Item.DataItem as SR_Position;
            if (p.ChildrenPosition.Count == 0) return;
            foreach (Control c in e.Item.Controls)
            {
                if (c.GetType() == typeof(Repeater))
                {
                    Repeater rpt = (Repeater)c;

                    rpt.DataSource = p.ChildrenPosition;
                    rpt.ItemDataBound += new RepeaterItemEventHandler(rpLv1_ItemDataBound);
                    rpt.DataBind();
                }
            }
        }
    }
}