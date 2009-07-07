<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MerchantStatus.ascx.cs"
    Inherits="CustomControls_MerchantStatus" %>
<h4>
    Merchant status</h4>
<p>
    Here you can see what your Merchants are doing at the moment.</p>
<table class="vis">
    <tbody>
        <tr>
            <td width="320">
                Số thương nhân đang chuyển hàng
            </td>
            <td align="right" width="60">
                <asp:Label ID="lblMerchantOnTheWay" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Thương nhân đang quay về
            </td>
            <td align="right">
                <asp:Label ID="lblMerchantOnTheWayHome" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Tổng số thương nhân
            </td>
            <td align="right">
                <b><% = this.Village.VillageBuildingData.Merchant %></b>
            </td>
        </tr>
    </tbody>
</table>
