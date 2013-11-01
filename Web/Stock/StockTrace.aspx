<%@ Page Title="" Language="C#" MasterPageFile="~/site_showroom.master" AutoEventWireup="true" CodeFile="StockTrace.aspx.cs" Inherits="Stock_StockTrace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>产品库存轨迹</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" Runat="Server">
<asp:GridView runat="server" ID="gv"></asp:GridView>
</asp:Content>

