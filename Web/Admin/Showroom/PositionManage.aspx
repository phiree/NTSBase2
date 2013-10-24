<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="PositionManage.aspx.cs" Inherits="Admin_Showroom_PositionManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Content/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/Admin/css/showroommanage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("#dvPositionForm").dialog({
                width: 370,
                autoOpen: false,
                buttons: [
                            {
                                text: "保存",
                                click: function () {
                                    var id = $("#hiId").val();
                                    var parentId = $("#hiParentId").val();
                                    var name = $("#name").val();
                                    var desc = $("#desc").val();
                                    var code = $("#code").val();
                                    $.post("/services/showroomservice.ashx",
                                                { "actiontype": "position_addmodify", "id": id, "parentId": parentId, "name": name, "code": code, "desc": desc }
                                                , function (data) {
                                                    $("#spMsg").show();
                                                    $("#spMsg").fadeOut(3000);
                                                }
                                                );
                                }
                            }
                    ,
                            {
                                text: "关闭",
                                click: function () {
                                    $(this).dialog("close");
                                }
                            }
                    ,
                            {
                                id: "dialog_button_delete",
                                text: "删除",
                                click: function () {

                                }
                            }
                ]
            });
            $(".dvAdd")
             .button()
              .click(function () {
                  $("#dialog_button_delete").hide();
                  $("#hiId").val("");
                  $("#name").val("");
                  $("#desc").val("");
                  $("#code").val("");
                  var parentId = $(this).parent().siblings("h3").attr("posId");
                  $("#hiParentId").val(parentId);
                  $("#dvPositionForm").dialog("open");
              });
            //修改
              $(".posName").click(function () {
                  $("#dialog_button_delete").show();
                var posId = $(this).attr("posId");
                $.get("/services/showroomservice.ashx",
                 { "actiontype": "position_get", "id": posId }
                 , function (data) {
                     $("#hiId").val(data.id);
                     $("#name").val(data.name);
                     $("#desc").val(data.desc);
                     $("#code").val(data.code);
                     $("#dvPositionForm").dialog("open");
                 }
            );

            });
            $("#btnSave").click(function () {
                var id = $("#hiId").val();
                var name = $("#name").val();
                var desc = $("#desc").val();
                var code = $("#code").val();

                $.post("/services/showroomservice.ashx",
             { "actiontype": "position_addmodify", "id": id, "name": name, "code": code, "desc": desc }
             , function (data) { }
             );
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageDesc" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater runat="server" ID="rpLv1">
        <HeaderTemplate><div id="dvContainerLv1">
        </HeaderTemplate>
        <ItemTemplate>
            <div>
                <h3 class="posName" posid='<%#Eval("id") %>'>
                    <%#Eval("Name") %></h3>
                    <asp:Repeater runat="server" ID="rpgLv2">
                        <HeaderTemplate><div class="dvContainerLv2">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div>
                                 <h3 class="posName" posid='<%#Eval("id")%>'>
                                    <%#Eval("Name") %></h3>
                             
                                    <asp:Repeater runat="server" ID="rpgLv3">
                                    <HeaderTemplate> 
                                      <div class="dvContainerLv3""></HeaderTemplate>
                                        <ItemTemplate>
                                            <div>
                                               <span class="posName" posid='<%#Eval("id") %>'><%#Eval("Name") %></span> 
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </div>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                     <div class="dvAdd">
                                                <span>增加展位</span></div>
                               
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                           
                         </div>
                        </FooterTemplate>
                    </asp:Repeater>
                 <div class="dvAdd">
                  <span >增加展厅</span></div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
           </div>
        </FooterTemplate>
            
    </asp:Repeater> 
    <div class="dvAdd">
      
      <span>增加展馆</span></div>
    <div id="dvPositionForm">
     <input type="hidden" id="hiId" />
     <input type="hidden" id="hiParentId" />
        <p>
            All form fields are required.</p>
        <fieldset>
            <label for="name">
                名称</label>
           
            <input type="text" name="name" id="name" class="text ui-widget-content ui-corner-all" />
            <label for="code">
                位置代码</label>
            <input type="text" name="code" id="code" value="" class="text ui-widget-content ui-corner-all" />
            <label for="description">
                位置描述</label>
            <input name="description" id="desc" value="" class="text ui-widget-content ui-corner-all" />
           <span id="spMsg"  class="hide success">保存成功</span>
        </fieldset>
    </div>
</asp:Content>
