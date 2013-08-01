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
        CurrentProduct.ModelNumber = tbxModelNumber.Text;
 

        //update multilanguage
        foreach (RepeaterItem item in rptProductLanguages.Items)
        {
            HiddenField hdLanguage = item.FindControl("hiddenLanguageId") as HiddenField;
            string hiddenLanguageId = hdLanguage.Value;
            ProductLanguage pl = bizPL.GetOne(new Guid(hiddenLanguageId));

            pl.Memo = ((TextBox)item.FindControl("tbxMemo")).Text;
            pl.Name = ((TextBox)item.FindControl("tbxName")).Text;
            pl.PlaceOfDelivery = ((TextBox)item.FindControl("tbxDelivery")).Text;
            pl.PlaceOfOrigin= ((TextBox)item.FindControl("tbxOriginal")).Text;
            pl.ProductDescription= ((TextBox)item.FindControl("tbxDescription")).Text;
            pl.ProductParameters= ((TextBox)item.FindControl("tbxParameters")).Text;
            pl.Unit= ((TextBox)item.FindControl("tbxUnit")).Text;
            bizPL.SaveOrUpdate(pl);
            
        }

    }
    
    private void LoadForm()
    {
        lblNtsCode.Text = CurrentProduct.NTSCode;
        rptProductLanguages.DataSource = CurrentProduct.ProductMultiLangues;
        rptProductLanguages.DataBind();

        rptLang.DataSource = CurrentProduct.ProductMultiLangues.Select(x => x.Language);
        rptLang.DataBind();
    }
    public void Save()
    {
        UpdateForm();
        bizProduct.SaveOrUpdate(CurrentProduct);
    }
}