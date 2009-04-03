<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TribeProfile.ascx.cs"
    Inherits="TribeProfile" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Office2007" />
<telerik:RadToolTipManager ID="pChangeTribeInformation" runat="server">
</telerik:RadToolTipManager>
<table width="100%">
    <tr>
        <td valign="top" width="30%">
            <table class="vis" width="100%">
                <tbody>
                    <tr>
                        <th colspan="2">
                            Thông tin bang hội
                        </th>
                    </tr>
                    <tr>
                        <td width="100">
                            Tên:
                        </td>
                        <td>
                            <% Response.Write(this.Tribe.Name); %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tag:
                        </td>
                        <td>
                            <% Response.Write(this.Tribe.Tag); %>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <a href="tribe.aspx?id=<%Response.Write(this.village.ID); %>&page=1">Danh sách thành
                                viên</a>
                            <br />
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
        <td valign="top">
            <table class="vis" width="100%">
                <tr>
                    <td>
                        <% if (this.tribe.Avatar) Response.Write("<center><img src='data/images/tribe/" + this.tribe.ID.ToString() + ".jpg' /></center>"); %>
                    </td>
                </tr>
            </table>
            <table class="vis" width="100%">
                <tbody>
                    <tr>
                        <th>
                            <div style="float: left;">
                                Mô tả</div>
                            <div style="float: right;">
                                <asp:Panel ID="pChangeDescription" runat="server">
                                    <a href="javascript:void(0);" onclick="javascript:$('#<% Response.Write(this.pChangeInfo.ClientID); %>').toggle('slow');">
                                        Đổi thông tin bang hội</a>
                                </asp:Panel>
                            </div>
                        </th>
                    </tr>
                    <tr>
                        <td align="center">
                            <% Response.Write(this.Tribe.Description); %>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table>
                <tr>
                    <td>
                    <asp:Panel ID="pChangeInfo" runat="server" CssClass="hidden_panel" Width="500px"
                Height="763px">
                <div>
                    <asp:Label ID="error" runat="server" ForeColor="Red"></asp:Label></div>
                <div>
                    <div>
                        Ký hiệu (tối đa 6 ký tự):
                    </div>
                    <div>
                        <telerik:RadTextBox ID="txtTag" runat="server" MaxLength="6" Width="260px">
                        </telerik:RadTextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTag"
                                runat="server" ErrorMessage="Nhập tag name"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            Tên:
                        </div>
                        <div>
                            <telerik:RadTextBox ID="txtName" runat="server" Width="355px">
                            </telerik:RadTextBox>
                            <div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtName"
                                    runat="server" ErrorMessage="Nhập tên"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div>
                            Ảnh đại diện:
                        </div>
                        <div>
                            <asp:Image ID="imgAvatar" runat="server" />
                            <div>
                                <asp:LinkButton ID="aDeleteAvatar" runat="server" OnClick="aDeleteAvatar_Click">Xoá ảnh đại diện</asp:LinkButton><br />
                            </div>
                            <asp:FileUpload ID="fileAvatar" runat="server" Width="500px" /><br />
                            <span style="font-size: xx-small;">Kích thước tối đa 240x180, dung lượng tối đa 120kByte,
                                (jpg, jpeg, png, gif)</span>
                            <br />
                            <asp:Label ID="lblAvatarError" runat="server" ForeColor="#FF3300"></asp:Label>
                        </div>
                        <div>
                            Thông tin bang hội:
                        </div>
                        <div>
                            <telerik:RadEditor ID="txtDescription" runat="server" 
                                ToolsFile="~/ToolsFile.xml">
                                <Content>
</Content>
                            </telerik:RadEditor>
                        </div>
                        <div style="margin-top: 5px;">
                            <asp:Button ID="bttnChangeTribeInfo" runat="server" Text="Thay đổi thông tin" Width="150"
                                OnClick="bttnChangeTribeInfo_Click" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
                    </td>
                </tr>
            </table>
            
        </td>
    </tr>
</table>
