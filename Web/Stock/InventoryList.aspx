<%@ Page Title="" Language="C#" MasterPageFile="~/site_showroom.master" AutoEventWireup="true"
    CodeFile="InventoryList.aspx.cs" Inherits="Stock_InventoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" runat="Server">
    <asp:Repeater runat="server" ID="rpt">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>
                        单号
                    </td>
                    <td>
                        盘点时间
                    </td>
                    <td>
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href='InventoryAddEdit.aspx?id=<%#Eval("Id") %>'>
                        <%#Eval("BillNo") %></a>
                </td>
                <td>
                    <%#Eval("CreatedDate") %>
                </td>
                <td>
                    <%#Eval("BillState") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
