<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeroDetails.ascx.cs" Inherits="HeroDetails" %>
<asp:Panel runat="server" ID="pHeroNotFound">
    Không tìm thấy hero
</asp:Panel>
<asp:Panel runat="server" ID="pHeroDetais">

    <script type="text/javascript">

            

        function myHandleEvent(e) {

            if (e.type == "keyup") {
                //.. Check if you have typed in a smiley. If so then replace it
                //var inst = tinyMCE.getInstanceById(editor_id);
                //var editor_id = tinyMCE.selectedInstance.editorId;
                //var _tempcontent = tinyMCE.activeEditor.getContent()

                //.. Add all the posible smileys here
                //var _tempcontent_new = _tempcontent.replace(":)", '<img border="0" src="images/smileys/smiley-smile.png">');
                //.. Only replace content if something has changed
                replaceAtCursor();
                if (_tempcontent_new != _tempcontent) {
                    //.. Save cursor postion before changing html
                    var bm = tinyMCE.activeEditor.selection.getBookmark();
                    tinyMCE.activeEditor.setContent(_tempcontent_new);
                    //.. Now put cursor back where it was
                    tinyMCE.activeEditor.selection.moveToBookmark(bm)
                }
            }

        }

        // Normal initialization of TinyMCE
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            plugins: "style,layer,table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras",

            // Theme options
            theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect, mylistbox",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true,
            handle_event_callback: "myHandleEvent",
            // Example content CSS (should be your site CSS)
            content_css: "css/example.css",

            // Drop lists for link/image/media/template dialogs
            template_external_list_url: "lists/template_list.js",
            external_link_list_url: "lists/link_list.js",
            external_image_list_url: "lists/image_list.js",
            media_external_list_url: "lists/media_list.js"
        });
    </script>

    <table>
        <tbody>
            <tr>
                <td>
                    Tên:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Ảnh đại diện:
                </td>
                <td>
                    <% if (this.Hero.Avatar) Response.Write("<img src='data/images/heroes/" + this.Hero.ID.ToString() + ".jpg' alt='" + this.Hero.Name + "' /><br />"); %>
                    <asp:LinkButton ID="aDeleteAvatar" runat="server" OnClick="aDeleteAvatar_Click">Xoá ảnh đại diện</asp:LinkButton>
                    <asp:FileUpload ID="fileAvatar" runat="server" Width="500px" /><br />
                    <span style="font-size: xx-small;">Kích thước tối đa 240x180, dung lượng tối đa 120kByte,
                        (jpg, jpeg, png, gif)</span>
                    <br />
                    <asp:Label ID="lblAvatarError" runat="server" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <table class="vis" width="500px">
        <tbody>
            <tr>
                <th colspan="2">
                    Tiểu sử hero:
                </th>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtPersonalText" runat="server" TextMode="MultiLine">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="bttnChangePlayerProfile" runat="server" Text="OK" OnClick="bttnChangePlayerProfile_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
