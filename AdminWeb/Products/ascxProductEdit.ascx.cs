using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBiz;
using NModel;

public partial class Admin_Products_ascxProductEdit : System.Web.UI.UserControl
{
    public Product CurrentProduct { get; set; }
    BizProduct bizProduct = new BizProduct();
    BizSupplier bizSupplier = new BizSupplier();
    BizCategory bizCate = new BizCategory();
    private bool isNew = false;
    private string paramId = string.Empty;
    private Guid productId;
    protected void Page_Load(object sender, EventArgs e)
    {
        paramId = Request["id"];
        if (Guid.TryParse(paramId, out productId))
        {

            CurrentProduct = bizProduct.GetOne(productId);
        }
        else
        {
            isNew = true;
            CurrentProduct = new Product();
        }

        if (!IsPostBack)
        {
            if (!isNew)
            {

                InitLoad();
            }
        }
    }
    private void InitLoad()
    {
        LoadForm();
    }
    BLLBase<ProductLanguage> bizPL = new BLLBase<ProductLanguage>(); 
    private void UpdateForm()
    {
        string modelNumber = tbxModelNumber.Text;
        string moneyType = tbxMoneyType.Text;
        CurrentProduct.ModelNumber = tbxModelNumber.Text;
        CurrentProduct.LastUpdateTime = DateTime.Now;
        CurrentProduct.MoneyType = tbxMoneyType.Text;
        CurrentProduct.PriceOfFactory = tbxPrice.Text;

        CurrentProduct.ProductionCycle = decimal.Parse(tbxProductCycle.Text);
        CurrentProduct.TaxRate = decimal.Parse(tbxTax.Text);
        if (CurrentProduct.SyncState == NModel.Enums.SyncState.Synced)
        {
            CurrentProduct.SyncState = NModel.Enums.SyncState.Modified;
        }
        UpdateList();
    }
    private void UpdateList()
    {
        //update multilanguage
        foreach (RepeaterItem item in rptProductLanguages.Items)
        {
            HiddenField hdLanguage = item.FindControl("hiddenLanguageId") as HiddenField;
            string hiddenLanguageId = hdLanguage.Value;
            ProductLanguage pl = bizPL.GetOne(new Guid(hiddenLanguageId));

            pl.Memo = ((TextBox)item.FindControl("tbxMemo")).Text;
            pl.Name = ((TextBox)item.FindControl("tbxName")).Text;
            pl.PlaceOfDelivery = ((TextBox)item.FindControl("tbxDelivery")).Text;
            pl.PlaceOfOrigin = ((TextBox)item.FindControl("tbxOriginal")).Text;
            pl.ProductDescription = ((TextBox)item.FindControl("tbxDescription")).Text;
            pl.ProductParameters = ((TextBox)item.FindControl("tbxParameters")).Text;
            pl.Unit = ((TextBox)item.FindControl("tbxUnit")).Text;
            bizPL.SaveOrUpdate(pl);

        }
    }
  
    private void LoadForm()
    {
        lblNtsCode.Text = CurrentProduct.NTSCode;
        Supplier s = bizSupplier.GetByCode(CurrentProduct.SupplierCode);
        if (s != null)
        {
            lblSupplierName.Text = string.Format("({2}){0} {1} ", s.Name, s.EnglishName, s.Code);
        }
        tbxModelNumber.Text = CurrentProduct.ModelNumber;
        lblCategoryCode.Text = bizCate.GetCateName(CurrentProduct.CategoryCode);
        tbxMoneyType.Text = CurrentProduct.MoneyType;
        tbxMinOrder.Text = CurrentProduct.OrderAmountMin.ToString();
        tbxPrice.Text = CurrentProduct.PriceOfFactory.ToString();
        tbxProductCycle.Text = CurrentProduct.ProductionCycle.ToString();
        tbxTax.Text = CurrentProduct.TaxRate.ToString();
        rptProductLanguages.DataSource = CurrentProduct.ProductMultiLangues;
        rptProductLanguages.DataBind();


    }

    public void Save()
    {
        UpdateForm();
        bizProduct.SaveOrUpdate(CurrentProduct);
        if (isNew)
        {
            NLibrary.Notification.Show(this.Page, "", "保存成功",
                "/admin/product/productedit.aspx?id=" + CurrentProduct.Id);

        }
        else
        {
            NLibrary.Notification.Show(this.Page, "", "保存成功", "");
        }
    }
}