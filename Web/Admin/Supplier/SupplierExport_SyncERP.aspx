<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="SupplierExport_SyncERP.aspx.cs" Inherits="Admin_Supplier_SupplierExport_SyncERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" Runat="Server">
供应商数据导出, 供ERP导入.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<asp:Button runat="server" ID="btnExport" OnClick="btnExport_Click" Text="导出" /></div>

<div><asp:Label   CssClass="clearfix success" runat="server" ID="lblResult"></asp:Label></div>
</asp:Content>

