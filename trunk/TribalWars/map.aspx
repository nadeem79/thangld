<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="map.aspx.cs"
    Inherits="map" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" RelativeTo="Element"
            Position="BottomCenter" AutoTooltipify="true" ContentScrolling="Default">
    </telerik:RadToolTipManager>
    

    <h2>Bản đồ
    </h2>
    <table>
        <tbody>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <table>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Table ID="tbVillages" runat="server" CssClass="table_map" CellPadding="0" CellSpacing="0" >
                                </asp:Table>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </tbody>
    </table>

    
</asp:Content>
