<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TribeDiplomacy.ascx.cs"
    Inherits="TribeDiplomacy" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Vista" DecoratedControls="All" />
<p>
    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:text, diplomatic_description %>" /></p>
<table class="vis" width="300">
    <tbody>
        <tr>
            <th colspan="2">
                Đồng minh
            </th>
        </tr>
        <asp:Repeater ID="gvAllies" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <a href="tribe_info.aspx?id=<% =this.Village.ID %>&tribe=<%# DataBinder.Eval(Container.DataItem, "ID") %>">
                            <%# DataBinder.Eval(Container.DataItem, "Tag") %></a> (<%# DataBinder.Eval(Container.DataItem, "Name") %>)
                    </td>
                    <% if ((DiplomacyPermission & beans.TribePermission.DiplomateOfficer) == beans.TribePermission.DiplomateOfficer)
                       { %>
                    <td>
                        <a href="tribe.aspx?id=<% =this.Village.ID %>&page=2&action=diplomacy&tribe=<%# DataBinder.Eval(Container.DataItem, "ID") %>">
                            Bỏ </a>
                    </td>
                    <% } %>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <div id="pTest">
        </div>
    </tbody>
</table>
<br />
<table class="vis" width="300">
    <tbody>
        <tr>
            <th colspan="2">
                Trung lập
            </th>
        </tr>
        <asp:Repeater ID="gvNaps" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <a href="tribe_info.aspx?id=<% =this.Village.ID %>&tribe=<%# DataBinder.Eval(Container.DataItem, "ID") %>"><%# DataBinder.Eval(Container.DataItem, "Tag") %></a> (<%# DataBinder.Eval(Container.DataItem, "Name") %>)
                    </td>
                    <% if ((DiplomacyPermission & beans.TribePermission.DiplomateOfficer) == beans.TribePermission.DiplomateOfficer)
                       { %>
                    <td>
                        <a href="tribe.aspx?id=<% =this.Village.ID %>&page=2&action=diplomacy&tribe=<%# DataBinder.Eval(Container.DataItem, "ID") %>">
                            Bỏ </a>
                    </td>
                    <% } %>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>
<br />
<table class="vis" width="300">
    <tbody>
        <tr>
            <th colspan="2">
                Enemy
            </th>
        </tr>
        <asp:Repeater ID="gvEnemies" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <a href="tribe_info.aspx?id=<% =this.Village.ID %>&tribe=<%# DataBinder.Eval(Container.DataItem, "ID") %>">
                            <%# DataBinder.Eval(Container.DataItem, "Tag") %></a> (<%# DataBinder.Eval(Container.DataItem, "Name") %>)
                    </td>
                    <% if ((DiplomacyPermission & beans.TribePermission.DiplomateOfficer) == beans.TribePermission.DiplomateOfficer)
                       { %>
                    <td>
                        <a href="tribe.aspx?id=<% =this.Village.ID %>&page=2&action=diplomacy&tribe=<%# DataBinder.Eval(Container.DataItem, "ID") %>">
                            Bỏ </a>
                    </td>
                    <% } %>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
</table>

<asp:UpdatePanel ID="pDiplomate" runat="server">
    <ContentTemplate>
<h3>
    Add relationship</h3>
<div style="float: left;">
    Tribe tag:
</div>

        <div style="float: left; margin-left: 5px;">
            <asp:TextBox ID="txtTag" runat="server">
            </asp:TextBox></div>
        <div style="float: left; margin-left: 5px;">
            <telerik:RadComboBox ID="cbRelation" runat="server">
                <Items>
                    <telerik:RadComboBoxItem Text="Ally" Value="2" />
                    <telerik:RadComboBoxItem Text="Nap" Value="1" />
                    <telerik:RadComboBoxItem Text="Enemy" Value="3" />
                </Items>
            </telerik:RadComboBox>
        </div>
        <div style="float: left; margin-left: 5px;">
            <asp:Button ID="bttnAddRelation" runat="server" Text="OK" OnClick="bttnAddRelation_Click" /></div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="bttnAddRelation" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
