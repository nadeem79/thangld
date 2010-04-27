<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeroList.ascx.cs" Inherits="HeroList" %>
<asp:Repeater runat="server" ID="rptHeroes">
    <HeaderTemplate>
        <table>
            <tbody>
                <tr>
                    <th>
                        STT
                    </th>
                    <th>
                        Tên
                    </th>
                    <th>
                        Trạng thái
                    </th>
                </tr>
    </HeaderTemplate>
    <FooterTemplate>
        </tbody> </table>
    </FooterTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <%# Container.ItemIndex + 1 %>
            </td>
            <td>
                <a href="academy.aspx?id=<% = this.Village.ID %>&page=details&hero=<%# Eval("ID") %>">
                    <%# Eval("Name") %></a>
            </td>
            <td>
                <%# GetHeroStatus((beans.Hero)DataBinder.GetDataItem(Container))%>
            </td>
        </tr>
    </ItemTemplate>
</asp:Repeater>
