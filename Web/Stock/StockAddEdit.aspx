<%@ Page Title="" Language="C#" MasterPageFile="~/site_showroom.master" AutoEventWireup="true"
    CodeFile="StockAddEdit.aspx.cs" Inherits="Admin_Showroom_StockIn_StockAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        ul li
        {
            list-style-type: none;
        }
        textarea
        {
            width: 100%;
            height: auto;
        }
        .panelAdd
        {
            background-color: aliceblue;
            border: 1px solid #999;
        }
        .ui-tabs .ui-state-disabled
        {
            display: none; /* disabled tabs don't show up */
        }
        .txtValue
        {
            width: 50px !important;
        }
        .panelAdd .tbxValue:first
        {
            width: 100px !important;
        }
    </style>
    <script type="text/javascript">

    $(function () {
        var isNew = <%=isNew.ToString().ToLower() %>;
        var cookieName = "djsmetab";
       $("#tabs").tabs({active: $.cookie(cookieName),
                             activate: function (event, ui) {
                            $.cookie(cookieName, ui.newTab.index(), { expires: 365 });
                        }
                        
                        });
        if (isNew) {
             $("#tabs").tabs(
             {"disabled":[1],
               active:0
             });
        }
    });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_maincontent" runat="Server">
    <h3 id="billTitle">
        <asp:Label runat="server" ID="lblBillTitle"></asp:Label></h3>
    <div id="tabs">
        <ul>
            <li><a href="#billHeader">基本信息</a></li>
            <li><a href="#billBody">产品列表</a></li>
        </ul>
        <div id="billHeader">
            <div>
                <span>单号:</span><asp:TextBox CssClass="text" Enabled="false" runat="server" ID="tbxBillNo"></asp:TextBox>
                <span>创建人:</span><asp:Label runat="server" ID="lblCreator"></asp:Label>
                <span>
                    <%=stockActivityType== NModel.StockActivityType.Export?"出库":"入库"%>类型:</span>
                <asp:DropDownList runat="server" ID="ddlResonType">
                </asp:DropDownList>
            </div>
            <div>
                <span>备注:</span><asp:TextBox runat="server" ID="tbxMemo" Rows="2" CssClass="text"
                    TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div id="billBody">
            <asp:Repeater ID="rpt" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <td>
                                    NTS编码
                                </td>
                                <td>
                                    名称
                                </td>
                                <td>
                                    库位号
                                </td>
                                <td>
                                    数量
                                </td>
                                <td>
                                    入库价格
                                </td>
                                <td>
                                    展示价格
                                </td>
                                <td>
                                    供应商
                                </td>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("Product.NTSCode") %><asp:HiddenField runat="server" Value='<%#Eval("Id")%>'
                                ID="hiStockId" />
                        </td>
                        <td>
                            <%#Eval("Product.Name") %>
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass=" text txtValue" Value='<%#Eval("Location")%>'
                                ID="tbxPositionCode"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="txtValue text" Value='<%#Eval("Stock")%>' ID="tbxQuantity"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="txtValue text" Value='<%#Eval("Price_Import")%>'
                                ID="tbxImportPrice"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="txtValue text" Value='<%#Eval("Price_Display")%>'
                                ID="tbxDisplayPrice"></asp:TextBox>
                        </td>
                        <td>
                            <%#Eval("Product.SupplierCode") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table></FooterTemplate>
            </asp:Repeater>
            <div id="dvAddProduct" class="panelAdd" runat="server">
                Nts编码:<asp:TextBox CssClass=".span-4" runat="server" ID="tbxNtsCode"></asp:TextBox>
                库位号:<asp:TextBox CssClass="txtValue text" runat="server" ID="tbxLocation"></asp:TextBox>
                数量:<asp:TextBox CssClass="txtValue text" runat="server" ID="tbxQuantity"></asp:TextBox>
                展示价格:<asp:TextBox CssClass="txtValue text" runat="server" ID="tbxDisplayPrice"></asp:TextBox>
                入库价格:<asp:TextBox CssClass="txtValue text" runat="server" ID="tbxImportPrice"></asp:TextBox>
                <asp:Button runat="server" ID="btnAddProduct" OnClick="btnAddProduct_Click" Text="增加" />
            </div>
        </div>
    </div>
    <div>
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" />
        <asp:Button runat="server" ID="btnApplyCheck" Text="提交审核" OnClick="btnApplyCheck_Click" />
    </div>
</asp:Content>
