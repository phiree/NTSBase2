<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="ProductEdit.aspx.cs" Inherits="Admin_Products_ProductEdit" %>

<%@ Register src="ascxProductEdit.ascx" tagname="ascxProductEdit" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:ascxProductEdit ID="ascxProductEdit1" runat="server" />
    <div>
    <asp:Button runat="server" ID="btnSave"  Text="保存"  OnClick="btnSave_Click"/>
    </div>
</asp:Content>

