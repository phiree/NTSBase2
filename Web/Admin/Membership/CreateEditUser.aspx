<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SysAdmin.master" AutoEventWireup="true" CodeFile="CreateEditUser.aspx.cs" Inherits="Admin_Membership_CreateEditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" RequireEmail="false"></asp:CreateUserWizard>
</asp:Content>

