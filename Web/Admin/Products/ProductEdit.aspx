<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="ProductEdit.aspx.cs" Inherits="Admin_Products_ProductEdit" %>

<%@ Register Src="ascxProductEdit.ascx" TagName="ascxProductEdit" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" runat="Server">
    产品编辑
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:ascxProductEdit ID="ascxProductEdit1" runat="server" />
    <div>
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" />
        
        <a target="_blank" href='/products/productdetail.aspx?id=<%=Request["id"] %>'>查看产品页面</a>
    </div>
</asp:Content>
