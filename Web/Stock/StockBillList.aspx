<%@ Page Title="" Language="C#" MasterPageFile="~/site_showroom.master" AutoEventWireup="true" CodeFile="StockBillList.aspx.cs" Inherits="Stock_StockBillList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" Runat="Server">
<div id="dvSearchArea">
    </div>
    <asp:Repeater runat="server" ID="rpt">
        <HeaderTemplate>
            <table>
                <tr>
                   
                    <td>
                      单号
                    </td>
                    <td>
                        创建人
                    </td>
                    <td>
                        总金额
                    </td>
                    <td>
                        单据状态
                    </td>
                    <td>
                        原因
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                   <a href='stockaddedit.aspx?type=<%#Convert.ToInt32(Eval("StockActivityType")) %>&id=<%#Eval("id") %>'><%#Eval("BillNo") %></a> 
                </td>
                <td>
                    <%#Eval("CreateMember.Name")%>
                </td>
                <td>
                     <%#Eval("TotalAmount")%>
                </td>
                <td>
                    <%#Eval("BillState") %>
                </td>
                <td>
                    <%#Eval("Reason")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
    <UC:AspNetPager runat="server" ID="pager" UrlPaging="true" CssClass="paginator" CustomInfoHTML="总计:&lt;b&gt;%RecordCount%&lt;/b&gt;"
        EnableTheming="True" ShowCustomInfoSection="Left" ShowNavigationToolTip="True"
        CustomInfoSectionWidth="" FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页"
        PrevPageText="上一页" AlwaysShow="True" AlwaysShowFirstLastPageNumber="True">
    </UC:AspNetPager>
</asp:Content>

