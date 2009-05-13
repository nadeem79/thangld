<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true"
    CodeFile="smithy.aspx.cs" Inherits="smithy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="images/smith3.png" title="Smithy" alt="">
                </td>
                <td>
                    <h2>
                        Viện nghiên cứu cấp
                        <% = this.Village[beans.BuildingType.Smithy] %></h2>
                    In the smithy you can research and improve weapons. Upgrading the smithy allows
                    the research of better weapons and decreases the research time.
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <asp:Repeater ID="researches" runat="server">
        <HeaderTemplate>
            <table class="vis">
                <tbody>
                    <tr><th>Nâng cấp</th>
                    <th>Còn lại</th>
                    <th>Hoàn thành trong</th>
                    <th>Huỷ</th></tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# this.TroopToString((beans.TroopType)DataBinder.Eval(Container.DataItem, "Type")) %></td>
                <td><span class="timer"><%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "End") - DateTime.Now) %></span></td>
                <td><%# ((DateTime)DataBinder.Eval(Container.DataItem, "End")).ToString("'lúc' HH:mm:ss 'ngày' dd/MM/yyyy") %></td>
                <td><asp:LinkButton ID="bttnCancel" runat="server" CommandArgument=<%# DataBinder.Eval(Container.DataItem, "ID").ToString() %> OnClick="bttnCancelResearch_Click">Huỷ</asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <table class="vis" width="100%">
        <tbody>
            <tr>
                <th width="33%">
                    infantry
                </th>
                <th width="33%">
                    Cavalry
                </th>
                <th width="33%">
                    Siege weapons
                </th>
            </tr>
            <tr>
                <td>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Image ID="imgSpear" runat="server" />
                                </td>
                                <td valign="top">
                                    <a href="javascript:popup_scroll('popup_unit.php?unit=spear&amp;level=1', 520, 520)">
                                        Lính giáo</a>
                                    <br>
                                    <img src="images/holz.png" />
                                    <% = this.Spear.Wood %>
                                    <img src="images/lehm.png" />
                                    <% = this.Spear.Clay %>
                                    <img src="images/eisen.png" />
                                    <% = this.Spear.Iron %><br />
                                    Thời gian:
                                    <% = Functions.FormatTime(this.Spear.Time) %>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="bttnUpgradeSpear" runat="server" 
                                                onclick="bttnUpgradeSpear_Click">Nâng cấp</asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="bttnUpgradeSpear" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <td>
                                    &nbsp;<asp:Image ID="imgScout" runat="server" />
                                </td>
                                <td valign="top">
                                    <a href="javascript:popup_scroll('popup_unit.php?unit=spy&amp;level=1', 520, 520)">Điệp
                                        viên</a>
                                    <br>
                                    <img src="images/holz.png" />
                                    <% = this.Scout.Wood %>
                                    <img src="images/lehm.png" />
                                    <% = this.Scout.Clay %>
                                    <img src="images/eisen.png" />
                                    <% = this.Scout.Iron %><br />
                                    Thời gian:
                                    <% = Functions.FormatTime(this.Scout.Time) %>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="bttnUpgradeScout" runat="server" OnClick="LinkButton1_Click">Nâng cấp</asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="bttnUpgradeScout" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <td>
                                    &nbsp;<asp:Image ID="imgRam" runat="server" />
                                </td>
                                <td valign="top">
                                    <a href="javascript:popup_scroll('popup_unit.php?unit=ram&amp;level=1', 520, 520)">Xe
                                        phá thành</a>
                                    <br>
                                    <img src="images/holz.png" />
                                    <% = this.Ram.Wood %>
                                    <img src="images/lehm.png" />
                                    <% = this.Ram.Clay %>
                                    <img src="images/eisen.png" />
                                    <% = this.Ram.Iron %><br />
                                    Thời gian:
                                    <% = Functions.FormatTime(this.Ram.Time) %>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="bttnUpgradeRam" runat="server" 
                                                onclick="bttnUpgradeRam_Click">Nâng cấp</asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="bttnUpgradeRam" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <td>
                                    &nbsp;<asp:Image ID="imgSword" runat="server" />
                                </td>
                                <td valign="top">
                                    <a href="javascript:popup_scroll('popup_unit.php?unit=sword&amp;level=1', 520, 520)">
                                        Lính kiếm</a>
                                    <br>
                                    <img src="images/holz.png" />
                                    <% = this.Sword.Wood %>
                                    <img src="images/lehm.png" />
                                    <% = this.Sword.Clay %>
                                    <img src="images/eisen.png" />
                                    <% = this.Sword.Iron %><br />
                                    Thời gian:
                                    <% = Functions.FormatTime(this.Sword.Time) %>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="bttnUpgradeSword" runat="server" 
                                                onclick="bttnUpgradeSword_Click">Nâng cấp</asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="bttnUpgradeSword" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <td>
                                    &nbsp;<asp:Image ID="imgLight" runat="server" />
                                </td>
                                <td valign="top">
                                    <a href="javascript:popup_scroll('popup_unit.php?unit=light&amp;level=1', 520, 520)">
                                        Kỵ binh</a>
                                    <br>
                                    <img src="images/holz.png" />
                                    <% = this.Light.Wood %>
                                    <img src="images/lehm.png" />
                                    <% = this.Light.Clay %>
                                    <img src="images/eisen.png" />
                                    <% = this.Light.Iron %><br />
                                    Thời gian:
                                    <% = Functions.FormatTime(this.Light.Time) %>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="bttnUpgradeLight" runat="server" 
                                                onclick="bttnUpgradeLight_Click">Nâng cấp</asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="bttnUpgradeLight" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <td>
                                    &nbsp;<asp:Image ID="imgCatapult" runat="server" />
                                </td>
                                <td valign="top">
                                    <a href="javascript:popup_scroll('popup_unit.php?unit=catapult&amp;level=1', 520, 520)">
                                        Máy bắn đá</a>
                                    <br>
                                    <img src="images/holz.png" />
                                    <% = this.Catapult.Wood %>
                                    <img src="images/lehm.png" />
                                    <% = this.Catapult.Clay %>
                                    <img src="images/eisen.png" />
                                    <% = this.Catapult.Iron %><br />
                                    Thời gian:
                                    <% = Functions.FormatTime(this.Catapult.Time) %>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="bttnUpgradeCatapult" runat="server" 
                                                onclick="bttnUpgradeCatapult_Click">Nâng cấp</asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="bttnUpgradeCatapult" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <td>
                                    &nbsp;<asp:Image ID="imgAxe" runat="server" />
                                </td>
                                <td valign="top">
                                    <a href="javascript:popup_scroll('popup_unit.php?unit=axe&amp;level=1', 520, 520)">Lính
                                        rìu</a>
                                    <br>
                                    <img src="images/holz.png" />
                                    <% = this.Axe.Wood %>
                                    <img src="images/lehm.png" />
                                    <% = this.Axe.Clay %>
                                    <img src="images/eisen.png" />
                                    <% = this.Axe.Iron %><br />
                                    Thời gian:
                                    <% = Functions.FormatTime(this.Axe.Time) %>
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="bttnUpgradeAxe" runat="server" 
                                                onclick="bttnUpgradeAxe_Click">Nâng cấp</asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="bttnUpgradeAxe" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <td>
                                    &nbsp;<asp:Image ID="imgHeavy" runat="server" />
                                </td>
                                <td valign="top">
                                    <a href="javascript:popup_scroll('popup_unit.php?unit=heavy&amp;level=1', 520, 520)">
                                        Hiệp sỹ</a>
                                    <br>
                                    <img src="images/holz.png" />
                                    <% = this.Heavy.Wood %>
                                    <img src="images/lehm.png" />
                                    <% = this.Heavy.Clay%>
                                    <img src="images/eisen.png" />
                                    <% = this.Heavy.Iron%><br />
                                    Thời gian:
                                    <% = Functions.FormatTime(this.Heavy.Time)%>
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="bttnUpgradeHeavy" runat="server" 
                                                onclick="bttnUpgradeHeavy_Click">Nâng cấp</asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="bttnUpgradeHeavy" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
