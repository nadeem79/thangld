<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="RadScriptManager1" runat="server">  
        </asp:ScriptManager> 
        <telerik:RadTextBox ID="txtInput" runat="server">  
                </telerik:RadTextBox> 
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">  
            <ContentTemplate> 
                
                <br /> 
                <asp:Button ID="bttnSend" runat="server" OnClick="bttnSend_Click" Text="sdfgh"></asp:Button><br /> 
                <telerik:RadToolTip ID="pAttack" runat="server" ShowEvent="FromCode" Skin="Office2007" 
                    TargetControlID="bttnSend" Position="Center" RelativeTo="BrowserWindow" Width="200" 
                    Height="200" Title="Tấn công" Modal="True" ShowDelay="100" ShowCallout="False" 
                    ManualClose="true">  
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">  
                        <ContentTemplate> 
                            <asp:Label ID="lblConfirm" runat="server"></asp:Label>
                            <asp:Button ID="Confirm" runat="server" Text="abc" OnClick="Confirm_Click"></asp:Button>
                        </ContentTemplate> 
                    </asp:UpdatePanel> 
                </telerik:RadToolTip> 
            </ContentTemplate> 
            <Triggers> 
                <asp:AsyncPostBackTrigger ControlID="bttnSend" EventName="Click" /> 
                <asp:AsyncPostBackTrigger ControlID="Confirm" EventName="Click" /> 
            </Triggers> 
        </asp:UpdatePanel> 
    </form>
</body>
</html>
