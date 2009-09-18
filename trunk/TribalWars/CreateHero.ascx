<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreateHero.ascx.cs" Inherits="CreateHero" %>
<table>
    <tbody>
        <tr>
            <td>
                Tài nguyên mua hero mới:<br />
                <div style="float: left;">
                    <img src="images/resources/clay.png" title="Clay" />
                    <% = this.Price.Clay%>
                </div>
                &nbsp;&nbsp;
                <div style="float: left; margin-left: 5px;">
                    <img src="images/resources/wood.png" title="Wood" />
                    <% = this.Price.Wood%>
                </div>
                &nbsp;&nbsp;
                <div style="float: left; margin-left: 5px;">
                    <img src="images/resources/iron.png" title="Iron" />
                    <% = this.Price.Iron%>
                </div>
                &nbsp;&nbsp;
                <div style="clear: both">
                </div>
            </td>
        </tr>
        <tr>
            <td>
            <asp:Panel runat="server" ID="pCreateHero">
                Tên:
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                &nbsp;<asp:Button runat="server" ID="bttnCreateHero" OnClick="bttnCreateHero_Click"
                    OnClientClick="return confirm('Tạo hero mới?');" />
                <br />
                Chú ý: Hero được sinh ra tức thời, vì thế phải cẩn thận trong tạo hero mới
                </asp:Panel>
                <asp:Panel runat="server" ID="pCannotCreateHero" Visible = "false">
                    <asp:Label ID="lblCannotCreateHero" runat="server"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
    </tbody>
</table>
