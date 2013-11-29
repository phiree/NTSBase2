<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="ProductExport.aspx.cs" Inherits="Admin_Products_ProductExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" runat="Server">
    产品导出
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
            <asp:CheckBox runat="server" ID="cbxNeedInertImage_NTSCode" Text="Excel包含图片" Checked="true" />
            <uc:ButtonExt runat="server" ID="btnExportCodeListExcel" Text="导出Excel" OnClick="btnExportCodeListExcel_Click" />
            <uc:ButtonExt runat="server" ID="btnExportCodeListImage" Text="导出图片" OnClick="btnExportCodeListImage_Click" />
        </div>
    </fieldset>
    <fieldset>
        <legend>导出自定义产品</legend>
        <div>
            需要导出的数据列表(格式:供应商代码---型号):<br />
            <asp:TextBox runat="server" TextMode="MultiLine" ID="tbxPs"></asp:TextBox>
        </div>
        <div>
                    <asp:CheckBox runat="server" ID="cbxNeedInertImage_CustomList" Text="Excel包含图片" Checked="true" />

            <uc:ButtonExt runat="server" ID="btnCustomListExcel" Text="导出Excel" OnClick="btnCustomListExcel_Click" />
            <uc:ButtonExt runat="server" ID="btnCustomListImage" Text="导出图片" OnClick="btnCustomListImage_Click" />
        </div>
    </fieldset>

     <fieldset>
        <legend>导出特定供应商的产品</legend>
        <div>
            供应商代码列表,每行一个供应商代码.<br />
        
            <asp:TextBox runat="server" TextMode="MultiLine" ID="tbxSupplierNames"></asp:TextBox>
        </div>
        <div>
              <asp:CheckBox runat="server" ID="cbxNeedInertImage_Supplier" Text="Excel包含图片" Checked="true" />

            <uc:ButtonExt runat="server" ID="btnSupplierExportExcel" Text="导出Excel" OnClick="btnSupplierExportExcel_Click" />
            <uc:ButtonExt runat="server" ID="btnSupplierExportImage" Text="导出图片" OnClick="btnSupplierExportImage_Click" />
        </div>
    </fieldset>

    <asp:Label runat="server" CssClass="info" ID="lblMsg"></asp:Label>
</asp:Content>
