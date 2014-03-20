$(function () {
    $("tr").each(function (e) {
        var tr = $(this);
        var clickCount = 0;
        tr.click(function () {
           
            if (clickCount % 2 == 0) {
                tr.css('background-color', '#34fe4d');
            }
            else {
                tr.css('background-color', '#fff');
            }
            clickCount++;
        });
    })
});