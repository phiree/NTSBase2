<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="product_disabled_list.aspx.cs" Inherits="Admin_Products_product_disabled_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView AutoGenerateColumns="false" RowStyle-BorderWidth="1" RowStyle-BorderColor="#cccccc"
        runat="server" ID="dgProduct" RowStyle-Height="60">
        <Columns>
           
            
            <asp:HyperLinkField HeaderText="名称" DataTextField="Name" Target="_blank" DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="/products/productdetail.aspx?id={0}" />
            <asp:BoundField HeaderText="型号" DataField="ModelNumber" />
            <asp:BoundField HeaderText="NTS编码" DataField="NTSCode" />
            <asp:BoundField HeaderText="出厂价" DataField="PriceOfFactory" />
            <asp:BoundField HeaderText="币别" DataField="MoneyType" />
            <asp:BoundField HeaderText="供应商代码" HeaderStyle-Wrap="false" DataField="SupplierCode" />
            <asp:TemplateField HeaderText="供应商名称">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="liSupplierName"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
            
             <a href='/admin/products/productedit.aspx?id=<%#Eval("ID") %>'
             >
             <%=Membership.GetUser()==null?"":"修改" %>
             </a>
            </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
        <EmptyDataTemplate>
            <div class="notice">
                没有相关信息
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>

