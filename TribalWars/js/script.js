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

function overviewShowLevel() {
	labels = overviewGetLabels();
	for(var i=0, len=labels.length; i < len; i++) {
		var label = labels[i];
		if(!label) continue;
		label.style.display = 'inline';
	}
}

function overviewHideLevel() 
{
	labels = overviewGetLabels();
	for(var i=0, len=labels.length; i < len; i++) {
		var label = labels[i];
		if(!label) continue;
		label.style.display = 'none';
	}
}

function gid(id) 
{
	return document.getElementById(id);
}

function overviewGetLabels() {
	labels = Array();
	labels.push(gid("l_main"));
	labels.push(gid("l_place"));
	labels.push(gid("l_wood"));
	labels.push(gid("l_stone"));
	labels.push(gid("l_iron"));
	labels.push(gid("l_statue"));
	labels.push(gid("l_wall"));
	labels.push(gid("l_farm"));
	labels.push(gid("l_hide"));

	labels.push(gid("l_storage"));
	labels.push(gid("l_market"));

	labels.push(gid("l_barracks"));
	labels.push(gid("l_stable"));
	labels.push(gid("l_garage"));
	labels.push(gid("l_church"));
	labels.push(gid("l_church_f"));
	labels.push(gid("l_snob"));
	labels.push(gid("l_smith"));

	return labels;
}