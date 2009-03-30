<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserProfile.ascx.cs" Inherits="UserProfile" %>

<script type="text/javascript" src="js/tiny_mce/tiny_mce.js"></script>

<script type="text/javascript">
    tinyMCE.init({
    
        // General options
        mode : "exact",
        elements : "<%Response.Write(this.txtPersonalText.ClientID); %>",
        theme : "advanced",
        skin : "o2k7",
        plugins : "safari,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,imagemanager,filemanager",

        // Theme options
        theme_advanced_buttons1 : "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect",
        theme_advanced_buttons2 : "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
        theme_advanced_buttons3 : "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
        theme_advanced_toolbar_location : "top",
        theme_advanced_toolbar_align : "left",
        theme_advanced_statusbar_location : "bottom",
        theme_advanced_resizing : true,
        extended_valid_elements : "script",
        extended_valid_elements : 
        "a[href|rel|rev|target|title|type]," +
        "b[],"+
        "blink[],"+
        "blockquote[align|cite|clear|height|type|width],"+
        "br[clear],"+
        "caption[align|height|valign|width],"+
        "center[align|height|width],"+
        "col[align|bgcolor|char|charoff|span|valign|width],"+
        "colgroup[align|bgcolor|char|charoff|span|valign|width],"+
        "comment[],"+
        "em[],"+
        "font[color|face|font-weight|point-size|size],"+
        "h1[align|clear|height|width],"+
        "h2[align|clear|height|width],"+
        "h3[align|clear|height|width],"+
        "h4[align|clear|height|width],"+
        "h5[align|clear|height|width],"+
        "h6[align|clear|height|width],"+
        "hr[align|clear|color|noshade|size|width],"+
        "img[align|alt|border|height|hspace|src|vspace|width],"+
        "li[align|clear|height|type|value|width],"+
        "marquee[behavior|bgcolor|direction|height|hspace|loop|scrollamount|scrolldelay|vspace|width],"+
        "ol[align|clear|height|start|type|width],"+
        "p[align|clear|height|width],"+
        "pre[clear|width|wrap],"+
        "s[],"+
        "small[],"+
        "span[align],"+
        "strike[],"+
        "strong[],"+
        "sub[],"+
        "sup[],"+
        "table[align|background|bgcolor|border|bordercolor|bordercolordark|bordercolorlight|"+
               "bottompadding|cellpadding|cellspacing|clear|cols|height|hspace|leftpadding|"+
               "rightpadding|rules|summary|toppadding|vspace|width],"+
        "tbody[align|bgcolor|char|charoff|valign],"+
        "td[abbr|align|axis|background|bgcolor|bordercolor|"+
           "bordercolordark|bordercolorlight|char|charoff|headers|"+
           "height|nowrap|rowspan|scope|valign|width],"+
        "tfoot[align|bgcolor|char|charoff|valign],"+
        "th[abbr|align|axis|background|bgcolor|bordercolor|"+
           "bordercolordark|bordercolorlight|char|charoff|headers|"+
           "height|nowrap|rowspan|scope|valign|width],"+
        "thead[align|bgcolor|char|charoff|valign],"+
        "tr[align|background|bgcolor|bordercolor|"+
           "bordercolordark|bordercolorlight|char|charoff|"+
           "height|nowrap|valign],"+
        "tt[],"+
        "u[],"+
        "ul[align|clear|height|start|type|width]",



        // Example content CSS (should be your site CSS)
        content_css : "css/example.css",

        // Drop lists for link/image/media/template dialogs
        template_external_list_url : "js/template_list.js",
        external_link_list_url : "js/link_list.js",
        external_image_list_url : "js/image_list.js",
        media_external_list_url : "js/media_list.js",

        // Replace values for the template plugin
        template_replace_values : {
	        username : "Some User",
	        staffid : "991234"
        }
    });
</script>



<table class="vis" width="100%">
    <tbody>
        <tr>
            <th colspan="2">
                Thông tin cá nhân
            </th>
        </tr>
        <tr>
            <td width="15%">
                Ngày sinh:
            </td>
            <td>
                <asp:DropDownList ID="cbDay" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="cbMonth" runat="server" Height="16px" Width="86px">
                    <asp:ListItem Text="Tháng một" Value="01"></asp:ListItem>
                    <asp:ListItem Text="Tháng hai" Value="02"></asp:ListItem>
                    <asp:ListItem Text="Tháng ba" Value="03"></asp:ListItem>
                    <asp:ListItem Text="Tháng bốn" Value="04"></asp:ListItem>
                    <asp:ListItem Text="Tháng năm" Value="05"></asp:ListItem>
                    <asp:ListItem Text="Tháng sáu" Value="06"></asp:ListItem>
                    <asp:ListItem Text="Tháng bảy" Value="07"></asp:ListItem>
                    <asp:ListItem Text="Tháng tám" Value="08"></asp:ListItem>
                    <asp:ListItem Text="Tháng chín" Value="09"></asp:ListItem>
                    <asp:ListItem Text="Tháng mười" Value="10"></asp:ListItem>
                    <asp:ListItem Text="Tháng mười một" Value="11"></asp:ListItem>
                    <asp:ListItem Text="Tháng mười hai" Value="12"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="cbYear" runat="server" Width="50px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Giới tính:
            </td>
            <td>
                <asp:RadioButton ID="rdoMale" runat="server" Text="Nam" />
                <asp:RadioButton ID="rdoFemale" runat="server" Text="Nữ" />
            </td>
        </tr>
        <tr>
            <td>
                Địa chỉ:
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Ảnh đại diện:
            </td>
            <td>
                <% if (this.player.Avatar) Response.Write("<img src='data/images/member/" + this.player.ID.ToString() + ".jpg' alt='" + this.player.Username + "' /><br />"); %>
                <asp:LinkButton ID="aDeleteAvatar" runat="server" OnClick="aDeleteAvatar_Click">Xoá ảnh đại diện</asp:LinkButton>
                <asp:FileUpload ID="fileAvatar" runat="server" Width="500px" /><br />
                <span style="font-size: xx-small;">Kích thước tối đa 240x180, dung lượng tối đa 120kByte,
                    (jpg, jpeg, png, gif)</span>
                <br />
                <asp:Label ID="lblAvatarError" runat="server" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" width="100%">
            </td>
        </tr>
    </tbody>
</table>
<br>
<table class="vis" width="100%">
    <tbody>
        <tr>
            <th colspan="2">
                Tự giới thiệu:
            </th>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtPersonalText" runat="server" Width="600px" Height="50px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="bttnChangePlayerProfile" runat="server" Text="OK" OnClick="bttnChangePlayerProfile_Click" />
            </td>
        </tr>
    </tbody>
</table>
