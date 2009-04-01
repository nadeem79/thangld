<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <script type="text/javascript">
    function HideLoginToolTip() {
            var tooltip = $find("<%=RadToolTip1.ClientID%>");
            if (tooltip)
              tooltip.hide();
        }
        </script>

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate><asp:Label ID="abc" runat="server"></asp:Label></ContentTemplate></asp:UpdatePanel>
        <telerik:RadToolTip ID="RadToolTip1" runat="server" ShowEvent="OnClick" Skin="Office2007"
            TargetControlID="LinkButton1" Position="Center" RelativeTo="BrowserWindow" Title="Enter Name and Password"
            Modal="True" ShowDelay="100" ShowCallout="False" Width="250px" ManualClose="true" >
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <telerik:RadTextBox ID="RadTextBox1" runat="server">
                    </telerik:RadTextBox><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </telerik:RadToolTip>
    </div>
    </form>
</body>
</html>
