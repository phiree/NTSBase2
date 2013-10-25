<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="StockAddEdit.aspx.cs" Inherits="Admin_Showroom_StockIn_StockAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3 id="billTitle">
        <asp:Label runat="server" ID="lblBillTitle"></asp:Label></h3>
    <div id="billHeader">
        <div>
            <span>单号:</span><asp:TextBox runat="server" ID="tbxBillNo"></asp:TextBox>
            <span>创建人:</span><asp:Label runat="server" ID="lblCreator"></asp:Label>
            <span>类型:</span><asp:TextBox runat="server" ID="tbxReason"></asp:TextBox>
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
                        <%#Eval("Product.NTSCode") %><asp:HiddenField runat="server" Value='<%#Eval("Product.Id")%>' ID="hiProductId" />
                    </td>
                    <td>
                        <%#Eval("Product.Name") %>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbxPositionCode"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbxQuantity"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbxImportPrice"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbxDisplayPrice"></asp:TextBox>
                    </td>
                    <td>
                        <%#Eval("Product.SupplierCode") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table></FooterTemplate>
        </asp:Repeater>
    </div>
    <div>
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" />
    </div>
</asp:Content>
