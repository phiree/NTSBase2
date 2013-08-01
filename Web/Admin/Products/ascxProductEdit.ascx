<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ascxProductEdit.ascx.cs"
    Inherits="Admin_Products_ascxProductEdit" %>
<!--各语言版本信息-->
<link href="/Content/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
    $(function () {
        $("#tab-lang").tabs();
    });
</script>
<div id="dvProductEditor">
    <div id="tab-lang">
        <asp:Repeater runat="server" ID="rptLang">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li><a href="#<%#Container.DataItem.ToString() %>">
                    <%#Container.DataItem.ToString() %></a></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptProductLanguages" runat="server">
            <ItemTemplate>
                <div id='<%#Eval("language")%>'>
                    <table>
                        <thead>
                        </thead>
                        <tbody>
                            <tr>
                                <th>
                                    名称
                                </th>
                                <td>
                                    <asp:TextBox runat="server" Text='<%#Eval("Name") %>' ID="tbxName"></asp:TextBox>
                                    <asp:HiddenField runat="server" ID="hiddenLanguageId" Value='<%#Eval("Id") %>' />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    单位
                                </th>
                                <td>
                                    <asp:TextBox runat="server" ID="tbxUnit"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    规格参数
                                </th>
                                <td>
                                    <asp:TextBox runat="server" ID="tbxParameters"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    产地
                                </th>
                                <td>
                                    <asp:TextBox runat="server" ID="tbxOriginal"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    交货地
                                </th>
                                <td>
                                    <asp:TextBox runat="server" ID="tbxDelivery"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    产品描述
                                </th>
                                <td>
                                    <asp:TextBox runat="server" ID="tbxDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    备注
                                </th>
                                <td>
                                    <asp:TextBox runat="server" ID="tbxMemo"></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <table>
        <thead>
        </thead>
        <tbody>
            <tr>
                <th>
                    NTS编码
                </th>
                <td>
                    <asp:Label runat="server" ID="lblNtsCode"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    供应商
                </th>
                <td>
                        <asp:Label runat="server" ID="lblSupplierName"></asp:Label>
           
                </td>
            </tr>
            <tr>
                <th>
                    产品型号
                </th>
                <td>
                    <asp:TextBox runat="server" ID="tbxModelNumber"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    分类编码
                </th>
                <td>
                    <asp:TextBox runat="server" ID="TextBox7"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    出厂价
                </th>
                <td>
                    <asp:TextBox runat="server" ID="TextBox8"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    币别
                </th>
                <td>
                    <asp:TextBox runat="server" ID="TextBox9"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    税率
                </th>
                <td>
                    <asp:TextBox runat="server" ID="TextBox10"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    最小起订量
                </th>
                <td>
                    <asp:TextBox runat="server" ID="TextBox11"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    生产周期
                </th>
                <td>
                    <asp:TextBox runat="server" ID="TextBox12"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Repeater runat="server" ID="rptImgList">
                    </asp:Repeater>
                </td>
            </tr>
        </tbody>
    </table>
</div>
