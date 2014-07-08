<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ascxProductEdit.ascx.cs"
    Inherits="Admin_Products_ascxProductEdit" %>
<!--各语言版本信息-->
<script src="/Scripts/jquery.validate.min.js" type="text/javascript"></script>
<script src="/Scripts/pages/ascxProductEdit.js" type="text/javascript"></script>
<script src="/Scripts/jquery.maskedinput.min.js" type="text/javascript"></script>
<link href="/Content/css/pages/ascxProductEdit.css" rel="stylesheet" type="text/css" />
<link href="/Content/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
<style>
    textarea.formError, input.formError
    {
        border: 1px solid red;
        background-color: #FFFFD5;
    }
    #dvError
    {
        display: none;
    }
    textarea
    {
        width: 310px;
        height: 100px;
    }
    input[type=text]
    {
        width: 310px;
    }
</style>
<script language="javascript" type="text/javascript">
    $(function () {
        //  $("#tab-lang").tabs();
        $(".dvLanguage table").each(function (e) {

            if (e > 0) {
                $(this).find("tbody tr th").remove();
            }
        });
        // $(".dvLanguage table:last tbody tr th").remove();
    });
</script>
<div id="dvProductEditor">
    <div class="error" id="dvError">
        <span></span>
    </div>
    <asp:Repeater ID="rptProductLanguages" runat="server">
        <ItemTemplate>
            <div class="dvLanguage" id='<%#Eval("language")%>'>
                <table>
                    <thead>
                    </thead>
                    <tbody>
                        <tr>
                            <th>
                                语言
                            </th>
                            <td>
                                <%# Eval("Language") %>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                名称
                            </th>
                            <td>
                                <asp:TextBox CssClass="pName" runat="server" Text='<%#Eval("Name") %>' ID="tbxName"></asp:TextBox>
                                <asp:HiddenField runat="server" ID="hiddenLanguageId" Value='<%#Eval("Id") %>' />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                单位
                            </th>
                            <td>
                                <asp:TextBox runat="server" CssClass="pUnit" Text='<%#Eval("Unit") %>' ID="tbxUnit"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                产地
                            </th>
                            <td>
                                <asp:TextBox runat="server" CssClass="pOriginal" Text='<%#Eval("PlaceOfOrigin") %>'
                                    ID="tbxOriginal"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                交货地
                            </th>
                            <td>
                                <asp:TextBox runat="server" CssClass="pDelivery" Text='<%#Eval("PlaceOfDelivery") %>'
                                    ID="tbxDelivery"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                规格参数
                            </th>
                            <td>
                                <asp:TextBox TextMode="MultiLine" CssClass="pParameters" Text='<%#Eval("ProductParameters") %>'
                                    runat="server" ID="tbxParameters"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                产品描述
                            </th>
                            <td>
                                <asp:TextBox runat="server" CssClass="pDescription" TextMode="MultiLine" Text='<%#Eval("ProductDescription") %>'
                                    ID="tbxDescription"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                备注
                            </th>
                            <td>
                                <asp:TextBox runat="server" CssClass="pMemo" TextMode="MultiLine" Text='<%#Eval("Memo") %>'
                                    ID="tbxMemo"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="clear">
    </div>
    <table style="width: auto">
        <thead>
        </thead>
        <tbody>
            <tr>
                <th>
                    停用
                </th>
                <td>
                    <asp:CheckBox runat="server" ID="cbxDisable" />
                </td>
            </tr>
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
                    分类
                </th>
                <td>
                    <asp:Label runat="server" ID="lblCategoryCode"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    产品型号
                </th>
                <td>
                    <asp:TextBox CssClass="pModelNumber" runat="server" ID="tbxModelNumber"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    出厂价
                </th>
                <td>
                    <asp:TextBox runat="server" CssClass="pPrice" ID="tbxPrice"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    币别
                </th>
                <td>
                    <asp:TextBox runat="server" CssClass="pMoneyType" ID="tbxMoneyType"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    报价有效期
                </th>
                <td>
                    <asp:TextBox runat="server" CssClass="pPriceValidPeriod" ID="tbxPriceValidPeriod"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    税率
                </th>
                <td>
                    <asp:TextBox runat="server" CssClass="pTax" ID="tbxTax"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    最小起订量
                </th>
                <td>
                    <asp:TextBox runat="server" CssClass="pOrderMinAmount" ID="tbxMinOrder"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    生产周期
                </th>
                <td>
                    <asp:TextBox runat="server" CssClass="pProductCycle" ID="tbxProductCycle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <asp:Repeater runat="server" ID="rptImgList" OnItemCommand="rpt_ImgList_Command">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Button runat="server" ID="btnDelete" CommandName='delete' CommandArgument='<%#Eval("Id") %>'
                                            Text="删除" OnClientClick="javascript:return confirm('确定要删除这张图片?')" />
                                    </td>
                                    <td>
                                        <img style="width:500px" src='/productimages/original/<%#Eval("ImageName") %>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <br />
                    <asp:FileUpload runat="server" ID="fu_Pi" /><asp:Button runat="server" ID='btnUpload'
                        OnClick="btnUpload_Click" Text="上传" />
                </td>
            </tr>
            
        </tbody>
    </table>
</div>
