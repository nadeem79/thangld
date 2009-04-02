<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shoutbox.aspx.cs" Inherits="shoutbox" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register src="Shoutbox.ascx" tagname="Shoutbox" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shoutbox</title>
    <link rel="stylesheet" type="text/css" href="css/index.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
        <uc1:Shoutbox ID="Shoutbox" runat="server"/>
    
    </div>
    </form>
</body>
</html>
