<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/administrator.master"
    AutoEventWireup="true" CodeFile="numeric_settings.aspx.cs" Inherits="administrator_numeric_settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <h1>
            Numeric
        </h1>
    </center>
    <asp:Repeater ID="numericConfigurationRepeater" runat="server" EnableViewState="true">
        <HeaderTemplate>
            <table border="1" width="90%">
                <tbody>
                    <tr>
                        <th>
                        </th>
                        <th>
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
                    <form method="post" action="<% = Request.Url.ToString() %>">
                    <input type="text" name="value" value='<%# DataBinder.Eval(Container.DataItem, "Value")  %>' />
                    <input type="hidden" name="key" value='<%# DataBinder.Eval(Container.DataItem, "Key")  %>' />
                    <input type="submit" value="Thay đổi" />
                    </form>
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
                    <td><asp:TextBox ID="valueTextBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" ><asp:Button ID="createNewSettingButton" runat="server" Text="Thêm giá trị mới" 
        onclick="createNewSettingButton_Click" style="height: 26px" /></td>
                </tr>
            </tbody>
        </table>
        
    </div>
    
</asp:Content>
