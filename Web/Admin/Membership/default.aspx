<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SysAdmin.master" AutoEventWireup="true"
    CodeFile="default.aspx.cs" Inherits="Admin_Membership_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" runat="Server">
    用户列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="search">
    </div>
    <asp:Repeater runat="server" ID="rptUserList">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <td>
                            用户名
                        </td>
                        <td>
                        </td>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                   <%#Eval("UserName") %>
                </td>
                <td>
                
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
    <uc:AspNetPager runat="server" ID="pagerUserList">
    </uc:AspNetPager>
</asp:Content>
