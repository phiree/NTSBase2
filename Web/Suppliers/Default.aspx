<%@ Page Title="" Language="C#" MasterPageFile="~/site_leftmenu.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Suppliers_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" runat="Server">
    <div>
        <fieldset>
            <legend>搜索</legend>
            <div>
                <span >供应商名称 或 编码</span>
                <asp:TextBox runat="server" CssClass="text"  Width="400" ID="tbxName"></asp:TextBox><asp:Button runat="server"
                    ID="btnSearch" OnClick="btnSearch_Click"  Text="搜索" />
            </div>
        </fieldset>
    </div>
    <uc:AspNetPager runat="server" ID="AspNetPager1" CloneFrom="pager">
    </uc:AspNetPager>
    <asp:GridView runat="server" ID="dgSupplier"   AutoGenerateColumns="false" OnRowCreated="dg_SupplierRowCreated">
    <Columns>
    
     <asp:TemplateField  HeaderText="中文名称" >
     <ItemTemplate>
     <a href='/products/?sname=<%# Server.UrlEncode(Eval("Name").ToString()) %>'> <%#Eval("Name")%></a>
     </ItemTemplate>
     </asp:TemplateField>
     <asp:BoundField DataField="EnglishName" HeaderText="英文名称" />
     <asp:BoundField DataField="Code" HeaderText="供应商编码" />
     <asp:BoundField DataField="ContactPerson" HeaderText="联系人" />
     <asp:BoundField DataField="Phone" HeaderText="电话" />
     
    </Columns>
        <EmptyDataTemplate>
            <div class="notice">
                没有相关信息
            </div>
        </EmptyDataTemplate>
        </asp:GridView>
        <uc:AspNetPager runat="server" ID="pager" UrlPaging="true" CssClass="paginator" CustomInfoHTML="Total:%RecordCount% Page %CurrentPageIndex% of %PageCount%"
            EnableTheming="True" ShowCustomInfoSection="Left" ShowNavigationToolTip="True">
        </uc:AspNetPager>
</asp:Content>
