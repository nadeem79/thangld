<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true"
    CodeFile="warehouse.aspx.cs" Inherits="warehouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="images/big_buildings/storage3.png" title="Warehouse" alt="">
                </td>
                <td>
                    <h2>
                        Warehouse Level
                        <% = this.Village[beans.BuildingType.Warehouse] %></h2>
                    The warehouse stores your resources. The higher its level the more resources can
                    be stored.
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <table>
        <tbody>
            <tr>
                <td width="220">
                    Current storage capacity
                </td>
                <td>
                    <b>
                        <% = this.Village.MaxResources %></b> units per resource
                </td>
            </tr>
            <tr>
                <td>
                    Storage capacity on level 29
                </td>
                <td>
                    <b>
                        <% = (int)(this.Village.MaxResources + this.Village.MaxResources * 0.3)%></b>
                    units per resource
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <table class="vis">
        <tbody>
            <tr>
                <th width="150">
                    Warehouse full
                </th>
                <th>
                    Time (hh:mm:ss)
                </th>
            </tr>
            <tr>
                <td width="250">
                    <img src="images/holz.png" title="Wood" alt="" />
                    <% = (DateTime.Now + TimeSpan.FromSeconds(this.Village.VillageResourceMethods.TimeTillFullWarehouse(DateTime.Now, beans.ResourcesType.Wood))).ToString("'ngày' dd/MM/yyyy 'lúc' HH:mm:ss") %>
                </td>
                <td>
                    <span class="timer">
                        <% = Functions.FormatTime(this.Village.VillageResourceMethods.TimeTillFullWarehouse(DateTime.Now, beans.ResourcesType.Wood))%></span>
                </td>
            </tr>
            <tr>
                <td width="250">
                    <img src="images/lehm.png" title="Clay" alt="" />
                    <% = (DateTime.Now + TimeSpan.FromSeconds(this.Village.VillageResourceMethods.TimeTillFullWarehouse(DateTime.Now, beans.ResourcesType.Clay))).ToString("'ngày' dd/MM/yyyy 'lúc' HH:mm:ss")%>
                </td>
                <td>
                    <span class="timer">
                        <% = Functions.FormatTime(this.Village.VillageResourceMethods.TimeTillFullWarehouse(DateTime.Now, beans.ResourcesType.Clay))%></span>
                </td>
            </tr>
            <tr>
                <td width="250">
                    <img src="images/eisen.png" title="Iron" alt="" />
                    <% = (DateTime.Now + TimeSpan.FromSeconds(this.Village.VillageResourceMethods.TimeTillFullWarehouse(DateTime.Now, beans.ResourcesType.Iron))).ToString("'ngày' dd/MM/yyyy 'lúc' HH:mm:ss")%>
                </td>
                <td>
                    <span class="timer">
                        <% = Functions.FormatTime(this.Village.VillageResourceMethods.TimeTillFullWarehouse(DateTime.Now, beans.ResourcesType.Iron))%></span>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
