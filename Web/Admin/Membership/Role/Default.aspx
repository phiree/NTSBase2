<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/empty.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Admin_Membership_Role_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <legend>角色列表</legend>
        <asp:GridView ID="gvRole" runat="server" DataSourceID="ObjectDataSource1" 
            AutoGenerateColumns="False" AllowPaging="True" CssClass="style1" 
            Height="279px">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    SortExpression="Description" />
            </Columns>
            <EmptyDataTemplate>
            
           
            </EmptyDataTemplate>
        </asp:GridView>
    </fieldset>
    <fieldset>
        <legend>增加角色</legend>
        <div>
       <span>角色名</span>     <asp:TextBox ID="tbxRoleName" runat="server"></asp:TextBox>
                <asp:Button ID="btnAddRole" OnClick="btnAddRole_Click" runat="server" Text="保存" />
        </div>
    </fieldset>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    DataObjectTypeName="NModel.Role" DeleteMethod="Delete" InsertMethod="Save" 
    SelectMethod="GetAll" TypeName="NBiz.BizRole" UpdateMethod="SaveOrUpdate"></asp:ObjectDataSource>
</asp:Content>
