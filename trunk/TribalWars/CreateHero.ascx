<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreateHero.ascx.cs" Inherits="CreateHero" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Label ID="lblError" runat="server"></asp:Label>
&nbsp;<table width="500px;">
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
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            
                            <table>
                                <tbody>
                                    <tr>
                                        <td>
                                            Tên:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" Width="116px"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập tên"
                                                ControlToValidate="txtName" ValidationGroup="CreatHero"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RadioButtonList runat="server" ID="rdoHeroType" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Text="Phát triển" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Tấn công" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Phòng thủ" Value="3"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Chọn kiểu hero"
                                                ControlToValidate="rdoHeroType"  ValidationGroup="CreatHero"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button runat="server" ID="bttnCreateHero" OnClick="bttnCreateHero_Click" OnClientClick="return confirm('Tạo hero mới?');"
                                                Text="Tạo hero mới" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger EventName="Click" ControlID="bttnCreateHero" />
                        </Triggers>
                        </asp:UpdatePanel>
                </asp:Panel>
                <asp:Panel runat="server" ID="pCannotCreateHero" Visible="false">
                    <asp:Label ID="lblCannotCreateHero" runat="server"></asp:Label></asp:Panel>
            </td>
        </tr>
    </tbody>
</table>
