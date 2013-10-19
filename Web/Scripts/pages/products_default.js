$(function () {
    //Begin 产品集管理

    //将产品增加到产品集
    $("#cbxSelAll").click(function () {
        var that = this;
        // $(that).toggle(that.checked);
        var checkedAll = $(that).is(":checked");

        $(".cbxp").attr("checked", checkedAll);
        $(".cbxp").closest("tr").children("td").toggleClass("sel", checkedAll);
    });
    //点击产品对应的checkbox
   
    $(".cbxp").change(function () {

        //复选框状态
        var checked = this.checked;
        if (!checked) {
            $("#cbxSelAll").attr("checked", false);
        }
        $(this).closest("tr").children("td").toggleClass("sel", checked);
        var pid = $(this).attr("pid");
        ProquestProduct(pid);
        
    });
    

    function CallBack_CheckProduct(data) {
        $("#sumCart").text(data);
    }
    InitSelectedProduct();
});


/*
初始化已经选择好的产品
*/
function InitSelectedProduct() {

    var selectedProducts = new Cart().CartItems;
    var currentProducts = $("table[id$='dgProduct']").find("tr").filter(function (index) {
        if (index == 0) return false;
        var that = this;
        return ProductIdListIndefaultCollection.indexOf($(that).find(".cbxp").attr("pid")) >= 0;
    });
    currentProducts.children("td").addClass("sel");
    $(currentProducts.find(".cbxp")).attr("checked", true);
}