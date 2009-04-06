<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TribeMembers.ascx.cs"
    Inherits="TribeMembers" %>
<h2>
    THÀNH VIÊN
    <% Response.Write(this.Tribe.Tag); %></h2>
<table class="vis">
    <tbody>
        <asp:Repeater ID="drTribeMembers" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <a href="user_info.aspx?id=<% = this.village.ID %>&player=<%# DataBinder.Eval(Container.DataItem, "ID") %>";">
                            <%# DataBinder.Eval(Container.DataItem, "Username") %></a><br />
                    </td>
                    <td>
                        <%# Container.ItemIndex + 1 %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>
