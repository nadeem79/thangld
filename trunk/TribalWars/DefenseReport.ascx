<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefenseReport.ascx.cs" Inherits="DefenseReport" %>
<h3>
    <% = (DefenseReportEntity.SuccessAttack) ? DefenseReportEntity.FromPlayer.Username : DefenseReportEntity.ToPlayer.Username %>
    thắng trận</h3>
May mắn (phía tấn công):
<% = (DefenseReportEntity.Luck*100).ToString("00") %> %
<br />
<br />
<table style="border: 1px solid rgb(222, 211, 185);" width="100%">
    <tbody>
        <tr>
            <th width="100">
                Tấn công:
            </th>
            <th>
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = DefenseReportEntity.FromPlayer.ID %>'>
                    <% = DefenseReportEntity.FromPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.DefenseReportEntity.FromVillage.ID %>'>
                    <% = this.DefenseReportEntity.FromVillage.Name %>
                    (<% = this.DefenseReportEntity.FromVillage.X.ToString("000") %>|<% = this.DefenseReportEntity.FromVillage.Y.ToString("000") %>)</a>
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
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.SpearSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.SwordSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.AxeSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.ScoutSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.LightCavalrySent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.HeavyCavalrySent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.RamSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.CatapultSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.NobleSent) %>
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Tổn thất:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.SpearAttackDead) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.SwordAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.AxeAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.ScoutAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.LightCavalryAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.HeavyCavalryAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.RamAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.CatapultAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.NobleAttackDead)%>
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
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.DefenseReportEntity.ToPlayer.ID %>'>
                    <% = this.DefenseReportEntity.ToPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.DefenseReportEntity.ToVillage.ID %>'>
                    <% = this.DefenseReportEntity.ToVillage.Name %>
                    (<% = this.DefenseReportEntity.ToVillage.X.ToString("000") %>|<% = this.DefenseReportEntity.ToVillage.Y.ToString("000") %>)</a>
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
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.SpearDefense) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.SwordDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.AxeDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.ScoutDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.LightCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.HeavyCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.RamDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.CatapultDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.NobleDefense)%>
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Thiệt hại:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.SpearDefenseDead) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.SwordDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.AxeDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.ScoutDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.LightCavalryDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.HeavyCavalryDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.RamDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.CatapultDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseReportEntity.NobleDefenseDead)%>
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
            <% = this.DefenseReportEntity.Clay %></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="float: left;margin-left:5px;">
        <asp:Panel runat="server" ID="pWood">
            <img src="images/resources/wood.png" title="Wood" />
            <% = this.DefenseReportEntity.Wood %></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="float: left;margin-left:5px;">
        <asp:Panel runat="server" ID="pIron">
            <img src="images/resources/iron.png" title="Iron" />
            <% = this.DefenseReportEntity.Iron %></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="clear: both">
    </div>
</asp:Panel>
