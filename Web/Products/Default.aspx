<%@ Page Title="" Language="C#" MasterPageFile="~/site_leftmenu.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Default.aspx.cs" Inherits="Products_Default" %>

<%@ Register Src="~/Products/ascxProductList.ascx" TagName="ProList" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/Scripts/InlineTip.js" type="text/javascript"></script>
    <script src="/Scripts/Service/ProductCollectionService.js" type="text/javascript"></script>
    <script src="/Scripts/pages/products_default.js" type="text/javascript"></script>
    <link href="/Content/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/Content/themes/base/minified/jquery.ui.autocomplete.min.css" rel="stylesheet"
        type="text/css" />
    <link href="/Content/css/productdefault.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        var ProductIdListIndefaultCollection="<%=ProductIdListIndefaultCollection%>";
        var tip = "输入 名称 规格参数 描述备注,用空格隔开";
        $(function () {

            var initValue = $("#<%=tbxName.ClientID%>").val();
            if (initValue == "") {
                $("#<%=tbxName.ClientID%>").InlineTip({ "tip": tip });
            }
            $("#<%=btnSearch.ClientID%>").click(
            function () {
                var that = this;
                var keyword = $("#<%=tbxName.ClientID%>").val();
                if (keyword == "" || keyword == tip) {
                    $("#<%=tbxName.ClientID%>").val("");
                }
            }
            );

            //类别
            $("#<%=ddlCate.ClientID%>").change(function (e) {
                var filteredValue = $(this).find(":selected");

                $.get("/services/CategoryList.ashx?parentCode=" + filteredValue[0].value
            , function (data) {
                $('#<%=ddlCateChild.ClientID%>').find('option')
                                                .remove()
                                                .end()
                                                .append('<option value="-1">全部</option>')
                // .val('-1')
                                                ;
                $.each(data, function (key, value) {
                    $('#<%=ddlCateChild.ClientID%>')
         .append($("<option></option>")
         .attr("value", value.Code)
         .text(value.Name));
                });
            });
                //alert(data);
            });
            $('#<%=ddlCateChild.ClientID%>').change(function (e) {
                $('#<%=hiCateChildValue.ClientID%>').val($(this).find(":selected")[0].value);
            });


        });
  
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" runat="Server">
    <fieldset>
        <legend>搜索</legend>
        <div>
            <span>关 键 字:</span>
            <asp:TextBox CssClass="text" Width="380" runat="server" ID="tbxName"></asp:TextBox>
        </div>
        <div>
            <span>NTS编码:</span>
            <asp:TextBox CssClass="text" Width="150" runat="server" ID="tbxNTSCode"></asp:TextBox>
            <span>分类:</span>
            <asp:TextBox Visible="false" CssClass="text" Width="150" runat="server" ID="tbxCode"></asp:TextBox>
            <asp:DropDownList runat="server" Width="100" ID="ddlCate" AutoPostBack="false" DataTextField="Name"
                DataValueField="Code" OnSelectedIndexChanged="ddlCate_SelectedChanged">
            </asp:DropDownList>
            <asp:DropDownList runat="server" Width="80" DataTextField="Name" DataValueField="Code"
                ID="ddlCateChild">
            </asp:DropDownList>
            <asp:HiddenField ID="hiCateChildValue" runat="server" />
       
            <span>产地:</span>
            <asp:TextBox CssClass="text" Width="80" runat="server" ID="tbxOriginal"></asp:TextBox>
            <span>发货地:</span>
            <asp:TextBox CssClass="text" Width="80" runat="server" ID="tbxDelivery"></asp:TextBox>
        </div>
      
        <div>
            <span>供应商名:</span>
            <asp:TextBox CssClass="text" Width="150" runat="server" ID="tbxSupplierName"></asp:TextBox>
            <span>产品型号:</span><asp:TextBox CssClass="text" Width="150" runat="server" ID="tbxModel"></asp:TextBox>
            <span>产品图片:</span>
            <asp:DropDownList runat="server" ID="ddlHasPhoto">
                <asp:ListItem Selected="True" Value="all">不限</asp:ListItem>
                <asp:ListItem Value="yes">有图</asp:ListItem>
                <asp:ListItem Value="no">无图</asp:ListItem>
            </asp:DropDownList>
            <span>图片质量:</span>
            <asp:DropDownList runat="server" ID="ddlImageQuanlity">
                <asp:ListItem Selected="True" Value="">不限</asp:ListItem>
                <asp:ListItem Value="a">A</asp:ListItem>
                <asp:ListItem Value="b">B</asp:ListItem>
            </asp:DropDownList>
            <UC:ButtonExt runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="搜索" /></div>
    </fieldset>
    <UC:AspNetPager runat="server" ID="AspNetPager1" CloneFrom="pager">
    </UC:AspNetPager>
    <asp:GridView AutoGenerateColumns="false" RowStyle-BorderWidth="1" RowStyle-BorderColor="#cccccc"
        runat="server" ID="dgProduct" OnRowDataBound="dgProduct_RowDataBound" RowStyle-Height="60">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <label for="cbxSelAll">
                        全选</label><input type="checkbox"  style="display:none" id="cbxSelAll" />
                </HeaderTemplate>
                <ItemTemplate>
                    <input runat="server" style="height: 30px; width: 30px;" type="checkbox" class="cbxp" pid='<%#Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="图片">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="rptImages" OnItemDataBound="rptImages_ItemDataBound">
                        <ItemTemplate>
                            <%-- <img style="width:200px" src='/ProductImages/<%# Container.DataItem.ToString()%>'  alt=""/>--%>
                            <!--"/ProductImages/<%# Container.DataItem.ToString()%> "
   "/ImageHandler.ashx?imagename=<%# Container.DataItem.ToString()%>&width=50&height=50&tt=2" 
   "/ProductImages/thumbnails/1742381668_100-100.JPG"
   -->
                            <a href='/ProductImages/original/<%# Eval("ImageName")%>' title="点击查看原图" target="_blank">
                                <img src='/ImageHandler.ashx?imagename=<%#Server.UrlEncode(Eval("ImageName").ToString())%>&width=50&height=50&tt=2' />
                            </a>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Image runat="server" ID="imgNoPic" Visible="false" />
                        </FooterTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="名称" DataTextField="Name" Target="_blank" DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="/products/productdetail.aspx?id={0}" />
            <asp:BoundField HeaderText="型号" DataField="ModelNumber" />
            <asp:BoundField HeaderText="NTS编码" DataField="NTSCode" />
            <asp:BoundField HeaderText="出厂价" DataField="PriceOfFactory" />
            <asp:BoundField HeaderText="币别" DataField="MoneyType" />
            <asp:BoundField HeaderText="供应商代码" HeaderStyle-Wrap="false" DataField="SupplierCode" />
            <asp:TemplateField HeaderText="供应商名称">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="liSupplierName"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="/admin/products/productedit.aspx?id={0}"
              />
        </Columns>
        <EmptyDataTemplate>
            <div class="notice">
                没有相关信息
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
    <UC:AspNetPager runat="server" ID="pager" UrlPaging="true" CssClass="paginator" CustomInfoHTML="总计:&lt;b&gt;%RecordCount%&lt;/b&gt;"
        EnableTheming="True" ShowCustomInfoSection="Left" ShowNavigationToolTip="True"
        CustomInfoSectionWidth="" FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页"
        PrevPageText="上一页" AlwaysShow="True" AlwaysShowFirstLastPageNumber="True">
    </UC:AspNetPager>
</asp:Content>
