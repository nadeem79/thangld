<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FloatingModalDock.aspx.cs"
    Inherits="FloatingModalDock" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" type="text/css" href="css/facebox.css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/facebox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1"
                runat="server" Text="Button" onclick="Button1_Click1" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
    
    <div id="abc">
    gaga
        <input type="button" value="gg" onclick="__doPostBack('Button2', '')" />
    </div>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:Button runat="server" ID="Button2" onclick="Button2_Click1" Text="Button2" />
    </form>
    
</body>
</html>
