﻿<%@ Page Title="" Language="C#" MasterPageFile="~/site_leftmenu.master" AutoEventWireup="true"
    CodeFile="upgrade.aspx.cs" Inherits="upgrade" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" runat="Server">
    <h3>
        2013.11.26</h3>
    <ul>
       
        <li>增加短编码.规则为产品所属大类(2位)+流水码(5位)</li>
        <li>保留供应商原始型号.</li>
        <li>展厅管理预览版.</li>
        
    </ul> 
   
    
   <h3>
        2013.10.21 产品集功能改进</h3>
    <ul>
        <li>导出的Excel中包含产品图片.</li>
        <li>选择的产品数量不再有限制.</li>
        
    </ul> 
   
    <h3>
        2013.10.09</h3>
    <ul>
        <li>实现产品信息中心和ERP产品库半自动同步,产品详情页面可以查看同步状态.</li>
        <li>供应商编码如果不足五位,则自动补齐.</li>
    </ul> 
      <h3>
        2013.08.28</h3>
    <ul>
        <li>搜索界面: 增加 产品分类 下拉菜单,替换原来的分类编码输入框</li>
        <li>供应商增加"别名"属性.</li>
        <li>增加 升级日志. 本次更新的主要内容会显示在页面顶部,关闭之后不会再提示. 页面底部增加 升级日志 链接,可以查看历史更新记录.</li>
    </ul> 
    <h3>
        2013.08.21
    </h3>
    <ul>
        <li>修改产品信息语种判断规则:名称,参数,描述中包含中文字符 即是中文版信息,否则是英文 </li>
    </ul>
</asp:Content>
