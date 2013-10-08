<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="ProductExport_ErpSync.aspx.cs" Inherits="Products_ProductExport_ErpSync" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" Runat="Server">
ERP同步数据导出:为 添加和修改的产品 生成Excel表格,用于ERP产品导入.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Button runat="server" ID="btnExport" OnClick="btnExport_Click" Text="导出" />
<asp:Label CssClass="success" runat="server" ID="lblResult"></asp:Label>
</asp:Content>

