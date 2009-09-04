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
    
    <fieldset style="margin-bottom:20px;">
        <legend>Tìm kiếm</legend>
        <table>
            <tbody>
                <tr>
                    <td>Text:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtKey" Width="500px"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:CheckBox runat="server" ID="chkSearchByValue" Text="Tìm kiếm theo value" /></td>
                </tr>
                <tr>
                    <td colspan="2"><center><asp:Button runat="server" Text="Tìm kiếm" ID="bttnSearchText" 
                            onclick="bttnSearchText_Click" /></center></td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    
    
    <asp:Label ID="lblPaging" runat="server"></asp:Label>
    
    <asp:Repeater ID="stringConfigurationRepeater" runat="server" 
    EnableViewState="true" onitemcommand="stringConfigurationRepeater_ItemCommand">
        <HeaderTemplate>
            <table border="1" width="100%">
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
                    <asp:CheckBox ID="checkDeleteCheckBox" Value='<%# DataBinder.Eval(Container.DataItem, "Key")  %>' runat="server" ToolTip='<%# DataBinder.Eval(Container.DataItem, "Key")  %>' />
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "Key")  %>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtValue" Width="95%" Height="50px" TextMode="MultiLine" OnTextChanged="ValueChanged" AutoPostBack="false" TextID='<%# Eval("Key")  %>'  Text='<%# Eval("Value")  %>'></asp:TextBox><br />
                    <asp:Button runat="server" ID="bttnChangeValue" Text="Sửa" CommandName="EditConfig" OnClientClick="return confirm('Sửa biến text?');" CommandArgument='<%# Eval("Key")  %>' />
                    <input type="button" value="Sửa chi tiết" onclick="javascript:window.location='change_text.aspx?key=<%# Eval("Key")  %>'" />
                    <asp:Button runat="server" ID="bttnDelete" Text="Xoá" CommandName="DeleteConfig" OnClientClick="return confirm('Bạn muốn xoá biến text này?');" CommandArgument='<%# Eval("Key")  %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Button ID="deleteSettingButton" runat="server" Text="Xoá phần được chọn" OnClick="deleteSettingButton_Click" />
</asp:Content>

