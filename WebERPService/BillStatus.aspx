<%@ Page 
 ViewStateMode="Disabled"
 MasterPageFile="~/m.master" AutoEventWireup="true" CodeFile="BillStatus.aspx.cs" Inherits="BillProcesing" %>
<%@ OutputCache Duration="60" VaryByParam="type"  %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<meta http-equiv="X-UA-Compatible" content="IE=10; IE=9; IE=8; IE=7; IE=EDGE" />
<style>
thead {
  
    background-color:white;
}
</style>
<title>ERP整体流程表</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<span>数据查询时间：<%=DateTime.Now%></span>
<a href="BillStatus.aspx?type=1">单据流转情况--业务</a>
<a href="BillStatus.aspx?type=3">单据流转情况--财务</a>
<a href="BillStatus.aspx?type=2">单据审核情况</a>
<a href="BillStatus.aspx?type=4">存货核算参考数据</a>
<asp:GridView runat="server" ID="gv" AutoGenerateColumns="true"  RowStyle-Wrap="false">

</asp:GridView>
<script>
    $('table').floatThead()
</script>
</asp:Content>


