<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="farm.aspx.cs" Inherits="farm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<table><tbody><tr><td><img src="images/big_buildings/farm3.png" title="Farm" alt=""></td><td><h2>Farm Level <% = this.Village[beans.BuildingType.Farm] %></h2>The farm supplies your workers and troops with food. Without extending your farm your village cannot grow. The higher its level the more villagers can be supplied.</td></tr></tbody></table><br><table class="vis">
<tbody><tr><td><img src="images/face.png" title="Villagers" alt=""> Maximum population</td><td><b><% = this.Village.MaxPopulation %></b></td></tr>

</tbody></table>


<h4>Current population</h4>
<table class="vis">
	<tbody>
	<tr><td>Tổng cộng</td><td align="right"><b><% = (int)this.Village.Population %></b></td></tr>
</tbody></table>

</asp:Content>

