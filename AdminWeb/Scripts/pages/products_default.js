$(function () {

    var theCart = new Cart();
    $(".btnAddToCart").click(function (e) {

        var theCart = new Cart();
        var that = this;
        theCart.AddToCart($(that).attr("pid"), 1);
        $("#sumCart").text(theCart.TotalQty);

        $(that).closest("tr").attr("bgcolor", "#f572e2");
        $(that).closest("tr").children("td").css("background-color", "#f572e2");

    });
    //产品选择
    $("#cbxSelAll").click(function () {
        var that = this;
        // $(that).toggle(that.checked);
        var checkedAll = $(that).is(":checked");

        $(".cbxp").attr("checked", checkedAll);
        $(".cbxp").closest("tr").children("td").toggleClass("sel", checkedAll);
    });
    $(".cbxp").change(function () {

        //样式
        var checked = this.checked;
        if (!checked) {
            $("#cbxSelAll").attr("checked", false);
        }
        $(this).closest("tr").children("td").toggleClass("sel", checked);

        /*购物车*/
        if (checked) {
            theCart.AddToCart($(this).attr("pid"), 1);
        }
        else {
            theCart.Delete($(this).attr("pid"));
        }
        $("#sumCart").text(theCart.TotalQty);

    });

    function cbxClick(pid) {
        
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
        return JSON.stringify(new Cart().CartItems).indexOf($(that).find(".cbxp").attr("pid")) >= 0;
    });
    currentProducts.children("td").addClass("sel");
    $(currentProducts.find(".cbxp")).attr("checked", true);
}