function initMenuList(menuRowID) {
	var menuRow = document.getElementById(menuRowID);
	for(index in menuRow.childNodes) {
		var node = menuRow.childNodes[index];
		if(node.nodeType == 1 && node.nodeName == "TD")
			initMenu(node);
	}
}

function initMenu(cell) {
    cell.onmouseover = function() {
        this.className = "hover";
    }
  
    cell.onmouseout = function() {
        this.className = "";
    }
}