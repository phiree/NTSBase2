var serviceUrl = "/Services/ProductCollectionService.ashx";
function ProquestProduct(pid) {
    $.post(serviceUrl + "?pid=" + pid, function (data) { CallBack_CheckProduct(data); });
}

function CallBack_CheckProduct(data) {
    $("#sumCart").text(data);
}