<%@ Page Title="" Language="C#" MasterPageFile="~/dialogs/dialog_template.master" AutoEventWireup="true" CodeFile="mine.aspx.cs" Inherits="dialogs_mine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dialog" Runat="Server">

<table>
        <tbody>
            <tr>
                <td>
                    <img src="images/iron3.png" title="Mỏ sắt" alt="" />
                </td>
                <td>
                    <h2>
                        Mỏ sắt cấp <% = this.Village.VillageBuildingData.IronMine %></h2>
                    Không như dầu mỏ Arập hay kim cương Châu Phi, các mỏ sắt trong Medieval Wars 
                    không bao giờ cạn kiệt. Cứ yên tâm khai thác, lấy nhiều được nhiều, lấy ít được 
                    ít. Nhưng cẩn thận đấy: Sắt chuyên dùng cho đào tạo quân đội, nên cũng dễ bị 
                    quân đội nơi khác đến cướp đi.</td>
            </tr>
        </tbody>
    </table>
    <br>
    <table class="vis">
        <tbody>
            <tr>
                <td width="200">
                    <img src="images/iron.png" title="Wood" alt="">
                    Sản lượng hiện tại
                </td>
                <td>
                    Tăng <b>
                        <% = this.Village.VillageResourceMethods.ProductPerHour(beans.ResourcesType.Iron) %></b>&nbsp;đơn vị 
                    kim loại
                    mỗi giờ
                </td>
            </tr>
        </tbody>
    </table>

</asp:Content>

