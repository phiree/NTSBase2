<%@ Page Title="" Language="C#" MasterPageFile="~/site_leftmenu.master" AutoEventWireup="true"
    CodeFile="upgrade.aspx.cs" Inherits="upgrade" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cph_maincontent" runat="Server">

<h3>
        2014.6.27</h3>
    <ul>
       
        <li>增强 "产品集合"功能. 增加  新增,删除,清空,修改名称等功能, 允许使用者同时保留多个产品集合.

        <a href="http://p.nts.com:89/productcollection/">http://p.nts.com:89/productcollection/</a>
        </li>
        
    </ul> 
<h3>
        2014.6.13</h3>
    <ul>
       
        <li>搜索条件增加"短编码"(十位数产品编码,目前NTSMyanmar在使用)。

        <a href="http://p.nts.com:89/products/">http://p.nts.com:89/products/</a>
        </li>
        
    </ul> 
      
<h3>
        2014.4.25</h3>
    <ul>
       
        <li>增加过期产品显示。 搜索条件增加 过期时间；过期产品背景设置为黄色，详情页面增加“已过期”标识。

        <a href="http://p.nts.com:89/products/">http://p.nts.com:89/products/</a>
        </li>
         <li>ERP报表增加 存货核算 参考列表
<a href="http://erp.nts.com:89/BillStatus.aspx?type=4">http://erp.nts.com:89/BillStatus.aspx?type=4</a>
        
        </li>
        
    </ul> 
      
<h3>
        2013.12.11</h3>
    <ul>
       
        <li>ERP单据流转分为 财务 和 业务 两部分,方便查看
        <a href="http://erp.nts.com:89">http://erp.nts.com:89</a>
        </li>
        
        
    </ul> 
   
   <h3>
        2013.12.09</h3>
    <ul>
       
        <li>修改流水码规则为 大类(2位)+小类(3位)+流水码(5位)</li>
        <li>修复bug:搜索页面小类下拉列表无法加载</li>
        <li>ERP审核单据流转+审核详情 http://erp.nts.com:89  </li>
        
    </ul> 
   
    
   <h3>

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
