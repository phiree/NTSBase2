<%@ Page Title="" Language="C#" MasterPageFile="~/site_showroom.master" AutoEventWireup="true"
    CodeFile="InventoryAddEdit.aspx.cs" Inherits="Stock_InventoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" runat="Server">
    <div>
        单号:<asp:TextBox runat="server" ID="tbxBillNo" Enabled="false"></asp:TextBox>
        创建人:<asp:Label runat="server" ID="lblCreator"></asp:Label>
    </div>
    <fieldset style="display:none">
        <legend>手动导入盘点清单</legend>
        <div>
            <span>Excel文件<a href="">(格式)</a></span>
            <asp:FileUpload runat="server" ID="fuExcel" /><asp:Button runat="server" ID="btnUpload"
                Text="生成" />
        </div>
    </fieldset>
    <fieldset style="display:none">
        <legend>自动生成盘点单</legend>
        <div>
            <span>最大数量:</span><asp:TextBox runat="server" ID="tbxAmount"></asp:TextBox>
            范围(输入展区代码,多个展区用逗号隔开)<asp:TextBox runat="server" ID="tbxPositionCodes"></asp:TextBox>
            <asp:Button runat="server" ID="btnRandomCreate" Text="生成" />
        </div>
    </fieldset> <div class="span-10 border last">
        <asp:Repeater runat="server" ID="rptProduct">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            产品代码
                        </td>
                        <td>
                            名称
                        </td>
                        <td>
                            系统库存
                        </td>
                        <td>
                            实际盘点
                        </td>
                        <td></td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Product.NTSCode") %>
                    </td>
                    <td>
                        <%#Eval("Product.Name") %>
                    </td>
                    <td>
                        <%#Eval("StockQuantity") %>
                    </td>
                    <td>
                     <asp:TextBox Width="50px" CssClass="text" runat="server" ID="tbxCheckQuantity"  Text=' <%#Eval("CheckQuantity") %>'></asp:TextBox>
                    </td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
         <asp:Button runat="server"  ID="btnBeginCheck" OnClick="btnBeginCheck_Click" Text="开始盘点"/>
         <asp:Button runat="server"  ID="btnApply" OnClick="btnApply_Click" Text="盘点结束,提交审核"/>
         <asp:Button runat="server"  ID="btnCheck" OnClick="btnCheck_Click" Text="审核通过"/>
    驳回原因:<asp:TextBox runat="server" ID="tbxReason"></asp:TextBox><asp:Button runat="server"  ID="btnRefuse" OnClick="btnRefuse_Click" Text="驳回"/>
    
    </div>
   
    <div class="span-9  last right border">
    <span></span><br />
    <asp:TextBox runat="server" ID="tbxNTSCodeList" Width="200px" Height="298px" TextMode="MultiLine" 
           ></asp:TextBox><br />
    <asp:Button runat="server" ID="btnAddToInventory" OnClick="btnAddToInventory_Click"  Text="加入盘点列表"/>
    <asp:Label runat="server" ID="lblMsg" Visible="false"></asp:Label>
    </div>
   
</asp:Content>
