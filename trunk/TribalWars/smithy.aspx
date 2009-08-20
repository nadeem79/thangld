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
    <asp:Repeater ID="rptResearches" runat="server">
        <HeaderTemplate>
            <table class="vis">
                <tbody>
                    <tr>
                        <th>
                            Nâng cấp
                        </th>
                        <th>
                            Còn lại
                        </th>
                        <th>
                            Hoàn thành trong
                        </th>
                        <th>
                            Huỷ
                        </th>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# this.ResearchToString((beans.ResearchType)Eval("Type")) %>
                    level
                    <%# Eval("Level") %>
                </td>
                <td>
                    <span <%# this.FirstRow(Container.ItemIndex)%>>
                        <%# Functions.FormatTime((DateTime)Eval("End") - DateTime.Now) %></span>
                </td>
                <td>
                    <%# ((DateTime)Eval("End")).ToString("'lúc' HH:mm:ss 'ngày' dd/MM/yyyy") %>
                </td>
                <td>
                    <asp:LinkButton ID="bttnCancel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID").ToString() %>'
                        OnClick="bttnCancelResearch_Click">Huỷ</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <table class="vis" width="100%">
        <tbody>
            <tr>
                <th width="220">
                    Upgrade
                </th>
                <th colspan="3">
                    Requirements
                </th>
                <th width="100">
                    Construction time(hh:mm:ss)
                </th>
                <th style="width: 200px;">
                    Construct
                </th>
            </tr>
            <tr>
                <td>
                    Upgrade attack to level
                    <% = this.AttackPrice.Level %>
                </td>
                <td>
                    <img src="images/resources/wood.png" title="Wood" alt="Wood" />
                    <% = this.AttackPrice.Wood %>
                    </td>
                    <td>
                    <img src="images/resources/clay.png" title="Clay" alt="Clay" />
                    <% = this.AttackPrice.Clay %>
                    </td><td>
                    <img src="images/resources/iron.png" title="Iron" alt="Iron" />
                    <% = this.AttackPrice.Iron %></td>
                <td>
                    <% = Functions.FormatTime(this.AttackPrice.Time) %>
                </td>
                <td>
                    <span class="hidden">
                        <asp:Literal runat="server" ID="cannotUpgradeAttack" Visible="false">Thiếu tài nguyên</asp:Literal></span>
                    <asp:UpdatePanel runat="server" ID="panelUpgradeAttack">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="bttnUpgradeAttack" Text="Nâng cấp" 
                                OnClick="bttnUpgradeAttack_Click">Nâng cấp</asp:LinkButton>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="bttnUpgradeAttack" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    Upgrade attack to level
                    <% = this.DefensePrice.Level %>
                </td>
                <td>
                    <img src="images/resources/wood.png" title="Wood" alt="Wood" />
                    <% = this.DefensePrice.Wood%></td>
                    <td><img src="images/resources/clay.png" title="Clay" alt="Clay" />
                    <% = this.DefensePrice.Clay%></td>
                    <td><img src="images/resources/iron.png" title="Iron" alt="Iron" />
                    <% = this.DefensePrice.Iron%>
                </td>
                <td>
                    <% = Functions.FormatTime(this.DefensePrice.Time) %>
                </td>
                <td>
                    <span class="hidden">
                        <asp:Literal runat="server" ID="cannotUpgradeDefense" Visible="false">Thiếu tài nguyên</asp:Literal></span>
                    <asp:UpdatePanel runat="server" ID="panelUpgradeDefense">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="bttnUpgradeDefense" Text="Nâng cấp" 
                                OnClick="bttnUpgradeDefense_Click">Nâng cấp</asp:LinkButton>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="bttnUpgradeDefense" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    Upgrade attack to level
                    <% = this.SpeedPrice.Level %>
                </td>
                <td>
                    <img src="images/resources/wood.png" title="Wood" alt="Wood" />
                    <% = this.SpeedPrice.Wood%></td>
                    <td><img src="images/resources/clay.png" title="Clay" alt="Clay" />
                    <% = this.SpeedPrice.Clay%></td>
                    <td><img src="images/resources/iron.png" title="Iron" alt="Iron" />
                    <% = this.SpeedPrice.Iron%>
                </td>
                <td>
                    <% = Functions.FormatTime(this.SpeedPrice.Time) %>
                </td>
                <td>
                    <span class="hidden">
                        <asp:Literal runat="server" ID="cannotUpgradeSpeed" Visible="false">Thiếu tài nguyên</asp:Literal></span>
                    <asp:UpdatePanel runat="server" ID="panelUpgradeSpeed">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="bttnUpgradeSpeed" Text="Nâng cấp" 
                                OnClick="bttnUpgradeSpeed_Click">Nâng cấp</asp:LinkButton>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="bttnUpgradeSpeed" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
