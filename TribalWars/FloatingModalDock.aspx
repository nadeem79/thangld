<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FloatingModalDock.aspx.cs"
    Inherits="FloatingModalDock" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript">
        ModalExtender = function(flElement) {
            /// <summary>
            /// Implements modality functionality for an element.   
            /// </summary>               
            this._windowResizeDelegate = null;
            this._windowScrollDelegate = null;

            this._xCoordinate = -1;
            this._yCoordinate = -1;
            this._backgroundElement = null;
            this._foregroundElement = flElement;

            this._saveTabIndexes = new Array();
            this._saveDesableSelect = new Array();
            this._tagWithTabIndex = new Array('A', 'AREA', 'BUTTON', 'INPUT', 'OBJECT', 'SELECT', 'TEXTAREA', 'IFRAME');
        }

        ModalExtender.prototype = {

            dispose: function() {
                /// <summary>
                /// Detaches and disposes eventhandlers       
                this.hide();
                this._backgroundElement = null;
                this._foregroundElement = null;
            },

            show: function() {
                this._attachWindowHandlers(true);
                //Append the modal overlay
                var elem = this._getModalOverlay();

                this._foregroundElement.parentNode.appendChild(elem);

                //Set z-Index        
                elem.style.zIndex = $telerik.getCurrentStyle(this._foregroundElement, 'zIndex', this._foregroundElement.style.zIndex) - 1; // + 1;                

                //Make the overlay visible
                elem.style.display = '';

                //Disable TAB
                this._disableTab();

                this._updatePageLayout();

                this._updatePageLayout();
            },

            _storeBrowserPosition: function() {
                var oBody = document.body;
                var oDoc = document.documentElement;
                this._browserTop = oBody.scrollTop > oDoc.scrollTop ? oBody.scrollTop : oDoc.scrollTop;
                this._browserLeft = oBody.scrollLeft > oDoc.scrollLeft ? oBody.scrollTop : oDoc.scrollLeft;
            },

            _restoreBrowserPosition: function(left, top) {
                try {
                    if (null == left) left = this._browserLeft;
                    if (null == top) top = this._browserTop;

                    var oBody = document.body;
                    var oDoc = document.documentElement;
                    oBody.scrollTop = top;
                    oBody.scrollLeft = left;
                    oDoc.scrollTop = top;
                    oDoc.scrollLeft = left;
                }
                catch (ex) { };
            },

            hide: function() {
                this._backgroundElement.style.display = 'none';
                this._restoreTab();

                this._attachWindowHandlers(false);
            },

            _enableScroll: function(enable) {
                if (enable) {
                    document.body.style.overflow = null != this._overflow ? this._overflow : '';
                    document.documentElement.style.overflow = null != this._documentOverflow ? this._documentOverflow : '';

                    document.body.style.marginRight = '';
                }
                else {
                    this._overflow = document.body.style.overflow;
                    document.body.style.overflow = 'hidden';

                    this._documentOverflow = document.documentElement.style.overflow;
                    document.documentElement.style.overflow = 'hidden';

                    document.body.style.marginRight = '18px';
                }
            },

            _getModalOverlay: function() {
                if (!this._backgroundElement) {
                    var div = document.createElement('div');
                    div.style.display = 'none';
                    div.style.position = 'absolute';
                    div.style.left = '0px';
                    div.style.top = '0px';
                    div.style.zIndex = 10000;
                    div.style.backgroundColor = "#aaaaaa";
                    div.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=80)";
                    div.style.opacity = ".8";
                    div.style.mozOpacity = ".8";

                    //Classname should be set to allow for devs to output it on the page, and style the DIV
                    div.className = "TelerikModalOverlay";


                    this._backgroundElement = div;
                }
                return this._backgroundElement;
            },

            _attachWindowHandlers: function(attachEvent) {
                var targetElement = window; //document;

                if (true == attachEvent) {
                    this._windowResizeDelegate = Function.createDelegate(this, this._updatePageLayout);
                    $addHandler(targetElement, 'resize', this._windowResizeDelegate);

                    this._windowScrollDelegate = Function.createDelegate(this, this._updatePageLayout);
                    $addHandler(targetElement, 'scroll', this._windowScrollDelegate);
                }
                else {
                    if (this._windowResizeDelegate) $removeHandler(targetElement, 'resize', this._windowResizeDelegate);
                    this._windowResizeDelegate = null;

                    if (this._windowScrollDelegate) $removeHandler(targetElement, 'scroll', this._windowScrollDelegate);
                    this._windowScrollDelegate = null;
                }
            },

            _updatePageLayout: function() {

                var scrollLeft = (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
                var scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
                var clientBounds = $telerik.getClientBounds();
                var clientWidth = clientBounds.width;
                var clientHeight = clientBounds.height;

                var elem = this._getModalOverlay();
                elem.style.width = Math.max(Math.max(document.documentElement.scrollWidth, document.body.scrollWidth), clientWidth) + 'px';
                elem.style.height = Math.max(Math.max(document.documentElement.scrollHeight, document.body.scrollHeight), clientHeight) + 'px';
            },

            _disableTab: function() {

                var i = 0;
                var tagElements;
                var tagElementsInPopUp = new Array();
                Array.clear(this._saveTabIndexes);


                for (var j = 0; j < this._tagWithTabIndex.length; j++) {
                    tagElements = this._foregroundElement.getElementsByTagName(this._tagWithTabIndex[j]);
                    for (var k = 0; k < tagElements.length; k++) {
                        tagElementsInPopUp[i] = tagElements[k];
                        i++;
                    }
                }

                i = 0;
                for (var j = 0; j < this._tagWithTabIndex.length; j++) {
                    tagElements = document.getElementsByTagName(this._tagWithTabIndex[j]);
                    for (var k = 0; k < tagElements.length; k++) {
                        if (Array.indexOf(tagElementsInPopUp, tagElements[k]) == -1) {
                            this._saveTabIndexes[i] = { tag: tagElements[k], index: tagElements[k].tabIndex };
                            tagElements[k].tabIndex = "-1";
                            i++;
                        }
                    }
                }


                i = 0;
                if ((Sys.Browser.agent === Sys.Browser.InternetExplorer) && (Sys.Browser.version < 7)) {
                    var tagSelectInPopUp = new Array();
                    for (var j = 0; j < this._tagWithTabIndex.length; j++) {
                        tagElements = this._foregroundElement.getElementsByTagName('SELECT');
                        for (var k = 0; k < tagElements.length; k++) {
                            tagSelectInPopUp[i] = tagElements[k];
                            i++;
                        }
                    }

                    i = 0;
                    Array.clear(this._saveDesableSelect);
                    tagElements = document.getElementsByTagName('SELECT');
                    for (var k = 0; k < tagElements.length; k++) {
                        if (Array.indexOf(tagSelectInPopUp, tagElements[k]) == -1) {
                            this._saveDesableSelect[i] = { tag: tagElements[k], visib: $telerik.getCurrentStyle(tagElements[k], 'visibility') };
                            tagElements[k].style.visibility = 'hidden';
                            i++;
                        }
                    }
                }
            },

            _restoreTab: function() {
                for (var i = 0; i < this._saveTabIndexes.length; i++) {
                    this._saveTabIndexes[i].tag.tabIndex = this._saveTabIndexes[i].index;
                }
                if ((Sys.Browser.agent === Sys.Browser.InternetExplorer) && (Sys.Browser.version < 7)) {
                    for (var k = 0; k < this._saveDesableSelect.length; k++) {
                        this._saveDesableSelect[k].tag.style.visibility = this._saveDesableSelect[k].visib;
                    }
                }
            }
        };

        Telerik.Web.UI.RadDock.prototype.enableModalExtender = function() {
            if (!this._modalExtender) {
                this._modalExtender = new ModalExtender(this.get_element());
            }
            this._modalExtender.show();
        };
        Telerik.Web.UI.RadDock.prototype.disableModalExtender = function() {
            if (this._modalExtender) {
                this._modalExtender.hide();
            }
        };

        Telerik.Web.UI.RadDock.prototype.old_dispose = Telerik.Web.UI.RadDock.prototype.dispose;
        Telerik.Web.UI.RadDock.prototype.dispose = function() {
            this.old_dispose();
            if (this._modalExtender) {
                this._modalExtender.dispose();
                this._modalExtender = null;
            }
        };

        function checkFoating(mode) {
            return mode == Telerik.Web.UI.DockMode.Floating;
        }
        function showDock() {
            var dock = $find("dock1");
            
            dock.set_closed(false);
            dock.enableModalExtender();
        };

        function hideDock(dock, args) {
            if (args.command.get_name() == "Close") {
                dock.set_closed(true);
                dock.disableModalExtender();
            }
        };
    
    </script>

</head>
<body>
    onclientclick="showDock();return false;"
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:TextBox ID="textbox1" runat="server"></asp:TextBox>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <telerik:RadDock ID="dock1" runat="server" DockMode="Docked" Closed="true" OnClientCommand="hideDock"
                Style="z-index: 60000;">
                <ContentTemplate>
                    <asp:UpdatePanel ID="pTest" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtTest" runat="server"></asp:TextBox>
                            <asp:Button ID="bttnTest" runat="server" OnClick="bttnTest_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </telerik:RadDock>
            <asp:Button ID="btn1" runat="server" Text="Show dock" OnClick="btn1_Click" />
            <asp:TextBox ID="abx" runat="server"></asp:TextBox>
        </ContentTemplate>
        <Triggers><asp:AsyncPostBackTrigger ControlID="btn1" EventName="Click" /></Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
