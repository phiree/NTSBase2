<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="StockAddEdit.aspx.cs" Inherits="Admin_Showroom_StockIn_StockAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script   type="text/javascript">

    $(function () {
        var isNew = <%=isNew.ToString().ToLower() %>;
       $("#tabs").tabs();
        if (isNew) {
             $("#tabs").tabs("disable",1);
        }
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3 id="billTitle">
        <asp:Label runat="server" ID="lblBillTitle"></asp:Label></h3>
    <div id="tabs">
        <ul>
            <li><a href="#billHeader">基本信息</a></li>
            <li><a href="#billBody">产品列表</a></li>
        </ul>
   
    <div id="billHeader">
        <div>
            <span>单号:</span><asp:TextBox  Enabled="false" runat="server" ID="tbxBillNo"></asp:TextBox>
            <span>创建人:</span><asp:Label runat="server" ID="lblCreator"></asp:Label>
            <span><%=stockActivityType== NModel.StockActivityType.Export?"出库":"入库"%>类型:</span>
            <asp:DropDownList runat="server" ID="ddlResonType"></asp:DropDownList>

        </div>
        <div>
            <span>备注:</span><asp:TextBox runat="server" ID="tbxMemo" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div>
            <span>从Excel导入</span><asp:FileUpload runat="server" ID="fuExcel" /><asp:Button runat="server"
                ID="btnImport" Text="导入" />
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
                        <asp:TextBox runat="server"  Value='<%#Eval("Location")%>' ID="tbxPositionCode"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server"   Value='<%#Eval("Stock")%>' ID="tbxQuantity"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server"   Value='<%#Eval("Price_Import")%>' ID="tbxImportPrice"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server"  Value='<%#Eval("Price_Display")%>'  ID="tbxDisplayPrice"></asp:TextBox>
                    </td>
                    <td>
                        <%#Eval("Product.SupplierCode") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table></FooterTemplate>
        </asp:Repeater>

        <div id="dvAddProduct" runat="server">
        Nts编码:<asp:TextBox runat="server" ID="tbxNtsCode"></asp:TextBox>
        库位号:<asp:TextBox runat="server" ID="tbxLocation"></asp:TextBox>
         展示价格:<asp:TextBox runat="server" ID="tbxDisplayPrice"></asp:TextBox>
         入库价格:<asp:TextBox runat="server" ID="tbxImportPrice"></asp:TextBox>
        数量:<asp:TextBox runat="server" ID="tbxQuantity"></asp:TextBox>
        
        <asp:Button runat="server" ID="btnAddProduct" OnClick="btnAddProduct_Click" Text="增加" />
        </div>
    </div>
     </div>
    <div>
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" />
                <asp:Button runat="server" ID="btnApplyCheck" Text="提交审核" OnClick="btnApplyCheck_Click" />

    </div>
</asp:Content>
