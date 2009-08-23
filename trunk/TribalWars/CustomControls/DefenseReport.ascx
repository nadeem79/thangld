<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefenseReport.ascx.cs" Inherits="CustomControls_DefenseReport" %>
<h3>
    <% = (DefenseReport.SuccessAttack) ? DefenseReport.FromPlayer.Username : DefenseReport.ToPlayer.Username %>
    thắng trận</h3>
May mắn (phía tấn công):
<% = DefenseReport.Luck.ToString("0.00") %>
<br />
<br />
<table style="border: 1px solid rgb(222, 211, 185);" width="100%">
    <tbody>
        <tr>
            <th width="100">
                Tấn công:
            </th>
            <th>
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = DefenseReport.FromPlayer.ID %>'>
                    <% = DefenseReport.FromPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.DefenseReport.FromVillage.ID %>'>
                    <% = this.DefenseReport.FromVillage.Name %>
                    (<% = this.DefenseReport.FromVillage.X.ToString("000") %>|<% = this.DefenseReport.FromVillage.Y.ToString("000") %>)</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="vis">
                    <tbody>
                        <tr class="center">
                            <td>
                            </td>
                            <td width="35">
                                <img src="images/unit_spear.png" title="Spear fighter" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_sword.png" title="Swordsman" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_axe.png" title="Axeman" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_spy.png" title="Scout" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_light.png" title="Light cavalry" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_heavy.png" title="Heavy cavalry" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_ram.png" title="Ram" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_catapult.png" title="Catapult" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_snob.png" title="Nobleman" alt="">
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Số lượng:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.SpearSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.SwordSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.AxeSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.ScoutSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.LightCavalrySent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.HeavyCavalrySent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.RamSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.CatapultSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.NobleSent) %>
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Tổn thất:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.SpearAttackDead) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.SwordAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.AxeAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.ScoutAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.LightCavalryAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.HeavyCavalryAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.RamAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.CatapultAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.NobleAttackDead)%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </tbody>
</table>
<br>
<table style="border: 1px solid rgb(222, 211, 185);" width="100%">
    <tbody>
        <tr>
            <th width="100">
                Phòng thủ:
            </th>
            <th>
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.DefenseReport.ToPlayer.ID %>'>
                    <% = this.DefenseReport.ToPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.DefenseReport.ToVillage.ID %>'>
                    <% = this.DefenseReport.ToVillage.Name %>
                    (<% = this.DefenseReport.ToVillage.X.ToString("000") %>|<% = this.DefenseReport.ToVillage.Y.ToString("000") %>)</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="vis">
                    <tbody>
                        <tr class="center">
                            <td>
                            </td>
                            <td width="35">
                                <img src="images/unit_spear.png" title="Spear fighter" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_sword.png" title="Swordsman" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_axe.png" title="Axeman" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_spy.png" title="Scout" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_light.png" title="Light cavalry" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_heavy.png" title="Heavy cavalry" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_ram.png" title="Ram" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_catapult.png" title="Catapult" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_snob.png" title="Nobleman" alt="">
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Số lượng:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.SpearDefense) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.SwordDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.AxeDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.ScoutDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.LightCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.HeavyCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.RamDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.CatapultDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.NobleDefense)%>
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Thiệt hại:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.SpearDefenseDead) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.SwordDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.AxeDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.ScoutDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.LightCavalryDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.HeavyCavalryDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.RamDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.CatapultDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReport.NobleDefenseDead)%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
<br />
<asp:Panel runat="server" ID="pPillaged" Visible="false">
    <h5>
        Cướp bóc:</h5>
    <div style="float: left;">
        <asp:Panel runat="server" ID="pClay">
            <img src="images/resources/clay.png" title="Clay" />
            <% = this.DefenseReport.Clay %></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="float: left;margin-left:5px;">
        <asp:Panel runat="server" ID="pWood">
            <img src="images/resources/wood.png" title="Wood" />
            <% = this.DefenseReport.Wood %></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="float: left;margin-left:5px;">
        <asp:Panel runat="server" ID="pIron">
            <img src="images/resources/iron.png" title="Iron" />
            <% = this.DefenseReport.Iron %></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="clear: both">
    </div>
</asp:Panel>
