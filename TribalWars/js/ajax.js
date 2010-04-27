function ajaxCreate() {
	try
	{
		if(window.XMLHttpRequest) {
			return new XMLHttpRequest();
		}
		else if(window.ActiveXObject) {
			return new ActiveXObject("Microsoft.XMLHTTP");
		}
	}
	catch (e)
	{
		return false;
	}
}

function ajaxSync(url, data) {
	var req = ajaxCreate();

	if(data != null) {
		req.open("POST", url, false);
		req.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
		req.setRequestHeader("Content-length", data.length);
	}
	else {
		req.open("GET", url, false);
	}
	req.send(data);

	return req;
}

function ajaxAsync(url, data, callback) {
	var req = ajaxCreate();

	if(data != null) {
		req.open("POST", url, true);
		req.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
		req.setRequestHeader("Content-length", data.length);
	}
	else {
		req.open("GET", url, true);
	}
	req.onreadystatechange = function() { if(req.readyState == 4) callback.complete(req); }
	req.send(data);

	return req;
}