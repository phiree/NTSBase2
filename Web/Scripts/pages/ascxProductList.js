$(function () {


    var theCart = new Cart();
    $(".btnDeleteCart").click(function () {
        var that = this;
        var proName = $(that).parent().parent().find(".proname").text();
        if (!confirm("确定从产品集中删除\"  " + proName + "\"  ?")) {
            return false;
        }

        var pid = $(that).attr("pid");
        theCart.Delete(pid);
        $("#sumCart").text(new Cart().TotalQty);

        $(that).parent().parent().remove();
    });

});

