<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="RadAjaxManager1" runat="server"></asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    <asp:UpdatePanel ID="panel" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
