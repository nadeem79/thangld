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
        </tbody>
    </table>
</asp:Content>
