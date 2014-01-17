<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/empty.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_SyncCenter_Myanmar_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<span class="info">根据ERP系统单号,导出两个excel文件和一个图片文件夹</span>
<span>输入ERP单据号,一行一条:</span><asp:TextBox TextMode=MultiLine runat="server" ID="tbxBillNoList"></asp:TextBox>
<asp:Button runat="server" ID="btnExport" Text="导出" OnClick="btnExport_Click" />
</asp:Content>

