$(function () {
    $("#form1").validate({
        errorLabelContainer: "#dvError",
        wrapper: "li",
        errorClass: "formError",
        invalidHandler: function (e, validator) {
            var errors = validator.numberOfInvalids();
            if (errors) {
                var message = '有' + errors + "个错误,请修改.";
                $("div#dvError span").html(message);
                $("div#dvError").show();
                //将后面的错误信息移动到该summary
            } else {
                $("div#dvError").hide();
            }
        }

    });
//    $(".fName").each(function (e) {
//        var that = this;
//        $(that).rules("add", {
//            required: true,
//            messages: {
//                required: "请填写产品名称."
//            }
//        });
//    });
    $.validator.addMethod("pName", $.validator.methods.required,
    "请填写产品名称");
    jQuery.validator.addClassRules("pName", {
        pName: true
    });

    $.validator.addMethod("pUnit", $.validator.methods.required,
    "请填写  单位");
    jQuery.validator.addClassRules("pUnit", {
        pUnit: true
    });

    $.validator.addMethod("pOriginal", $.validator.methods.required,
    "请填写  产地");
    jQuery.validator.addClassRules("pOriginal", {
        pOriginal: true
    });

    $.validator.addMethod("pDelivery", $.validator.methods.required,
    "请填写  发货地");
    jQuery.validator.addClassRules("pDelivery", {
        pDelivery: true
    });

    $.validator.addMethod("pParameters", $.validator.methods.required,
    "请填写  产品参数");
    jQuery.validator.addClassRules("pParameters", {
        pParameters: true
    });

    $.validator.addMethod("pDescription", $.validator.methods.required,
    "请填写  产品描述");
    jQuery.validator.addClassRules("pDescription", {
        pDescription: true
    });

    $.validator.addMethod("pModelNumber", $.validator.methods.required,
    "请填写  型号");
    jQuery.validator.addClassRules("pModelNumber", {
        pModelNumber: true
    });

    $.validator.addMethod("pPrice", $.validator.methods.required,
    "请填写  出厂价");
    jQuery.validator.addClassRules("pPrice", {
        pPrice: true
    });

    $.validator.addMethod("pMoneyType", $.validator.methods.required,
    "请填写  币别");
    jQuery.validator.addClassRules("pMoneyType", {
        pMoneyType: true
    });

    $.validator.addMethod("pTax", $.validator.methods.required,
    "请填写  税率");
    jQuery.validator.addClassRules("pTax", {
        pTax: true
    });

    $.validator.addMethod("pOrderMinAmount", $.validator.methods.required,
    "请填写  最小起定量");
    jQuery.validator.addClassRules("pOrderMinAmount", {
        pOrderMinAmount: true
    });

    $.validator.addMethod("pProductCycle", $.validator.methods.required,
    "请填写  生产周期名称");
    jQuery.validator.addClassRules("pProductCycle", {
        pProductCycle: true
    });

});




