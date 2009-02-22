var timeDiff = null;
var timeStart = null;

// Mausposition
var mx = 0;
var my = 0;

var resis = new Object();
var timers = new Array();

if(document.addEventListener)
	document.addEventListener("mousemove", watchMouse, true);
else
	document.onmousemove = watchMouse;

function watchMouse(e) {
	if(e) {
		mx = e.clientX;
		my = e.clientY;
	}
	else {
		mx = window.event.clientX;
		my = window.event.clientY;
	}

	var info = document.getElementById("info");
	if(info != null && info.style.visibility == "visible") {
		map_move();
	}
}

/**
 * Title-Tag setzen
 */
function setImageTitles() {
	//var imgs = fetch_tags(document, 'img');
	for (var i = 0; i < document.images.length; i++)
	{
		var image = document.images[i];
		if (!image.title && image.alt != '')
		{
			image.title = image.alt;
		}
	}
}

function setCookie(name, value) {
	document.cookie = name+"="+value;
}

function popup(url, width, height) {
	wnd = window.open(url, "popup", "width="+width + ",height="+height + ",left=150,top=150,resizable=yes");
	wnd.focus();
}

function popup_scroll(url, width, height) {
	wnd = window.open(url, "popup", "width="+width + ",height="+height + ",left=150,top=100,resizable=yes,scrollbars=yes");
	wnd.focus();
}

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
            $(this).html(hour + ":" + minute + ":" + second);
        });
        setTimeout("attackTimer()", 1000);
}

function addTimer(element, endTime, reload) {
	var timer = new Object();
	timer['element'] = element;
	timer['endTime'] = endTime;
	timer['reload'] = reload;
	timers.push(timer);
}


function startTimer() {
	var serverTime = getTime(document.getElementById("serverTime"));
	timeDiff = serverTime-getLocalTime();
	timeStart = serverTime;

	// Nach span mit der Klasse timer und timer_replace suchen
	var spans = document.getElementsByTagName("span");
	for(var i=0; i<spans.length; i++) {
		var span = spans[i];
		if(span.className == "timer" || span.className == "timer_replace") {
			startTime = getTime(span);
			if(startTime != -1)
				addTimer(span, serverTime+startTime, (span.className == "timer"));
		}
	}

	startResTicker('wood');
	startResTicker('stone');
	startResTicker('iron');

	window.setInterval("tick()", 1000);
}

function startResTicker(resName) {
	var element = document.getElementById(resName);
	var start = parseInt(element.firstChild.nodeValue);
	var max = parseInt(document.getElementById("storage").firstChild.nodeValue);
	var prod = element.title/3600;

	var res = new Object();
	res['name'] = resName;
	res['start'] = start;
	res['max'] = max;
	res['prod'] = prod;
	resis[resName] = res;
}

function tickRes(res) {
	var resName = res['name'];
	var start = res['start'];
	var max = res['max'];
	var prod = res['prod'];

	var now = new Date();
	var time = (now.getTime()/1000+timeDiff)-timeStart;
	var current = Math.min(Math.floor(start+prod*time), max);
	var element = document.getElementById(resName);
	element.firstChild.nodeValue = current;

	if(current == max) {
		element.setAttribute('class', 'warn');
	}
}

function tick() {
	tickTime();
	for(var res in resis) {
		tickRes(resis[res]);
	}
	for(var timer=0;timer<timers.length;timer++){
		var remove = tickTimer(timers[timer]);
		if(remove) {
			timers.splice(timer, 1);
		}
	}
}

function tickTime() {
	var serverTime = document.getElementById("serverTime");
	if(serverTime != null) {
		var time = getLocalTime()+timeDiff;
		formatTime(serverTime, time, true);
	}
}

function tickTimer(timer) {
	var time = timer['endTime']-(getLocalTime()+timeDiff);

	if(timer['reload'] && time < 0) {
		document.location.href = document.location.href.replace(/action=\w*/, '');
		formatTime(timer['element'], 0, false);
		return true;
	}

	if (!timer['reload'] && time <= 0)
	{
		// Timer ausblenden und Alternativ-Text anzeigen
		var parent = timer['element'].parentNode;
		parent.nextSibling.style.display = 'inline'; // Nachfolger des Parent einblenden
		parent.parentNode.removeChild(parent); // Parent entfernen

		return true;
	}

	formatTime(timer['element'], time, false);
	return false;
}

function getLocalTime() {
	var now = new Date();
	return Math.floor(now.getTime()/1000)
}

function getTime(element) {
	// Zeit auslesen
	if(element.firstChild.nodeValue == null) return -1;
	var part = element.firstChild.nodeValue.split(":");

	// Führende Nullen entfernen
	for(var j=1; j<3; j++) {
		if(part[j].charAt(0) == "0")
			part[j] = part[j].substring(1, part[j].length);
	}

	// Zusammenfassen
	var hours = parseInt(part[0]);
	var minutes = parseInt(part[1]);
	var seconds = parseInt(part[2]);
	var time = hours*60*60+minutes*60+seconds;
	return time;
}

function formatTime(element, time, clamp) {
	// Wieder aufsplitten
	var hours = Math.floor(time/3600);
	if(clamp) hours = hours%24;
	var minutes = Math.floor(time/60) % 60;
	var seconds = time % 60;

	var timeString = hours + ":";
	if(minutes < 10)
		timeString += "0";
	timeString += minutes + ":";
	if(seconds < 10)
		timeString += "0";
	timeString += seconds;

	element.firstChild.nodeValue = timeString;

	if(timeString == '0:00:00') {
		incrementDate();
	}
}

function incrementDate() {
	currentDate = gid('serverDate').firstChild.nodeValue;
	splitDate = currentDate.split('/');

	date = splitDate[0];
	month = splitDate[1] - 1;
	year = splitDate[2];

	dateObject = new Date(year, month, date);
	dateObject.setDate(dateObject.getDate()+1);

	dateString = '';

	date = dateObject.getDate();
	month = dateObject.getMonth() + 1;
	year = dateObject.getFullYear();

	if(date < 10)
		dateString += "0";
	dateString += date + "/";
	if(month < 10)
		dateString += "0";
	dateString += month + "/";
	dateString += year;


	gid('serverDate').firstChild.nodeValue=dateString;


}

function selectAll(form, checked) {
	for(var i=0; i<form.length; i++) {
		form.elements[i].checked = checked;
	}
}

/**
 * Im Adelshof für alle Dörfer Nichts/Maximum auswählen
 */
var max = true;
function selectAllMax(form, textMax, textNothing) {
	for(var i=0; i<form.length; i++) {
		var select = form.elements[i];
		if(select.selectedIndex != null) {
			if(max)
				select.selectedIndex = select.length-2;
			else
				select.value = 0;
		}
	}

	max = max ? false : true;

	anchor = document.getElementById('select_anchor_top');
	anchor.firstChild.nodeValue = max ? textMax : textNothing;
	anchor = document.getElementById('select_anchor_bottom');
	anchor.firstChild.nodeValue = max ? textMax : textNothing;

	changeBunches(form);
}

function changeBunches(form) {
	var sum = 0;
	for(var i=0; i<form.length; i++) {
		var select = form.elements[i];
		if(select.selectedIndex != null) {
			sum += parseInt(select.value);
		}
	}

	setText(gid('selectedBunches_bottom'), sum);
	setText(gid('selectedBunches_top'), sum);
}

function redir(href) {
	window.location.href = href;
}

function setText(element, text) {
	var textNode = document.createTextNode(text);
	element.removeChild(element.firstChild);
	element.appendChild(textNode);
}

var old_extra_text = null;
var extra_info_timeout = null;
var map_info_data = new Object();
function map_popup(title, bonus_image, bonus_text, points, owner, ally, village_groups, moral, village_id, source_id, last_attack_date, last_attack_dot) {
	setText(gid("info_title"), title);

	var info_bonus_image = gid("info_bonus_image");
	var info_bonus_text = gid("info_bonus_text");
	if(bonus_image != '') {
		info_bonus_image.firstChild.src = bonus_image;
		info_bonus_text.firstChild.firstChild.innerHTML = bonus_text;
		info_bonus_image.style.display = '';
		info_bonus_text.style.display = '';
	}
	else {
		info_bonus_image.style.display = 'none';
		info_bonus_text.style.display = 'none';
	}

	setText(gid("info_points"), points);
	if(owner != null) {
		setText(gid("info_owner"), owner);
		gid("info_owner_row").style.display = '';
		gid("info_left_row").style.display = 'none';
	}
	else {
		gid("info_owner_row").style.display = 'none';
		gid("info_left_row").style.display = '';
	}

	if(ally != null) {
		gid("info_ally_row").style.display = '';
		setText(gid("info_ally"), ally);
	}
	else {
		gid("info_ally_row").style.display = 'none';
	}

	if(village_groups) {
		gid("info_village_groups_row").style.display = '';
		setText(gid("info_village_groups"), village_groups);
	} else {
		gid("info_village_groups_row").style.display = 'none';
	}

	if(moral && gid('map_popup_moral') && gid('map_popup_moral').checked) {
		gid("info_moral_row").style.display = '';
		setText(gid("info_moral"), moral + '%');
	} else {
		gid("info_moral_row").style.display = 'none';
	}

	if(last_attack_date && last_attack_dot) {
		gid("info_last_attack_row").style.display = '';
		gid("info_last_attack").innerHTML = '<img alt="" src="graphic/' + last_attack_dot + '" /> ' + last_attack_date;
	} else {
		gid("info_last_attack_row").style.display = 'none';
	}

	var show_info = village_id != false &&
		(gid('map_popup_res').checked ||
		gid('map_popup_pop').checked ||
		gid('map_popup_trader').checked ||
		gid('map_popup_units').checked ||
		gid('map_popup_units_times').checked);

	if(show_info) {
		gid('info_extra_info').style.display = '';
		if(old_extra_text == null) {
			old_extra_text = gid('info_extra_info').firstChild.firstChild.nodeValue;
		} else {
			gid('info_extra_info').firstChild.innerHTML = old_extra_text;
		}
		if(map_info_data[village_id] == null) {
			extra_info_timeout = window.setTimeout("map_info_get(" + village_id + ", " + source_id + ")", 500);
		} else {
			map_info(village_id);
		}

	} else {
		gid('info_extra_info').style.display = 'none';
	}

	map_move();
	var info = gid("info");
	info.style.visibility = "visible";
}

function map_kill() {
	var info = document.getElementById("info");
	info.style.visibility = "hidden";
	if(extra_info_timeout != null) {
		window.clearTimeout(extra_info_timeout);
	}
}

function map_move() {
	var info_content = $("info_content"); // gid() nicht möglich, da sonst IE7 kein Element zurück gibt.
	var info = $("info");

	if(window.pageYOffset)
		scrollY = window.pageYOffset;
	else
		scrollY = document.body.scrollTop;

	// Sicherstellen, dass Popup nicht vom rechten Rand abgeschnitten wird
	var popup_size = info_content.getCoordinates();
	var window_width = window.getWidth();
	// getWidth funktioniert im IE6 nur wenn XHTML strict
	if(!window_width){
		window_width = document.body.clientWidth;
	}
	var margin_right = window_width - mx;

	if(margin_right > popup_size.width + 5) {
		info.style.left = mx + 5 + "px";
	} else {
		info.style.left = window_width - popup_size.width + "px";
	}

	// Unterer Rand des Popups soll nicht Mauszeiger überlappen
	var popup_top =  my - popup_size.height - 5 + scrollY;
	info.style.top = popup_top + "px";
}

function map_info_get(village_id, source_id)
{
	var url = 'game.php?screen=overview&xml&village=' + village_id + '&source=' + source_id;
	var t = get_sitter_player()
	if(t) {
		url = url + '&t=' + t;
	}

	var map_info_callback = new Object();
	map_info_callback.complete = function(req) {
		var village_data = new Object();
		var village = req.responseXML.firstChild;
		while (village != null && village.nodeType != 1) {
			village = village.nextSibling;
		}
		if(village.firstChild.nodeName == 'error') {
			var error = village.firstChild.nodeValue;
			alert(error);
		}
		village_data['id'] = parseInt(village.getAttribute('id'));
		for(var i = 0; i < village.childNodes.length; i++) {
			village_data[village.childNodes[i].nodeName] = village.childNodes[i].firstChild.nodeValue;
		}
		map_info_data[village_data['id']] = village_data;
		map_info(village_data['id']);
	}

	ajaxAsync(url, null, map_info_callback);
}

function map_info(village_id)
{
	var village_data = map_info_data[village_id];
	var xhtml = '<table>';

	// Rohstoffe
	if(gid('map_popup_res').checked && (village_data['wood'] || village_data['stone'] || village_data['iron'] || village_data['storage_max'])) {
		xhtml += '<tr><td colspan="2"><table><tr>';
		if (village_data['wood']) xhtml += '<td><img src="' + image_base + '/holz.png" />' + village_data['wood'] + '</td>';
		if (village_data['stone']) xhtml += '<td><img src="' + image_base + '/lehm.png" />' + village_data['stone'] + '</td>';
		if (village_data['iron']) xhtml += '<td><img src="' + image_base + '/eisen.png" />' + village_data['iron'] + '</td>';
		if (village_data['storage_max']) xhtml += '<td><img src="' + image_base + '/res.png" />' + village_data['storage_max'] + '</td>';
		xhtml += '</tr></table></td></tr>';
	}


	var pop_xhtml = false;
	if(gid('map_popup_pop').checked && village_data['pop_max']) {
		pop_xhtml = '<img src="' + image_base + '/face.png" />' + village_data['pop'] + '/' + village_data['pop_max'];
	}

	var trader_xhtml = false;
	if(gid('map_popup_trader').checked && village_data['trader_current']) {
		trader_xhtml = '<img src="' + image_base + '/overview/trader.png" />' + village_data['trader_current'] + '/' + village_data['trader_total'];
	}

	// Bevölkerung und Haendler
	if(pop_xhtml || trader_xhtml) {
		xhtml += '<tr><td colspan="2"><table><tr>';
		xhtml += xhtml_column_builder(pop_xhtml, trader_xhtml);
		xhtml += '</tr></table></td></tr>';
	}

	if(gid('map_popup_units').checked || gid('map_popup_units_times').checked) {
		uh_xhtml = '<tr><td colspan="2"><table style="border:1px solid #DED3B9" cellpadding="0" cellspacing="0"><tr class="center">';
		var i=0;
		for(var prop in village_data) {
			if((prop.substr(0, 4) == 'unit') && ((village_data[prop] != 0) || (gid('map_popup_units_times').checked && village_data['time_'+prop]))) {
				var bgcolor = ((i%2) == 0) ? 'F8F4E8' : 'DED3B9';
				uh_xhtml += '<td style="padding:2px;background-color:#'+bgcolor+'"><img src="' + image_base + '/unit/' + prop + '.png" alt="" /></td>';
				i++;
			}
		}

		i=0;
		units=0;
		un_xhtml='';

		for(var prop in village_data) {
			if(prop.substr(0, 4) == 'unit' && village_data[prop] != 0 && gid('map_popup_units').checked) {
				var bgcolor = ((i%2) == 0) ? 'F8F4E8' : 'DED3B9';
				un_xhtml += '<td style="padding:2px;background-color:#'+bgcolor+'">'+village_data[prop]+'</td>';
				i++;
				units++;
			} else if (gid('map_popup_units_times').checked && village_data['time_'+prop]) {
				var bgcolor = ((i%2) == 0) ? 'F8F4E8' : 'DED3B9';
				un_xhtml += '<td style="padding:2px;background-color:#'+bgcolor+'">&#160;</td>';
				i++;
			}
		}

		i=0;
		times=0;
		ut_xhtml='';

		if(gid('map_popup_units_times').checked) {
			for(var prop in village_data) {
				if(prop.substr(0, 9) == 'time_unit' && village_data[prop] != 0) {
					var bgcolor = ((i%2) == 0) ? 'F8F4E8' : 'DED3B9';
					ut_xhtml += '<td style="padding:2px;font-size: 9px;background-color:#'+bgcolor+'">' + village_data[prop] +'</td>';
					i++;
					times++;
				}
			}
		}

		if (units > 0 || times > 0) {
			xhtml += uh_xhtml;

			if (units > 0) {
				xhtml += '</tr><tr class="center">';
				xhtml += un_xhtml;
			}

			if (times	> 0) {
				xhtml += '</tr><tr class="center">';
				xhtml += ut_xhtml;
			}
			xhtml += '</tr></table></tr></td></tr>';
		}
	}
	xhtml += '</table>';
	gid('info_extra_info').firstChild.innerHTML = xhtml;
	map_move();
}

function xhtml_column_builder(col1, col2) {
	var xhtml = '';
	xhtml += '<tr>';
	if(col1 && col2) {
		xhtml += '<td>' + col1 + '</td><td>' + col2 + '</td>';
	} else {
		if(col1) {
			xhtml += '<td colspan="2">' + col1 + '</td>';
		} else {
			xhtml += '<td colspan="2">' + col2 + '</td>';
		}
	}
	xhtml += '</tr>';
	return xhtml;
}

function toggle_map_popup_options() {
	if(gid('map_popup_options').style.display == 'none') {
		gid('map_popup_options').style.display = '';
	} else {
		gid('map_popup_options').style.display = 'none';
	}
}

function gid(id) {
	return document.getElementById(id);
}

function mapScroll(x, y) {
	width = 10;
	height = 10;
	url = "map.php?x="+x+"&y="+y+"&width="+width+"&height="+height;
	req = ajaxSync(url);
	villages = req.responseXML.firstChild.childNodes;
	for(var i=0; i<villages.length; i++) {
		v = villages[i];
		if(v.nodeType != 1) continue;
		if(v.nodeName != "v") continue;

		mapSetTile(3, 0, v);
	}
}

function mapSetTile(x, y, v) {
	tile = gid("tile_" + x + "_" + y);
	if(v != null) {
		alert(v.getAttribute("href"));
		//tile.className = v.className;
		tile.replaceChild(v, tile.firstChild);
	}
	else {
		img = document.createElement("img");
		img.src = "graphic/map/map_free.png";
		tile.replaceChild(img, tile.firstChild);
	}
}

function insertCoord(form, element) {
	// Koordinaten auslesen
	part = element.value.split("|");
	if(part.length != 2) return;
	x = parseInt(part[0]);
	y = parseInt(part[1]);
	form.x.value = x;
	form.y.value = y;
}

function insertCoordNew(form, element) {
	// Koordinaten auslesen
	part = element.value.split(":");
	if(part.length != 3) return;
	form.con.value = parseInt(part[0]);
	form.sec.value = parseInt(part[1]);
	form.sub.value = parseInt(part[2]);
}

function insertUnit(input, count) {
	if(input.value != count)
		input.value=count;
	else
		input.value='';
}

function insertNumber(input, count) {
	if(input.value != count)
		input.value=count;
	else
		input.value='';
}

function insertBBcode(textareaID, startTag, endTag) {
		var input = $(textareaID);
		input.focus();

		/* für Internet Explorer */
		if(typeof document.selection != 'undefined') {
			 /* Einfügen */
			var range = document.selection.createRange();
			var insText = range.text;
			range.text = startTag + insText + endTag;

			/* Cursorposition anpassen */
			range = document.selection.createRange();
			if (insText.length == 0) {
				range.move('character', -endTag.length);
			} else {
				range.moveStart('character', startTag.length + insText.length + endTag.length);
			}
			range.select();
		}

		/* für neuere auf Gecko basierende Browser */
		else if(typeof input.selectionStart != 'undefined') {
			/* Einfügen */
			var start = input.selectionStart;
			var end = input.selectionEnd;
			var insText = input.value.substring(start, end);
			input.value = input.value.substr(0, start) + startTag + insText + endTag + input.value.substr(end);

			/* Cursorposition anpassen */
			var pos;
			if (insText.length == 0) {
				pos = start + startTag.length;
			} else {
				pos = start + startTag.length + insText.length + endTag.length;
			}
			input.selectionStart = pos;
			input.selectionEnd = pos;
		}
}

function selectTarget(x, y) {
	document.forms["units"].elements["x"].value = x;
	document.forms["units"].elements["y"].value = y;
	inlinePopupClose();
}

function selectTargetCoord(con, sec, sub) {
	document.forms["units"].elements["con"].value = con;
	document.forms["units"].elements["sec"].value = sec;
	document.forms["units"].elements["sub"].value = sub;
	inlinePopupClose();
}

function insertAdresses(to, check) {
	opener.document.forms["header"].to.value += to;
	if(check) {
		var mass_mail = opener.document.forms["header"].mass_mail;
		if(mass_mail)
			mass_mail.checked='checked';
	}
}

function selectVillage(id) {
	var href = opener.location.href;
	if(href.search(/village=\d*/) != -1)
		href = href.replace(/village=\d*/, 'village='+id);
	else
		href += '&village='+id;
	href = href.replace(/action=\w*/, '');
	opener.location.href = href;
	window.close();
}

function overviewShowLevel() {
	labels = overviewGetLabels();
	for(var i=0, len=labels.length; i < len; i++) {
		var label = labels[i];
		if(!label) continue;
		label.style.display = 'inline';
	}
}

function overviewHideLevel() {
	labels = overviewGetLabels();
	for(var i=0, len=labels.length; i < len; i++) {
		var label = labels[i];
		if(!label) continue;
		label.style.display = 'none';
	}
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

function insertMoral(moral) {
	opener.document.getElementById('moral').value = moral;
}

function resetAttackerPoints(points) {
	document.getElementById('attacker_points').value = points;
}

function resetDefenderPoints(points) {
	document.getElementById('defender_points').value = points;
}

function resetDaysPlayed(days) {
	document.getElementById('days_played').value = days;
}

function editGroup(group_id) {
	var href = opener.location.href;
	href = href.replace(/&action=edit_group&edit_group=\d+&h=([a-z0-9]+)/, '');
	href = href.replace(/&edit_group=\d+/, '');
	overview = opener.document.getElementById('overview');
	if(overview && overview.value.search(/(combined|prod|units|buildings|tech)/) != -1) {
		opener.location.href = href + '&edit_group=' + group_id;
	}
	window.close();
}

function toggleExtended()
{
	var extended = document.getElementById('extended');
	if(extended.style.display == 'block') {
		extended.style.display = 'none';
		document.getElementsByName('extended')[0].value = 0;
	} else {
		extended.style.display = 'block';
		document.getElementsByName('extended')[0].value = 1;
	}
}

function resizeIGMField(type)
{
	field = document.getElementsByName('text')[0];
	old_size = parseInt(field.getAttribute('rows'));
	if(type == 'bigger') {
		field.setAttribute('rows',	old_size + 3);
	} else if(type == 'smaller') {
		if(old_size >= 4) {
			field.setAttribute('rows', old_size - 3);
		}
	}
}

/**
 * @param edit ID des anzuzeigenden Edit-Elements
 * @param label ID des zu versteckenden Label-Elements
 */
function editToggle(label, edit) {
	gid(edit).style.display = '';
	gid(label).style.display = 'none';
}

function toggle_visibility(id) {
	var element = document.getElementById(id);
	if(element.style.display == 'block')
		element.style.display = 'none';
	else
		element.style.display = 'block';
}

function urlEncode(string) {
	return encodeURIComponent(string);
}

/**
 *
 */
function editSubmit(label, labelText, edit, editInput, url) {
	var data = gid(editInput).value;
	data = urlEncode(data);

	var req = ajaxSync(url, 'text='+data);

	gid(edit).style.display = 'none';
	setText(gid(labelText), req.responseText);
	gid(label).style.display = '';
}

function editSubmitNew(label, labelText, edit, editInput, url) {
	var data = gid(editInput).value;
	var jSonRequest = new Request.JSON({url: url, onComplete: function(response_data) {
		response_data = JSON.decode(response_data);

		if(response_data.error) {
			alert(response_data.error);
		} else {
			gid(edit).style.display = 'none';
			setText(gid(labelText), response_data.text);
			gid(label).style.display = '';
		}
	}}).post({json: JSON.encode({text:data})});
}

function inlinePopup(name, url, options) {
	var popup_position_x = mx + options.offset_x;
	var popup_position_y = my + options.offset_y;

	$('inline_popup').setStyle('display', 'block');
	$('inline_popup').setStyle('left', popup_position_x + 'px');
	$('inline_popup').setStyle('top', popup_position_y + 'px');

	inlinePopupReload(name, url, options);
}

function inlinePopupReload(name, url, options) {
	// Even better would be a solution with automatic throbber creation.
	var req = new Request({
		url: url,
		onRequest: function() {
		 if(options.empty_errors)
			 $('error').empty();

		 $('inline_popup_content').empty();
		 $('inline_popup_content').appendChild(new Element(
			 'img',
			 {
				 'src': options.image_base + '/throbber.gif',
				 'alt': 'Loading...'
			 }
		 ));
		},
		onSuccess: function(reponseText, responseXML) {
		 $('inline_popup_content').empty();
		 $('inline_popup_content').innerHTML = reponseText;
		}
	}).send();
}

function inlinePopupClose() {
		$('inline_popup').setStyle('display', 'none');
}

function add_forum_share(edit_input, forum_id, url) {
	var ally_tag = gid(edit_input).value;
	
	var jSonRequest = new Request.JSON({url: url, onComplete: function(response_data) {
		response_data = JSON.decode(response_data);
		if(response_data.error) {
			$('error').empty();
			$('error').innerHTML = response_data.error;
			$('error').setStyle('display', '');
		} else {
			$('shared_'+forum_id).empty();
			$('shared_'+forum_id).innerHTML = response_data.new_shares;
			$('add_shares_link_'+forum_id).setStyle('display', 'none');
			$('edit_shares_link_'+forum_id).setStyle('display', '');
			inlinePopupClose();
		}
	}}).post({json: JSON.encode({ally_tag:ally_tag, forum_id:forum_id})});
}

function remove_forum_shares(label_text, forum_id, url) {
	var remove = new Array();
	$$('#checkboxes input').each (function (box){
		if(box.checked) 
			remove.push(box.value);
	});
	remove = JSON.encode(remove);

	var jSonRequest = new Request.JSON({url: url, onComplete: function(response_data) {
		response_data = JSON.decode(response_data);

		if(response_data.error) {
			$('error').empty();
			$('error').innerHTML = response_data.error;
			$('error').setStyle('display', '');
		} else {
			$(label_text).empty();

			if(response_data.new_shares)
				$(label_text).innerHTML = response_data.new_shares;
			else { 
				$('add_shares_link_'+forum_id).setStyle('display', '');
				$('edit_shares_link_'+forum_id).setStyle('display', 'none');
			}

			inlinePopupClose();
		}

	}}).post({json: JSON.encode({remove:remove, forum_id:forum_id})});
}

function showElement(name) {
	gid(name).style.display = '';
}

function get_sitter_player()
{

	var t_regexp = /(\?|&)t=(\d+)/;
	var matches = t_regexp.exec(location.href + "");
	if(matches) {
		return parseInt(matches[2]);
	} else {
		return false;
	}
}

function igm_to_show(url)
{
	var igm_to = gid('igm_to');
	gid('igm_to_content').innerHTML = ajaxSync(url, null).responseText;
	igm_to.style.display = 'inline';
}

function igm_to_hide()
{
	var igm_to = gid('igm_to');
	igm_to.style.display = 'none';
}

function igm_to_insert_adresses(list) {
	gid('to').value += list;
}

function igm_to_addresses_clear() {
	gid('to').value = '';
}

function xProcess(xelement, yelement) {
	xvalue = gid(xelement).value;
	yvalue = gid(yelement).value;

	if(xvalue.indexOf("|") != -1) {
		xypart = xvalue.split("|");
		x = parseInt(xypart[0]);
		
		if(xypart[1].length == 0)
			y = '';
		else		
			y = parseInt(xypart[1]);

		gid(xelement).value = x;
		gid(yelement).value = y;
		return;
	}

	if(xvalue.length == 3 && yvalue.length == 0)
		gid(yelement).focus();
}

function _(t) {
	if(lang[t]) {
		return lang[t];
	} else {
		return t;
	}
}

function swap_image(img_id, src_new) {
	$(img_id).src = src_new;
}

function map_toggle_belief_radius(checkbox, h, x, y) {
	var new_params = new Array();
	
	checked = checkbox.checked;
	params = window.location.search.substring(1, window.location.search.length);

	params_arr = params.split('&');
	
	for(i = 0; i < params_arr.length; i++) {
		param = params_arr[i].split('=');
		param_name  = param[0];
		param_value = param[1];
		
		// Parameter, die gleich wieder angehaengt werden filtern, damit sie nicht doppelt vorkommen
		if(param_name != 'belief' && param_name != 'h' && param_name != 'action') {
			new_params.push(param_name +'='+ param_value);
		}
	}
	
	// Array wieder zu url zusammensetzen
	new_params = new_params.join('&');
	
	new_params += '&action=save_belief&h='+h;
	if(checked) 
		new_params += '&belief=1';
	else
		new_params += '&belief=0';
	
	if(x)
		new_params += '&x='+x;

	if(y)
		new_params += '&y='+y;
	
	url = window.location.href.split('?')[0] + '?' + new_params;
	
	// Seite neu laden
	window.location.href = url;
}