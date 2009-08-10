function production(element, timeout)
{
    var quantity = $("#" + element).html();
    quantity++;
    
    $("#" + element).html(quantity);
    setTimeout("production('" + element + "', " + timeout + ")", timeout);
}

function queryString(ji)
{
    hu = window.location.search.substring(1);
    gy = hu.split("&");
    for (i = 0; i < gy.length; i++)
    {
        ft = gy[i].split("=");
        if (ft[0] == ji)
            return ft[1];
    }
    return "";
}

function getPage() {
    var url = location.pathname + "?redirect=1";
    var id = queryString("id");
    var page = queryString("page");

    if (id != "")
        url += "&id=" + id;
    if (page != "")
        url += "&page=" + page;
    return url;
}

function reload() {
    window.location = getPage();
}

function attackTimer()
{
    $('span.timer').each(function() {
        var arr = $(this).html().split(":");
        var hour = eval(arr[0]);
        var minute = eval(arr[1]);
        var second = eval(arr[2]);

        second--;
        if (second < 0) {
            minute--;
            second = 59;
        }
        if (minute < 0) {
            hour--;
            minute = 59;
        }
        if (hour < 0) {
            setTimeout("reload()", 2000);
            return;
        }
        if (second == 0 && minute == 0 && hour == 0) {
            setTimeout("reload()", 2000);
            return;
        }
        $(this).html(hour + ":" + ((minute < 10) ? ("0" + minute) : minute) + ":" + ((second < 10) ? ("0" + second) : second));
    });
        
        if ($('span.timer').size()>0)
            setTimeout("attackTimer()", 1000);
}

function increaseTime() {
    $('span.increaseTimer').each(function() {
        var arr = $(this).html().split(":");
        var hour = eval(arr[0]);
        var minute = eval(arr[1]);
        var second = eval(arr[2]);

        second++;
        if (second > 59) {
            minute++;
            second = 00;
        }
        if (minute >59) {
            hour++;
            minute = 00;
        }
        $(this).html(hour + ":" + ((minute < 10) ? ("0" + minute) : minute) + ":" + ((second < 10) ? ("0" + second) : second));
    });
    setTimeout("increaseTime()", 1000);
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

function overviewShowLevel() 
{
    $("div.label").show();	
}

function overviewHideLevel() 
{
	$("div.label").hide();
}

function Test(str) {
    alert(str);
}

function ShowHideShoutbox(shoutbox) {
    var dock = $find(shoutbox);
    var isClosed = dock.get_closed();
    dock.set_closed(!isClosed);
}