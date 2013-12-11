<%@ Page Title="" Language="C#" ViewStateMode="Disabled" MasterPageFile="~/m.master" AutoEventWireup="true" CodeFile="BillStatus.aspx.cs" Inherits="BillProcesing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<a href="BillStatus.aspx?type=1">单据流转情况--业务</a>
<a href="BillStatus.aspx?type=3">单据流转情况--财务</a>
<a href="BillStatus.aspx?type=2">单据审核情况</a>
<asp:GridView runat="server" ID="gv" AutoGenerateColumns="true"  RowStyle-Wrap="false">

</asp:GridView>
</asp:Content>

