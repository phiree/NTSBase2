<%@ Page Title="" Language="C#" MasterPageFile="~/site_showroom.master" AutoEventWireup="true"
    CodeFile="StockTrace.aspx.cs" Inherits="Stock_StockTrace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>产品库存轨迹</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" runat="Server">
    <asp:Repeater runat="server" ID="gv">
        <HeaderTemplate><table><thead>
        <tr><td>名称</td>
        <td>NTS编码</td>
        <td>数量</td>
        <td>位置</td>
        <td>更改日期</td>
        <td>单号</td>
        </tr>
        </thead></HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td><%#Eval("Product.Name") %></td>
        <td><%#Eval("Product.NTSCode") %></td>
       
        <td><%#Eval("Stock")%></td>
        <td><%#Eval("Location")%></td>
        <td><%#Eval("Bill.CreatedDate")%></td>
          <td><a href='StockAddEdit.aspx?id=<%#Eval("Bill.Id") %>'><%#Eval("Bill.BillNo")%></a></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
