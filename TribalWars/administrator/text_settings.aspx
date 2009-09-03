<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/administrator.master" AutoEventWireup="true" CodeFile="text_settings.aspx.cs" Inherits="administrator_text_settings" ValidateRequest="false" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <h1>
            Text Settings
        </h1>
    </center>
    <asp:Repeater ID="stringConfigurationRepeater" runat="server" 
    EnableViewState="true" onitemcommand="stringConfigurationRepeater_ItemCommand">
        <HeaderTemplate>
            <table border="1" width="95%">
                <tbody>
                    <tr>
                        <th width="30px;">
                        </th>
                        <th width="250px;">
                            Tên biến
                        </th>
                        <th>
                            Giá trị
                        </th>
                    </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
        <ItemTemplate>
            <tr>
                <td width="3%">
                    <asp:CheckBox ID="checkDeleteCheckBox" runat="server" ToolTip='<%# DataBinder.Eval(Container.DataItem, "Key")  %>' />
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "Key")  %>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtValue" Width="95%" Height="50px" TextMode="MultiLine" OnTextChanged="ValueChanged" AutoPostBack="false" TextID='<%# Eval("Key")  %>'  Text='<%# Eval("Value")  %>'></asp:TextBox><br />
                    <asp:Button runat="server" ID="bttnChangeValue" Text="Sửa" CommandArgument='<%# Eval("Key")  %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Button ID="deleteSettingButton" runat="server" Text="Xoá phần được chọn" OnClick="deleteSettingButton_Click" />
    <input type="button" value="Thêm giá trị mới" onclick="$('#new_value').toggle('slow');" />
    <div id="new_value" style="display:none;">
        <table>
            <tbody>
                <tr>
                    <td>Key:</td>
                    <td><asp:TextBox ID="keyTextBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Giá trị:</td>
                    <td><telerik:RadEditor ID="valueTextBox" Runat=server></telerik:RadEditor></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" ><asp:Button ID="createNewSettingButton" runat="server" Text="Thêm giá trị mới" 
        onclick="createNewSettingButton_Click" style="height: 26px" /></td>
                </tr>
            </tbody>
        </table>
        
    </div>
</asp:Content>

