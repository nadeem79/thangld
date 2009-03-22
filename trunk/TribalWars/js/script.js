function production(element, timeout)
{
    var quantity = $("#" + element).html();
    quantity++;
    
    $("#" + element).html(quantity);
    setTimeout("production('" + element + "', " + timeout + ")", timeout);
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
            if (second==0&&minute==0&&hour==0)
                history.go(0);
            $(this).html(hour + ":" + minute + ":" + second);
        });
        setTimeout("attackTimer()", 1000);
}

function insertUnit(element, value)
{
    var quantity = $("#" + element).val();
    quantity += 0;
    
    if (quantity==0)
        $("#" + element).val(value);
    else
        $("#" + element).val("0");
}