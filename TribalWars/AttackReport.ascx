<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttackReport.ascx.cs"
    Inherits="AttackReport" %>
<h3>
    <% = (AttackReportEntity.SuccessAttack) ? AttackReportEntity.FromPlayer.Username : AttackReportEntity.ToPlayer.Username %>
    thắng trận</h3>
May mắn (phía tấn công):
<% = (AttackReportEntity.Luck*100).ToString("00") %> %
<br />
<br />
<table style="border: 1px solid rgb(222, 211, 185);" width="100%">
    <tbody>
        <tr>
            <th width="100">
                Tấn công:
            </th>
            <th>
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = AttackReportEntity.FromPlayer.ID %>'>
                    <% = AttackReportEntity.FromPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.AttackReportEntity.FromVillage.ID %>'>
                    <% = this.AttackReportEntity.FromVillage.Name %>
                    (<% = this.AttackReportEntity.FromVillage.X.ToString("000") %>|<% = this.AttackReportEntity.FromVillage.Y.ToString("000") %>)</a>
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
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.SpearSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.SwordSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.AxeSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.ScoutSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.LightCavalrySent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.HeavyCavalrySent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.RamSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.CatapultSent) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.NobleSent) %>
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Tổn thất:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.SpearAttackDead) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.SwordAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.AxeAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.ScoutAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.LightCavalryAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.HeavyCavalryAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.RamAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.CatapultAttackDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.NobleAttackDead)%>
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
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.AttackReportEntity.ToPlayer.ID %>'>
                    <% = this.AttackReportEntity.ToPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.AttackReportEntity.ToVillage.ID %>'>
                    <% = this.AttackReportEntity.ToVillage.Name %>
                    (<% = this.AttackReportEntity.ToVillage.X.ToString("000") %>|<% = this.AttackReportEntity.ToVillage.Y.ToString("000") %>)</a>
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
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.SpearDefense) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.SwordDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.AxeDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.ScoutDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.LightCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.HeavyCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.RamDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.CatapultDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.NobleDefense)%>
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Thiệt hại:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.SpearDefenseDead) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.SwordDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.AxeDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.ScoutDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.LightCavalryDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.HeavyCavalryDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.RamDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.CatapultDefenseDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.AttackReportEntity.NobleDefenseDead)%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
<br />
<asp:Panel runat="server" ID="pWallDamaged">
    Tường bị phá từ level <b><% = this.AttackReportEntity.WallBefore %></b> xuống level <b><% = this.AttackReportEntity.WallAfter %></b>
</asp:Panel>
<asp:Panel runat="server" ID="pBuildingDamaged">
    Công trình <b><% = LanguageFunctions.BuildingToString(this.AttackReportEntity.Building) %></b> bị phá từ level <b><% = this.AttackReportEntity.BuildingBefore %></b> xuống level <b><% = this.AttackReportEntity.BuildingAfter %></b>
</asp:Panel>
<asp:Panel runat="server" ID="pPillaged" Visible="false">
    <h5>
        Cướp bóc:</h5>
    <div style="float: left;">
        <asp:Panel runat="server" ID="pClay">
            <img src="images/resources/clay.png" title="Clay" />
            <% = this.AttackReportEntity.Clay%></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="float: left;margin-left:5px;">
        <asp:Panel runat="server" ID="pWood">
            <img src="images/resources/wood.png" title="Wood" />
            <% = this.AttackReportEntity.Wood%></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="float: left;margin-left:5px;">
        <asp:Panel runat="server" ID="pIron">
            <img src="images/resources/iron.png" title="Iron" />
            <% = this.AttackReportEntity.Iron%></asp:Panel>
    </div> &nbsp;&nbsp;
    <div style="clear: both">
    </div>
</asp:Panel>
