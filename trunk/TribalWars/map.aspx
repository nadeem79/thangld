<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="map.aspx.cs"
    Inherits="map" EnableViewState="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" RelativeTo="Element"
        Position="BottomCenter" AutoTooltipify="true" ContentScrolling="Default" Skin="Web20">
    </telerik:RadToolTipManager>
    <h2>
        Bản đồ
    </h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <fieldset style="margin-bottom:5px;">
        x:
        <asp:TextBox ID="txtX" runat="server"></asp:TextBox>
        &nbsp;y:
        <asp:TextBox ID="txtY" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="centerButton" runat="server" onclick="centerButton_Click" 
            Text="Button" />
    </fieldset>
    
    <table class="map_container">
        <tbody>
            <tr>
                <td>
                </td>
                <td style="margin:2px;text-align:center;">
                    <asp:ImageButton ID="moveNorthButton" runat="server" ImageAlign="Middle" 
                        ImageUrl="~/images/map_n.png" style="width:11px;height:11px;" 
                        onclick="moveNorthButton_Click" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="margin:2px;">
                    <asp:ImageButton ID="moveWestButton" runat="server" ImageAlign="Middle" 
                        ImageUrl="~/images/map_w.png" style="width:11px;height:11px;" 
                        onclick="moveWestButton_Click" />
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Table ID="tbRows" runat="server" CssClass="table_map" CellPadding="0" CellSpacing="0">
                                </asp:Table>
                            </td>
                            <td>
                                <asp:Table ID="tbVillages" runat="server" CssClass="table_map" style="border:1px solid black;" CellPadding="0" CellSpacing="0">
                                </asp:Table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Table ID="tbColumns" runat="server" CssClass="table_map" CellPadding="0" CellSpacing="0">
                                </asp:Table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="margin:2px;">
                    <asp:ImageButton ID="moveEastButton" runat="server" ImageAlign="Middle" 
                        ImageUrl="~/images/map_e.png" style="width:11px;height:11px;" 
                        onclick="moveEastButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="margin:2px;text-align:center;">
                    
                    <asp:ImageButton ID="moveSouthButton" runat="server" ImageAlign="Middle" 
                        ImageUrl="~/images/map_s.png" style="width:11px;height:11px;" 
                        onclick="moveSouthButton_Click" />
                    
                </td>
                <td>
                </td>
            </tr>
        </tbody>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="moveSouthButton" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="moveNorthButton" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="moveWestButton" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="moveEastButton" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="centerButton" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>
