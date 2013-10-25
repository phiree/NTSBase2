using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NModel;
using NBiz;
public partial class Admin_Showroom_StockIn_StockAddEdit : AuthPage
{

    bool isNew = true;
    BillStock billStock = null;
    BizBill bizBill = new BizBill();
    protected void Page_Load(object sender, EventArgs e)
    {
        //入库 还是出库
        string paramType = Request["type"];
        if (string.IsNullOrEmpty(paramType))
        {
            throw new Exception("错误.请传入单据类型");
        }
        StockActivityType stockActivityType = (StockActivityType)Enum.Parse(typeof(StockActivityType), paramType);
        switch (stockActivityType)
        {
            case StockActivityType.Export: lblBillTitle.Text = "出库单"; break;
            case StockActivityType.Import: lblBillTitle.Text = "入库单"; break;
        }
        //单据id,为空则是新建
        string paramId = Request["Id"];
        if (string.IsNullOrEmpty(paramId))
        {
            isNew = true;
            billStock = new BillStock();
        }
        else
        {
            isNew = false;
            billStock = (BillStock)bizBill.GetOne(new Guid(paramId));
            if (billStock == null)
            {
                throw new Exception("没有找到对应的单据,可能是传入参数有误");
            }
        }
        if (!IsPostBack)
        {
            LoadForm();
        }
    }
    private void LoadForm()
    {
        tbxBillNo.Text = billStock.BillNo;
        tbxMemo.Text = billStock.Memo;
        lblCreator.Text = billStock.CreateMember.RealName;
        tbxReason.Text = billStock.Reason;
        rpt.DataSource = billStock.Detail;
        rpt.DataBind(); 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
    private void CreateBill(BillBase bill)
    {
        List<ProductStock> stock = new List<ProductStock>();
        foreach (RepeaterItem item in rpt.Items)
        {
            
                ps = new ProductStock();
        }
    }
}