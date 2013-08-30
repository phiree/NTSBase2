<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="ImportStockData.aspx.cs" Inherits="Stock_ImportStockData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:FileUpload runat="server" ID="fuExcel" />  <asp:Button ID="btnImport" runat="server" Text="导入"  OnClick="btnImport_Click"/>
</asp:Content>

