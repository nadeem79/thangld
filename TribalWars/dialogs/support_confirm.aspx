﻿<%@ Page Title="" Language="C#" MasterPageFile="~/dialogs/dialog_template.master"
    AutoEventWireup="true" CodeFile="support_confirm.aspx.cs" Inherits="dialogs_support_confirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #<% =this.pSendSupport.ClientID %>
        {
            float:left;
        }
        #<% =this.pCancelSupport.ClientID %>
        {
            float:left;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dialog" runat="Server">
    <asp:Panel ID="pNotFound" runat="server">
        <h2>
            Lỗi: Không tìm thấy lệnh</h2>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pFound" runat="server">
        <h2>
            Tấn công</h2>
        <table class="vis" width="300">
            <tbody>
                <tr>
                    <th colspan="2">
                        Đặt lệnh
                    </th>
                </tr>
                <tr>
                    <td>
                        Tấn công:
                    </td>
                    <td>
                        <a href="../village_info.aspx?player=<% = command.To.ID %><% = (object.Equals(Request["id"], null) ? "&id=" + Request["id"] : "") %>"
                            target="_blank">
                            <% = command.To.Name %></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Đối thủ:
                    </td>
                    <td>
                        <a href="../user_info.aspx?player=<% = command.To.Owner.ID %><% = (object.Equals(Request["id"], null) ? "&id=" + Request["id"] : "") %>">
                            <% = command.To.Owner.Username %></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Thời gian:
                    </td>
                    <td>
                        <% = Functions.FormatTime(command.LandingTime - command.StartTime)%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Đến lúc:
                    </td>
                    <td id="date_arrival">
                        <asp:Label ID="lblLandingTime" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ghi chú:
                    </td>
                    <td>
                        <asp:Label ID="lblNote" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
        <br>
        <table class="vis">
            <tbody>
                <tr>
                    <th width="50">
                        <img src="../images/unit_spear.png" title="Spear fighter" alt="" />
                    </th>
                    <th width="50">
                        <img src="../images/unit_sword.png" title="Swordsman" alt="">
                    </th>
                    <th width="50">
                        <img src="../images/unit_axe.png" title="Axeman" alt="" />
                    </th>
                    <th width="50">
                        <img src="../images/unit_spy.png" title="Scout" alt="" />
                    </th>
                    <th width="50">
                        <img src="../images/unit_light.png" title="Light cavalry" alt="" />
                    </th>
                    <th width="50">
                        <img src="../images/unit_heavy.png" title="Heavy cavalry" alt="" />
                    </th>
                    <th width="50">
                        <img src="../images/unit_ram.png" title="Ram" alt="" />
                    </th>
                    <th width="50">
                        <img src="../images/unit_catapult.png" title="Catapult" alt="" />
                    </th>
                    <th width="50">
                        <img src="../images/unit_snob.png" title="Nobleman" alt="" style="height: 18px; width: 18px" />
                    </th>
                </tr>
                <tr>
                    <td>
                        <span <% if (command.Spear == 0) Response.Write(" class='hidden'"); %>>
                            <% = command.Spear %></span>
                    </td>
                    <td>
                        <span <% if (command.Sword == 0) Response.Write(" class='hidden'"); %>>
                            <% = command.Sword %></span>
                    </td>
                    <td>
                        <span <% if (command.Axe == 0) Response.Write(" class='hidden'"); %>>
                            <% = command.Axe %></span>
                    </td>
                    <td>
                        <span <% if (command.Scout == 0) Response.Write(" class='hidden'"); %>>
                            <% = command.Scout %></span>
                    </td>
                    <td>
                        <span <% if (command.Light == 0) Response.Write(" class='hidden'"); %>>
                            <% = command.Light %></span>
                    </td>
                    <td>
                        <span <% if (command.Heavy == 0) Response.Write(" class='hidden'"); %>>
                            <% = command.Heavy %></span>
                    </td>
                    <td>
                        <span <% if (command.Ram == 0) Response.Write(" class='hidden'"); %>>
                            <% = command.Ram %></span>
                    </td>
                    <td>
                        <span <% if (command.Catapult == 0) Response.Write(" class='hidden'"); %>>
                            <% = command.Catapult %></span>
                    </td>
                    <td>
                        <span <% if (command.Noble == 0) Response.Write(" class='hidden'"); %>>
                            <% = command.Noble %></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="9">
                        <asp:UpdatePanel ID="pSendSupport" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="bttnSendSupport" runat="server" Text="OK" OnClick="bttnSendSupport_Click" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="bttnSendSupport" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="pCancelSupport" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="bttnCancelSupport" runat="server" Text="Huỷ" OnClick="bttnCancelSupport_Click" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="bttnCancelSupport" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>
