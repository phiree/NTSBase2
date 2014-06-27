<%@ Page Title="" Language="C#" MasterPageFile="~/site_leftmenu.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="ProductCollection_Default" %>

<%@ Register Src="~/Products/ascxProductList.ascx" TagName="ProList" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" runat="Server">
    <fieldset>
    <legend>产品集合.红色字体:当前集合;**前缀:默认集合.</legend>
    
    <div>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <a style='<%# Request["id"] == Eval("Id").ToString()?"color:red;font-size:big;": "" %>' href='Default.aspx?id=<%# Eval("Id") %>'>
                   <%# (bool)Eval("IsDefault")?"**":"" %> <%# string.IsNullOrEmpty(Eval("CollectionName").ToString()) ? "[无名称]" : Eval("CollectionName")%></a>
            </ItemTemplate>
        </asp:Repeater></div>
        </fieldset>
        <fieldset>
        <legend>创建产品集合</legend>
        <div>
        名称:<asp:TextBox runat="server" ID="tbxNewName"></asp:TextBox>
        <asp:Button Text="创建新集合" OnClick="btnCreateNew_Click" runat="server" ID="btnCreateNew" />
        </div>
    </fieldset>
    <UC:ProList runat="server" id="ucProList">
    </UC:ProList>
    <div>
        <div>
            <asp:Button runat="server" ID="btnClear" OnClick="btnClear_Click" Text="清空" />
            <asp:Button runat="server" ID="btnDelete" OnClick="btnDelete_Click" Text="删除集合" />
            产品集合名称:<asp:TextBox runat="server" ID="tbxCollectionName"></asp:TextBox>
            <asp:Button runat="server" ID="btnSaveName" OnClick="btnSaveName_Click" Text="保存产品集合" />
            <asp:Button runat="server" ID="btnSetDefault" OnClick="btnSetDefault_Click" Text="设置为默认" />
            <asp:Button runat="server" ID="btnExport" OnClick="btnExport_Click" Text="导出Excel文件" />
        </div>
    </div>
    <hr />
    <div>
    说明:
    <ol>
    <li>产品列表选择的产品 会自动添加到 默认集合中</li>
    <li>产品集合数据只保存于本机</li>
    <li>清空浏览器历史记录 亦可能清空集合数据 </li>
    </ol>
    </div>
</asp:Content>
