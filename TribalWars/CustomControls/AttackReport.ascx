<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttackReport.ascx.cs"
    Inherits="CustomControls_AttackReport" %>
<h3>
    <% = (AttackReport.SuccessAttack) ? AttackReport.FromPlayer.Username : AttackReport.ToPlayer.Username %>
    thắng trận</h3>
May mắn (phía tấn công):
<% = AttackReport.Luck.ToString("0.00") %>
<br />
<br />
<table style="border: 1px solid rgb(222, 211, 185);" width="100%">
    <tbody>
        <tr>
            <th width="100">
                Tấn công:
            </th>
            <th>
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = AttackReport.FromPlayer.ID %>'>
                    <% = AttackReport.FromPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.AttackReport.FromVillage.ID %>'>
                    <% = this.AttackReport.FromVillage.Name %>
                    (<% = this.AttackReport.FromVillage.X.ToString("000") %>|<% = this.AttackReport.FromVillage.Y.ToString("000") %>)</a>
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
                                <% = Functions.GetTroopQuantity(this.AttackReport.SpearSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.SwordSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.AxeSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.ScoutSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.LightCavalrySent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.HeavyCavalrySent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.RamSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.CatapultSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.NobleSent) %>
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Tổn thất:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.SpearAttackDead) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.SwordAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.AxeAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.ScoutAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.LightCavalryAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.HeavyCavalryAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.RamAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.CatapultAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.NobleAttackDead)%>
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
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.AttackReport.ToPlayer.ID %>'>
                    <% = this.AttackReport.ToPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.AttackReport.ToVillage.ID %>'>
                    <% = this.AttackReport.ToVillage.Name %>
                    (<% = this.AttackReport.ToVillage.X.ToString("000") %>|<% = this.AttackReport.ToVillage.Y.ToString("000") %>)</a>
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
                                <% = Functions.GetTroopQuantity(this.AttackReport.SpearDefense) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.SwordDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.AxeDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.ScoutDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.LightCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.HeavyCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.RamDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.CatapultDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.NobleDefense)%>
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Thiệt hại:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.SpearDefenseDead) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.SwordDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.AxeDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.ScoutDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.LightCavalryDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.HeavyCavalryDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.RamDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.CatapultDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReport.NobleDefenseDead)%>
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
            <% = this.AttackReport.Clay %></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="float: left;margin-left:5px;">
        <asp:Panel runat="server" ID="pWood">
            <img src="images/resources/wood.png" title="Wood" />
            <% = this.AttackReport.Wood %></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="float: left;margin-left:5px;">
        <asp:Panel runat="server" ID="pIron">
            <img src="images/resources/iron.png" title="Iron" />
            <% = this.AttackReport.Iron %></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="clear: both">
    </div>
</asp:Panel>
