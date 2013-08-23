<%@ Page Title="" Language="C#" MasterPageFile="~/site_leftmenu.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="Products_ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" Runat="Server">
 <asp:DetailsView  ID="dv" AutoGenerateRows="false" runat="server" 
        OnDataBound="dv_DataBound" OnItemCreated="dv_ItemCreated" 
        onload="dv_Load"   >
 <Fields>
 <asp:BoundField  HeaderStyle-Wrap="false"  ItemStyle-Font-Size="Medium"  ItemStyle-Font-Bold="true"  HtmlEncode="false"  HeaderText="名称" DataField="Name"/>
 <asp:TemplateField >
 <ItemTemplate>
 <!--<input type="button" id="btnAddToCart" value="加入选单" pid='<%#Eval("id") %>' /> -->
 </ItemTemplate>
 </asp:TemplateField>
<asp:BoundField  HeaderStyle-Wrap="false"  HeaderText="型号" DataField="ModelNumber"/>
 <asp:BoundField  HeaderStyle-Wrap="false" ItemStyle-Font-Bold="true"  HeaderText="出厂价" DataField="PriceOfFactory"/>
 <asp:BoundField  HeaderStyle-Wrap="false" ItemStyle-Font-Bold="true"  HeaderText="币别" DataField="MoneyType"/>
 <asp:BoundField  HeaderStyle-Wrap="false" ItemStyle-Font-Bold="true"  HeaderText="报价有效期" DataField="PriceValidPeriod"/>

<asp:BoundField   HeaderStyle-Wrap="false"  HeaderText="NTS编码" DataField="NTSCode"/>
<asp:BoundField   HeaderStyle-Wrap="false"  HeaderText="分类编码" DataField="CategoryCode"/> 
<asp:TemplateField HeaderStyle-Wrap="false"  HeaderText="供应商">
<ItemTemplate>
<asp:Label runat="server" ID="lblSupplierName"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField   HeaderStyle-Wrap="false"  HeaderText="税率" DataField="TaxRate"/>
<asp:BoundField   HeaderStyle-Wrap="false"  HeaderText="起定量" DataField="OrderAmountMin"/>
<asp:BoundField   HeaderStyle-Wrap="false"  HeaderText="生产周期" DataField="ProductionCycle"/>
<asp:BoundField  HeaderStyle-Wrap="false"   HeaderText="最后修改日期" DataField="LastUpdateTime"/>
<asp:BoundField  HeaderStyle-Wrap="false"   HeaderText="单位" DataField="Unit" HtmlEncode="false"/>
<asp:BoundField   HeaderStyle-Wrap="false"  HeaderText="产地" DataField="PlaceOfOrigin" HtmlEncode="false"/>
<asp:BoundField   HeaderStyle-Wrap="false"  HeaderText="发货地" DataField="PlaceOfDelivery" HtmlEncode="false"/>

<asp:BoundField   HeaderStyle-Wrap="false"  HeaderText="规格参数" DataField="ProductParameters" HtmlEncode="false"/>
<asp:BoundField   HeaderStyle-Wrap="false"  HeaderText="产品描述" DataField="ProductDescription" HtmlEncode="false"/>
<asp:BoundField   HeaderStyle-Wrap="false"  HeaderText="图片质量" DataField="ImageState" HtmlEncode="false"/>
<asp:BoundField   HeaderStyle-Wrap="false"  HeaderText="备注" DataField="Memo" HtmlEncode="false"/>

<asp:TemplateField HeaderStyle-Wrap="false"  HeaderText="图片">
  <ItemTemplate>
    <asp:Repeater runat="server" ID="rptImages">
    <ItemTemplate>
   <%-- <img style="width:200px" src='/ProductImages/<%# Container.DataItem.ToString()%>'  alt=""/>--%>
  <!--"/ProductImages/<%# Container.DataItem.ToString()%> "
   "/ImageHandler.ashx?imagename=<%# Container.DataItem.ToString()%>&width=50&height=50&tt=2" 
   "/ProductImages/thumbnails/1742381668_100-100.JPG"
   -->
 <a href='/ProductImages/original/<%# Eval("ImageName")%>' title="点击查看原图"
                                target="_blank">
                                <img src='/ImageHandler.ashx?imagename=<%#Server.UrlEncode(Eval("ImageName").ToString())%>&width=500&height=500&tt=2' />
                            </a>
    </ItemTemplate>
    </asp:Repeater>
  </ItemTemplate>
</asp:TemplateField>

 </Fields>
 </asp:DetailsView>
</asp:Content>

