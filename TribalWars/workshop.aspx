<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true"
    CodeFile="workshop.aspx.cs" Inherits="workshop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
<asp:Panel ID="pNotConstruct" runat="server" Visible="false">
        <h1>Công trình chưa được xây dựng</h1>
    </asp:Panel>
    <asp:Panel ID="pConstructed" runat="server" Visible="false">
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="images/garage2.png" title="Stable" alt="">
                </td>
                <td>
                    <h2>
                        Nhà xe cấp&nbsp;
                        <% Response.Write(this.village.VillageBuildingData.Workshop); %></h2>
                    Là nơi xây dựng các công trình quân sự dùng công phá tường thành, công trình 
                    thành phố đối phương&nbsp;
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <br />
    <asp:Label ID="lblError" runat="server" Font-Size="14pt" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <asp:Repeater runat="server" ID="rCarRecruits">
        <HeaderTemplate>
            <table class="vis">
        <tbody>
            <tr>
                <th width="150">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:text, training %>" />
                </th>
                <th width="120">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:text, duration %>" />
                </th>
                <th width="300">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:text, completion %>" />
                </th>
                <th width="120">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:text, cancel %>" />
                </th>
            </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
        <ItemTemplate>
            <tr class='lit'>
                <td>
                    <%# Eval("Quantity") %> <%# TroopTypeString((beans.TroopType)Eval("Troop")) %>
                </td>
                <td>
                    <span <%# this.FirstRow(Container.ItemIndex) %>><%# this.FirstRowTime(Container.ItemIndex, (beans.Recruit)Container.DataItem)%></span>
                </td>
                <td>
                    <%# ((DateTime)Eval("FinishTime")).ToString("HH:mm:ss 'ngày' dd/MM/yyyy")%>
                </td>
                <td>
                    <a href="barrack.aspx?id=<% = this.village.ID %>&mode=cancel_recruit&recruit_id=<%# Eval("ID") %>">Huỷ</a>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <table class="vis">
        <tbody>
            <tr>
                <th width="190">
                    Đơn vị quân</th>
                <th colspan="4" width="200">
                    Chi phí</th>
                <th width="120">
                    Thời gian
                </th>
                <th>
                    Trong thành/tổng số
                </th>
                <th>
                    Số lượng
                </th>
            </tr>
            <tr class="row_a">
                <td>
                    <a href="javascript:popup_scroll('popup_unit.php?unit=spy', 520, 520)">
                        <img src="images/unit_ram.png" alt=""> Xe phá thành</a>
                </td>
                <td class="nowrap">
                    <img src="images/holz.png" title="Wood" alt=""> 300
                </td>
                <td class="nowrap">
                    <img src="images/lehm.png" title="Clay" alt=""> 200
                </td>
                <td class="nowrap">
                    <img src="images/eisen.png" title="Iron" alt="">
                    200
                </td>
                <td class="nowrap">
                    <img src="images/face.png" title="Villagers" alt=""> 5
                </td>
                <td>
                    0:03:08
                </td>
                <td>
                    <% Response.Write(this.village.VillageTroopData.Ram.ToString()); %>/<%Response.Write(this.village.VillageTroopData.RamOfVillage.ToString()); %>
                </td>
                <td>
                    <asp:TextBox ID="txtRam" runat="server" Width="33px"></asp:TextBox>
                    &nbsp;(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.txtRam.ClientID); %>', <% Response.Write(this.village.VillageRecruitMethods.MaxRecruit(beans.TroopType.Ram)); %>)"><%Response.Write(this.village.VillageRecruitMethods.MaxRecruit(beans.TroopType.Ram)); %></a>)
                </td>
            </tr>
            <tr class="row_a">
                <td>
                    <a href="javascript:popup_scroll('popup_unit.php?unit=light', 520, 520)">
                        <img src="images/unit_catapult.png" alt=""> Xe bắn đá</a>
                </td>
                <td class="nowrap">
                    <img src="images/holz.png" title="Wood" alt="">
                    320
                </td>
                <td class="nowrap">
                    <img src="images/lehm.png" title="Clay" alt=""> 400
                </td>
                <td class="nowrap">
                    <img src="images/eisen.png" title="Iron" alt=""> 100
                </td>
                <td class="nowrap">
                    <img src="images/face.png" title="Villagers" alt=""> 8</td>
                <td>
                    0:06:15
                </td>
                <td>
                    <% Response.Write(this.village.VillageTroopData.Catapult.ToString()); %>/<%Response.Write(this.village.VillageTroopData.CatapultOfVillage.ToString()); %>
                </td>
                <td>
                    <asp:TextBox ID="txtCatapult" runat="server" Width="33px"></asp:TextBox>
                    &nbsp;(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.txtCatapult.ClientID); %>', <% Response.Write(this.village.VillageRecruitMethods.MaxRecruit(beans.TroopType.Catapult)); %>)"><%Response.Write(this.village.VillageRecruitMethods.MaxRecruit(beans.TroopType.Catapult)); %></a>)
                </td>
            </tr>
            <tr>
                <td colspan="8" align="right">
                    <asp:Button ID="bttnRecruit" runat="server" Font-Size="10pt" Text="Huấn luyện" 
                        OnClick="bttnRecruit_Click" />
                    &nbsp;
                </td>
            </tr>
        </tbody>
    </table>
    </asp:Panel>
</asp:Content>
