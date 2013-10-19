<%@ Page Title="" Language="C#" MasterPageFile="~/site_leftmenu.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ProductCollection_Default" %>
<%@ Register Src="~/Products/ascxProductList.ascx" TagName="ProList" TagPrefix="UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" Runat="Server">
  <UC:ProList runat="server" id="ucProList">
    </UC:ProList>
    <div>
        <div>
            <asp:Button runat="server" ID="btnExport" OnClick="btnExport_Click" Text="导出Excel文件" />
        </div>
    </div>
</asp:Content>

