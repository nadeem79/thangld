function production(element, timeout) 
{
    var quantity = $("#" + element).html();
    quantity++;
    $("#" + element).html(quantity);
    var str = "production('" + element + "', " + timeout + ")";
    $("#test").html(str);
    setTimeout(str, timeout);
}

function attackTimer()
{
    $('span.timer').each(function () 
        {
            var arr = $(this).html().split(":");
            var hour = eval(arr[0]);
            var minute = eval(arr[1]);
            var second = eval(arr[2]);
            
            second--;
            if (second<0)
            {
                minute--;
                second=59;
            }
            if (minute<0)
            {
                hour--;
                minute=59;
            }
            if (hour<0)
            {
                history.go(0);
            }
            $(this).html(hour + ":" + minute + ":" + second);
        });
        setTimeout("attackTimer()", 1000);
}