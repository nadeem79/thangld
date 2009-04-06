<%@ Page Title="" Language="C#" MasterPageFile="~/CustomForm.master" AutoEventWireup="true"
    CodeFile="change_tribe_info.aspx.cs" Inherits="change_tribe_info" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:Panel ID="pCannotChange" runat="server">
        <h2>
            Bạn không có quyền truy cập khu vực này
        </h2>
    </asp:Panel>
    <asp:Panel ID="pCanChange" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div>
                        <asp:Label ID="error" runat="server" ForeColor="Red"></asp:Label></div>
                    <div>
                        <h2>
                            THAY ĐỔI THÔNG TIN BANG HỘI</h2>
                        <div>
                            Ký hiệu:
                        </div>
                        <div>
                            <asp:TextBox ID="txtTag" runat="server"></asp:TextBox>
                            <div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTag"
                                    runat="server" ErrorMessage="Nhập tag name"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                Tên:
                            </div>
                            <div>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
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
                                <telerik:RadEditor ID="txtDescription" runat="server">
                                </telerik:RadEditor>
                            </div>
                            <div>
                                <asp:Button ID="bttnChangeTribeInfo" runat="server" Text="Thay đổi thông tin" Width="150"
                                    OnClick="bttnChangeTribeInfo_Click" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
</asp:Content>
