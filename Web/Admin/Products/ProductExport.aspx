<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="ProductExport.aspx.cs" Inherits="Admin_Products_ProductExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" runat="Server">
    导出所有产品的英文资料
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <legend>英文产品资料</legend>
        <div>
            导出<asp:TextBox runat="server" ID="tbxBeginDate"></asp:TextBox>之后的产品
            <uc:ButtonExt runat="server" ID="btnExportExcel" Text="导出Excel" OnClick="btnExportExcel_Click" />
            <uc:ButtonExt runat="server" ID="btnExportImage" Text="导出图片" OnClick="btnExportImage_Click" />
        </div>
    </fieldset>
    <fieldset>
        <legend>没有图片的产品</legend>
        <div>
            <uc:ButtonExt runat="server" ID="btnExport_NoImage" Text="导出Excel" OnClick="btnExport_NoImage_Click" />
        </div>
    </fieldset>
      <fieldset>
        <legend>根据nts代码导出</legend>
        <div>
           每个代码一行.<br />
            <asp:TextBox runat="server" TextMode="MultiLine" ID="tbxCodeList"></asp:TextBox>
        </div>
        <div>
            <uc:ButtonExt runat="server" ID="btnExportCodeListExcel" Text="导出Excel" OnClick="btnExportCodeListExcel_Click" />
            <uc:ButtonExt runat="server" ID="btnExportCodeListImage" Text="导出图片" OnClick="btnExportCodeListImage_Click" />
        </div>
    </fieldset>
    <fieldset>
        <legend>导出自定义产品</legend>
        <div>
            导出Excel的文件名:<asp:TextBox runat="server" ID="tbxExportName"></asp:TextBox>
            需要导出的数据列表(格式:供应商名称(代码)---型号):
            <asp:TextBox runat="server" TextMode="MultiLine" ID="tbxPs"></asp:TextBox>
        </div>
        <div>
            <uc:ButtonExt runat="server" ID="btnCustomListExcel" Text="导出Excel" OnClick="btnCustomListExcel_Click" />
            <uc:ButtonExt runat="server" ID="btnCustomListImage" Text="导出图片" OnClick="btnCustomListImage_Click" />
        </div>
    </fieldset>

     <fieldset>
        <legend>导出特定供应商的产品</legend>
        <div>
            导出Excel的文件名:<asp:TextBox runat="server" ID="tbxExportName_Supplier"></asp:TextBox>
            供应商列表(格式:供应商名称):
            <asp:TextBox runat="server" TextMode="MultiLine" ID="tbxSupplierNames"></asp:TextBox>
            <asp:CheckBox runat="server" ID="cbxWithImage"  Checked="true"/>
        </div>
        <div>
            <uc:ButtonExt runat="server" ID="btnSupplierExportExcel" Text="导出Excel" OnClick="btnSupplierExportExcel_Click" />
            <uc:ButtonExt runat="server" ID="btnSupplierExportImage" Text="导出图片" OnClick="btnSupplierExportImage_Click" />
        </div>
    </fieldset>

    <asp:Label runat="server" CssClass="info" ID="lblMsg"></asp:Label>
</asp:Content>
