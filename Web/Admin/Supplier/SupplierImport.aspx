﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="SupplierImport.aspx.cs" Inherits="Admin_Supplier_SupplierImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>选择供应商列表:</h3>  <p>
       
          <asp:FileUpload runat="server" ID="fuSupplier" />
        <asp:Button runat="server" ID="btnImport" OnClick="btnImport_Click" Text="导入" />
    </p>
    <p>
         <div  runat="server" ID="lblMsg">
    
        </div>
    </p>
</asp:Content>

