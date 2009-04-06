<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TribeShoutbox.ascx.cs" Inherits="CustomControls_TribeShoutbox" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../Shoutbox.ascx" tagname="Shoutbox" tagprefix="uc1" %>

<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Vista" />

<uc1:Shoutbox ID="Shoutbox1" runat="server" />
