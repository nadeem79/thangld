<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="village.aspx.cs"
    Inherits="village" Title="Medieval War - Thành phố" %>
    <%@ Reference Control="GraphicVillageInfo.ascx" %>
    <%@ Reference Control="TextVillageInfo.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <span id="test"></span>
    <h2>
        Thành phố
        <% Response.Write(this.current.Name); %></h2>
    <table>
        <tr>
            <td width="450" valign="top">
                <asp:PlaceHolder ID="pVillageInfo" runat="server"></asp:PlaceHolder>
            </td>
            <td valign="top">
                <table class="vis" width="100%">
                    <tr>
                        <th colspan="2">
                            Năng suất
                        </th>
                    </tr>
                    <tr class="nowrap">
                        <td width="70">
                            <img src="images/holz.png" title="Wood" alt="" />
                            Gỗ
                        </td>
                        <td>
                            <strong>
                                <% Response.Write(this.current.ProductPerHour(beans.ResourcesType.Wood).ToString()); %></strong>
                            mỗi giờ
                        </td>
                    </tr>
                    <tr class="nowrap">
                        <td>
                            <img src="images/lehm.png" title="Clay" alt="" />
                            Gạch
                        </td>
                        <td>
                            <strong>
                                <% Response.Write(this.current.ProductPerHour(beans.ResourcesType.Clay).ToString()); %></strong>
                            mỗi giờ
                        </td>
                    </tr>
                    <asp:Label ID="lbl123" runat="server"></asp:Label>
                    <tr class="nowrap">
                        <td>
                            <img src="images/eisen.png" title="Iron" alt="" />
                            Kim loại
                        </td>
                        <td>
                            <strong>
                                <% Response.Write(this.current.ProductPerHour(beans.ResourcesType.Iron).ToString()); %></strong>
                            mỗi giờ
                        </td>
                    </tr>
                </table>
                <br />
                <table class="vis" width="100%">
                    <tr>
                        <th>
                            Units
                        </th>
                    </tr>
                    <asp:Label ID="lblTroops" runat="server"></asp:Label>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
