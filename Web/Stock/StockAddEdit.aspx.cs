using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NModel;
using NBiz;
using NLibrary;
public partial class Admin_Showroom_StockIn_StockAddEdit : AuthPage
{

   protected  bool isNew = true;
    BillStock billStock = null;
   public StockActivityType stockActivityType= StockActivityType.Export;
    BizBill bizBill = new BizBill();
    BizProduct bizProduct = new BizProduct();
    BizStock bizStock = new BizStock();
    BizStockBillDetail bizBillDetail = new BizStockBillDetail();
    NTSMembershipProvider bizNtsMember = new NTSMembershipProvider();
    protected override void  OnLoadComplete(EventArgs e)
{
    if (isNew)
    {
        btnApplyCheck.Visible =btnApplyCheck.Visible = false;
    }
    else
         if (billStock.BillState != BillState.草稿)
        {
            dvAddProduct.Visible = btnAddProduct.Visible = btnSave.Visible = btnApplyCheck.Visible = false;
        }
        base.OnPreLoad(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //入库 还是出库
        string paramType = Request["type"];
        if (string.IsNullOrEmpty(paramType))
        {
            throw new Exception("错误.请传入单据类型");
        }
        stockActivityType = (StockActivityType)Enum.Parse(typeof(StockActivityType), paramType);
           
        //单据id,为空则是新建
        string paramId = Request["Id"];
        if (string.IsNullOrEmpty(paramId))
        {
            isNew = true;

           
            billStock = new BillStock(stockActivityType);
            billStock.CreateMember = bizNtsMember.NM_GetUser(CurrentMember.UserName);
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
        switch (billStock.StockActivityType)
        {
            case StockActivityType.Export: lblBillTitle.Text = "出库单"; break;
            case StockActivityType.Import: lblBillTitle.Text = "入库单"; break;
        }

        if (!IsPostBack)
        {
            BindReson();
            LoadForm();
        }
    }
    
    private void BindReson()
    {
        foreach (StockActivityReason r in Enum.GetValues(typeof(StockActivityReason)))
        {
            string enumName = Enum.GetName(typeof(StockActivityReason), r);
            
            if (stockActivityType == StockActivityType.Export)
            {
                if (enumName.StartsWith("IN_"))
                {
                    continue;
                }
            }
            else
            {
                if (enumName.StartsWith("OUT_"))
                {
                    continue;
                }
            }
            ListItem item = new ListItem(Enum.GetName(typeof(StockActivityReason), r), ((int)r).ToString());
            ddlResonType.Items.Add(item);
        }
    }
    private void LoadForm()
    {
        tbxBillNo.Text = billStock.BillNo;
        tbxMemo.Text = billStock.Memo;
        lblCreator.Text = billStock.CreateMember.Name;
        ddlResonType.SelectedValue = ((int)billStock.Reason).ToString();
        rpt.DataSource = billStock.Detail;
        rpt.DataBind(); 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateForm();
        
        bizBill.Save(billStock);
        if (isNew)
        {
            Response.Redirect(Request.RawUrl + "&id=" + billStock.Id, true);
        }
    }

    
    private void UpdateForm()
    {
    
        foreach (RepeaterItem item in rpt.Items)
        {
           NModel.StockBillDetail  ps =
               bizBillDetail.GetOne(new Guid(((HiddenField)item.FindControl("hiStockId")).Value));
             ps.Location = ((TextBox)item.FindControl("tbxPositionCode")).Text;
             ps.Price_Display =Convert.ToDecimal(((TextBox)item.FindControl("tbxDisplayPrice")).Text);
             ps.Price_Import =Convert.ToDecimal( ((TextBox)item.FindControl("tbxImportPrice")).Text);
             ps.Stock = Convert.ToDecimal(((TextBox)item.FindControl("tbxQuantity")).Text);
             ps.UpdateTime = DateTime.Now;
        }
        billStock.BillNo = tbxBillNo.Text;
        billStock.StockActivityType = stockActivityType;
        billStock.CreatedDate = DateTime.Now;
        //billStock.CreateMember = CurrentMember;
        billStock.Memo = tbxMemo.Text;
        billStock.Reason = (StockActivityReason)(Convert.ToInt32(ddlResonType.SelectedValue));
        }
    
    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        UpdateForm();
       string errMsg;
       bizBill.AddStockDetail(billStock, tbxNtsCode.Text, tbxLocation.Text, Convert.ToDecimal(tbxQuantity.Text)
           , Convert.ToDecimal(tbxDisplayPrice.Text), Convert.ToDecimal(tbxImportPrice.Text), out errMsg);
       if (isNew)
       {
           Response.Redirect(Request.RawUrl + "&id=" + billStock.Id, true);
       }
       else
       {
           rpt.DataSource = billStock.Detail;
           rpt.DataBind();
       }
    }
    private void ClearAddPanel() { 
     
    }
    protected void btnApplyCheck_Click(object sender,EventArgs e) {
    //提交审核
        billStock.BillState = BillState.未审核;
        btnSave_Click(sender, e);
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        string errMsg;
        QuantityChangeDirecrion direction;
       bool isValid= bizBill.StockBillStateChange(billStock, BillState.已审核,out errMsg,out direction);
       if (!isValid)
       {
           Notification.Show(this, "错误", errMsg, string.Empty);
       }
           else{
        bizBill.ApplyStockChange(billStock,direction);
        billStock.BillState = BillState.已审核;
        bizBill.Save(billStock);
           }
    }
    protected void btnRefuse_Click(object sender, EventArgs e)
    {
        string errMsg; QuantityChangeDirecrion direction;
        bool isValid = bizBill.StockBillStateChange(billStock, BillState.草稿, out errMsg, out direction);
       if (!isValid)
       {
           Notification.Show(this, "错误", errMsg, string.Empty);
       }
       else
       {
           billStock.Memo += DateTime.Now + "驳回:" + tbxRefuseReason.Text + Environment.NewLine;

           bizBill.ApplyStockChange(billStock, direction);
           billStock.BillState = BillState.草稿;
           bizBill.Save(billStock);
       }
    }
}