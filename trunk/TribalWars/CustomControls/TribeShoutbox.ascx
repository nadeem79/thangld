<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TribeShoutbox.ascx.cs" Inherits="CustomControls_TribeShoutbox" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../Shoutbox.ascx" tagname="Shoutbox" tagprefix="uc1" %>

<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Vista" />
<div id="shoutbox_area" style="width:100%; height:500px;"></div>
<telerik:RadWindow OffsetElementID="OffsetElement" CssClass="rtlClass" Skin="Sunset"
                runat="server"  VisibleOnPageLoad="true" RestrictionZoneID="shoutbox_area"
                ID="Radwindow1">
            </telerik:RadWindow>
