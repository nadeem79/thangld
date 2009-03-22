<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="rally.aspx.cs"
    Inherits="rally" Title="Medieval War - Trại Lính" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="images/place1.png" title="Rally point" alt="">
                </td>
                <td>
                    <h2>
                        Trại lính Cấp 1</h2>
                    Nơi tập trung, điều khiển và theo dõi tình hình quân sự
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <table width="100%">
        <tbody>
            <tr>
                <td valign="top" width="100">
                    <table class="vis" width="100%">
                        <tbody>
                            <tr>
                                <td class="selected" width="100">
                                    <a href="rally.aspx?id=<% Response.Write(this.village.ID.ToString()); %>">Đặt lệnh</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="/game.php?village=64454&amp;screen=place&amp;mode=units">Troops</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="/game.php?village=64454&amp;screen=place&amp;mode=sim">Simulator</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top" width="*">
                    <asp:Label ID="lblError" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                    <h3>
                        Đặt lệnh</h3>
                    <table>
                        <tbody>
                            <tr>
                                <td valign="top" width="150">
                                    <table class="vis" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    
                                                        <img src="images/unit_spear.png" title="Spear fighter" alt=""> <asp:TextBox
                                                            ID="spear" runat="server" Width="33px"></asp:TextBox>
                                                        &nbsp;<span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.spear.ClientID); %>', <% Response.Write(this.village.Spear.ToString()); %>)"><% Response.Write(this.village.Spear.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    
                                                        <img src="images/unit_sword.png" title="Swordsman" alt="">
                                                    <asp:TextBox ID="sword" runat="server" Width="33px"></asp:TextBox>
                                                    &nbsp;<span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.sword.ClientID); %>', <% Response.Write(this.village.Sword.ToString()); %>)"><% Response.Write(this.village.Sword.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    
                                                        <img src="images/unit_axe.png" title="Axeman" alt="" />
                                                    <asp:TextBox ID="axe" runat="server" Width="33px"></asp:TextBox>
                                                    &nbsp;<span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.axe.ClientID); %>', <% Response.Write(this.village.Axe.ToString()); %>)"><% Response.Write(this.village.Axe.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td valign="top" width="150">
                                    <table class="vis" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    
                                                        <img src="images/unit_spy.png" title="Scout" alt="">
                                                    <asp:TextBox ID="scout" runat="server" Width="33px"></asp:TextBox>
                                                    &nbsp;<span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.scout.ClientID); %>', <% Response.Write(this.village.Scout.ToString()); %>)"><% Response.Write(this.village.Scout.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    
                                                        <img src="images/unit_light.png" title="Light cavalry" alt="">
                                                    <asp:TextBox ID="light" runat="server" Width="33px"></asp:TextBox>
                                                    &nbsp;<span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.light.ClientID); %>', <% Response.Write(this.village.Light.ToString()); %>)"><% Response.Write(this.village.Light.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    
                                                        <img src="images/unit_heavy.png" title="Heavy cavalry" alt="">
                                                    <asp:TextBox ID="heavy" runat="server" Width="33px"></asp:TextBox>
                                                    &nbsp;<span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.heavy.ClientID); %>', <% Response.Write(this.village.Heavy.ToString()); %>)"><% Response.Write(this.village.Heavy.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td valign="top" width="150">
                                    <table class="vis" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    
                                                        <img src="images/unit_ram.png" title="Ram" alt="">
                                                    <asp:TextBox ID="ram" runat="server" Width="33px"></asp:TextBox>
                                                    &nbsp;<span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.ram.ClientID); %>', <% Response.Write(this.village.Ram.ToString()); %>)"><% Response.Write(this.village.Ram.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    
                                                        <img src="images/unit_catapult.png" title="Catapult" alt="">
                                                    <asp:TextBox ID="catapult" runat="server" Width="33px"></asp:TextBox>
                                                    &nbsp;<span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.catapult.ClientID); %>', <% Response.Write(this.village.Catapult.ToString()); %>)"><% Response.Write(this.village.Catapult.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td valign="top" width="150">
                                    <table class="vis" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    
                                                        <img src="images/unit_snob.png" title="Nobleman" alt="">
                                                    <asp:TextBox ID="noble" runat="server" Width="33px"></asp:TextBox>
                                                    &nbsp;<span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.noble.ClientID); %>', <% Response.Write(this.village.Noble.ToString()); %>)"><% Response.Write(this.village.Noble.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    
                    <table>
                        <tbody>
                            <tr>
                                <td rowspan="2">
                                    x:
                                    <asp:TextBox ID="x" runat="server" Width="33px"></asp:TextBox>
                                    &nbsp;y:
                                    <asp:TextBox ID="y" runat="server" Width="33px"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    
                                </td>
                                <td valign="top">
                                </td>
                                <td rowspan="2">
                                    <asp:Button ID="bttnAttack" runat="server" CssClass="attack" Font-Size="10pt" 
                                        Text="Attack" onclick="bttnAttack_Click" />
                                    &nbsp;
                                </td>
                                <td rowspan="2">
                                    <asp:Button ID="bttnSupport" runat="server" CssClass="support" Font-Size="10pt" 
                                        Text="Support" onclick="bttnSupport_Click" />
                                    &nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>

                    <h3>
                        Troop movements</h3>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <th width="250">
                                    Lệnh đến: 
                                </th>
                                <th width="160">
                                    Thời gian
                                </th>
                                <th width="100">
                                    Cập nhật trong
                                </th>
                            </tr>
                            <asp:Label ID="lblInwardsCommand" runat="server"></asp:Label>
                        </tbody>
                    </table>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <th width="250">
                                    Lệnh đi: 
                                </th>
                                <th width="160">
                                    Thời gian
                                </th>
                                <th width="100">
                                    Cập nhật trong
                                </th>
                            </tr>
                            <asp:Label ID="lblOutwardsCommand" runat="server"></asp:Label>
                        </tbody>
                    </table>
                    <br/>
                    
                </td>
            </tr>
        </tbody>
    </table>
    <div id="abc"></div>
    
</asp:Content>
