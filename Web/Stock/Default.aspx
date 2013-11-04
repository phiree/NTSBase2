<%@ Page Title="" Language="C#" MasterPageFile="~/site_showroom.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Stock_StockList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/Scripts/InlineTip.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
    var tip="产品名称,nts编码";
    var initValue = $("#<%=tbxKeyword.ClientID%>").val();
            if (initValue == "") {
                $("#<%=tbxKeyword.ClientID%>").InlineTip({ "tip": tip });
            }
});

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" runat="Server">
<div class="dvSearch">
    <span>关键字:</span><asp:TextBox CssClass="text" runat="server" ID="tbxKeyword"></asp:TextBox>
    <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" />
</div>
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
            <a target="_blank" href='StockTrace.aspx?id=<%#Eval("Product.Id") %>'>
            <%#Eval("Product.Name") %></a>  
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
