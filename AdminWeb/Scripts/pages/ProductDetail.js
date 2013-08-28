$(function () {
    var theCart = new Cart();
    $("#btnAddToCart").click(function () {

        var pid = $(this).attr("pid");
        if (theCart.IsInCart(pid) != null) {
            if (confirm("确定从选单中删除?")) {

                theCart.Delete(pid);
                $(this).val("加入选单");
            }
        }
        else { 
        
        }

    });
});


