<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true"
    CodeFile="academy.aspx.cs" Inherits="academy" %>
<%@ Reference Control="CreateHero.ascx" %>
<%@ Reference Control="HeroDetails.ascx" %>
<%@ Reference Control="HeroList.ascx" %>
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
                    <img src="images/big_buildings/academy.png" title="Academy" alt="">
                </td>
                <td>
                    <h2>
                        Academy Level <% = this.Village.VillageBuildingData.Academy %></h2>
                    In the academy you can educate noblemen. They will help you conquer other villages.
                    <br />
                </td>
            </tr>
        </tbody>
    </table>
    <table>
        <tbody>
            <tr>
                <td valign="top">
                    <table class="vis" id="tblMenu" runat="server">
                        <tbody>
                            <tr>
                                <td width="100">
                                    <a href="academy.aspx?id=<%=this.Village.ID %>">Danh sách</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="academy.aspx?id=<%=this.Village.ID %>&page=unit">Đào tạo hero</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top">
                    <asp:PlaceHolder ID="heroPanel" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </tbody>
    </table>
    </asp:Panel>
</asp:Content>
