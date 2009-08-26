<%@ Page Title="" Language="C#" MasterPageFile="~/dialogs/dialog_template.master"
    AutoEventWireup="true" CodeFile="timber.aspx.cs" Inherits="dialogs_timber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dialog" runat="Server">
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="../images/wood3.png" title="Timber camp" alt="" />
                </td>
                <td>
                    <h2>
                        Trại đốn gỗ cấp
                        <% = this.Village.VillageBuildingData.TimberCamp %></h2>
                    Mỗi thành phố đều được hệ thống sinh thái rừng rậm bảo vệ khỏi nạn ô nhiễm môi trường
                    từ khói thuốc, xe cộ và khí thải CO2. Từ rừng, chúng ta mới có những chuyện cổ tích
                    như Thạch Sanh - Lý Thông hay Cây tre trăm đốt. Hi vọng các bác tiều phu của chúng
                    ta không đốn quá nhiều, để dành cho con cháu mai sau.
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <table class="vis">
        <tbody>
            <tr>
                <td width="200">
                    <img src="../images/resources/wood.png" title="Wood" alt="">
                    Sản lượng hiện tại
                </td>
                <td>
                    Tăng <b>
                        <% = this.Village.VillageResourceMethods.ProductPerHour(beans.ResourcesType.Wood) %></b>&nbsp;đơn
                    vị gỗ mỗi giờ
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
