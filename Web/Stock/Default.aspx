<%@ Page Title="" Language="C#" MasterPageFile="~/site_showroom.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Stock_StockList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" runat="Server">
    <div id="dvSearchArea">
    </div>
    <asp:Repeater runat="server" ID="rpt">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>
                          名称
                    </td>
                    <td>
                      NTS编码
                    </td>
                    <td>
                        库存
                    </td>
                    <td>
                        位置
                    </td>
                    <td>
                        最后更新
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Product.Name") %>
                </td>
                <td>
                    <%#Eval("Product.NTSCode") %>
                </td>
                <td>
                    <%#Eval("Stock") %>
                </td>
                <td>
                    <%#Eval("Location") %>
                </td>
                <td>
                    <%#Eval("UpdateTime")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
