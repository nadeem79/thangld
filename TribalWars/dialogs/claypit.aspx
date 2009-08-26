<%@ Page Title="" Language="C#" MasterPageFile="~/dialogs/dialog_template.master" AutoEventWireup="true" CodeFile="claypit.aspx.cs" Inherits="dialogs_claypit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dialog" Runat="Server">
<table>
        <tbody>
            <tr>
                <td>
                    <img src="../images/stone3.png" title="Lò gạch" alt="" />
                </td>
                <td>
                    <h2>
                        Lò gạch cấp <% = this.Village.VillageBuildingData.ClayPit %></h2>
                    Cung cấp vật liệu xây dựng dùng cho phát triển thành phố to - đẹp - hiện đại. Nghe
                    giang hồ đồn đại rằng vào những đêm trăng sáng hoặc lễ hội Valentine, 8/3, hai vợ
                    chồng nhà Thị Nở - Chí Phèo chuyên môn ra đây tâm sự.
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <table class="vis">
        <tbody>
            <tr>
                <td width="200">
                    <img src="../images/lehm.png" title="Wood" alt="">
                    Sản lượng hiện tại
                </td>
                <td>
                    Tăng <b>
                        <% = this.Village.VillageResourceMethods.ProductPerHour(beans.ResourcesType.Clay) %></b>&nbsp;đơn vị gạch
                    mỗi giờ
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>

