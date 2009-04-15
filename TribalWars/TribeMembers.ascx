<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TribeMembers.ascx.cs"
    Inherits="TribeMembers" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
    
<h2>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    THÀNH VIÊN
    <% Response.Write(this.Tribe.Tag); %></h2>
<table class="vis">
    <tbody>
        <tr>
            <th>
                Thành viên
            </th>
            <th>
                Số thứ tự
            </th>
            <th>
                Tổng điểm
            </th>
            <% if ((this.Member.TribePermission & beans.TribePermission.Baron) == beans.TribePermission.Baron)
               { %>
            <th>
            </th>
            <%} %>
        </tr>
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
                    <td><%# DataBinder.Eval(Container.DataItem, "Point") %></td>
                    <% if ((this.Member.TribePermission & beans.TribePermission.Baron) == beans.TribePermission.Baron)
                       { %>
            <td>
            
            </td>
            <%} %>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>
