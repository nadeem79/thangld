/*
 * CometChat 
 * Version: 1.0.1
 */
 
 (function(a){a.cometchat=function(){
	
// UPDATE THE FOLLOWING LINE IF YOU PLACE COMETCHAT IN DIFFERENT FOLDER
 var g = "http://localhost/cometchat/";
 alert(g + "cometchat_send.php");
var v={};var u={};var f={};var Y="";var t=0;var r=0;var M=true;var l=0;var w=false;var Z;var ab=3000;var I=12000;var N=3000;var h=1;var W=0;var p=0;var n={};var m={};var ac={};a("<div/>").attr("id","cometchat_base").appendTo(a("body"));function L(ah,ae){if(a("#cometchat_tooltip").length>0){a("#cometchat_tooltip .cometchat_tooltip_content").html(ae)}else{a("body").append('<div id="cometchat_tooltip"><div class="cometchat_tooltip_content">'+ae+"</div></div>")}var ag=a("#"+ah).offset();var ad=a("#"+ah).width();var af=a("#cometchat_tooltip").width();a("#cometchat_tooltip").css("bottom",29).css("left",(ag.left+ad)-af+12).css("display","block");if(w){a("#cometchat_tooltip").css("position","absolute");a("#cometchat_tooltip").css("top",parseInt(a(window).height())-parseInt(a("#cometchat_tooltip").css("bottom"))-parseInt(a("#cometchat_tooltip").height())+a(window).scrollTop()+"px")}}function D(ae,ad,af){if(ae.keyCode==13&&ae.shiftKey==0){message=a(ad).val();message=message.replace(/^\s+|\s+$/g,"");a(ad).val("");a(ad).css("height","18px");a("#cometchat_user_"+af+"_popup .cometchat_tabcontenttext").css("height","200px");a(ad).css("overflow-y","hidden");a(ad).focus();if(message!=""){a.post(g+"cometchat_send.php",{to:af,message:message},function(ag){if(ag){P(af,message,"1","1",ag);a("#cometchat_user_"+af+"_popup .cometchat_tabcontenttext").scrollTop(a("#cometchat_user_"+af+"_popup .cometchat_tabcontenttext")[0].scrollHeight)}h=1;if(N>ab){N=ab;clearTimeout(Z);Z=setTimeout(function(){B()},ab)}})}return false}}function V(ae,ad){if(ae.keyCode==13&&ae.shiftKey==0){message=a(ad).val();if(message!=""){a.post(g+"cometchat_send.php",{statusmessage:message},function(af){a(ad).blur()})}return false}}function S(ag,af,ah){var ae=af.clientHeight;var ad=94;if(ad>ae){ae=Math.max(af.scrollHeight,ae);if(ad){ae=Math.min(ad,ae)}if(ae>af.clientHeight){a(af).css("height",ae+4+"px");a("#cometchat_user_"+ah+"_popup .cometchat_tabcontenttext").css("height",218-(ae+4)+"px")}}else{a(af).css("overflow-y","auto")}a("#cometchat_user_"+ah+"_popup .cometchat_tabcontenttext").scrollTop(a("#cometchat_user_"+ah+"_popup .cometchat_tabcontenttext")[0].scrollHeight)}function z(){a("#cometchat_optionsbutton_popup .busy").css("text-decoration","none");a("#cometchat_optionsbutton_popup .invisible").css("text-decoration","none");a("#cometchat_optionsbutton_popup .available").css("text-decoration","none");a("#cometchat_userstab_icon").removeClass("cometchat_user_available2");a("#cometchat_userstab_icon").removeClass("cometchat_user_busy2");a("#cometchat_userstab_icon").removeClass("cometchat_user_invisible2")}function X(ad){a.post(g+"cometchat_send.php",{status:ad},function(ae){})}function O(ad){r=1;z();a("#cometchat_userstab_icon").addClass("cometchat_user_invisible2");if(ad!=1){X("offline")}a("#cometchat_userstab_popup").removeClass("cometchat_tabopen");a("#cometchat_userstab").removeClass("cometchat_userstabclick").removeClass("cometchat_tabclick");a("#cometchat_optionsbutton_popup").removeClass("cometchat_tabopen");a("#cometchat_optionsbutton").removeClass("cometchat_tabclick");F("buddylist","0");a("#cometchat_userstab_text").html("Offline")}function K(){a("<span/>").attr("id","cometchat_optionsbutton").addClass("cometchat_tab").addClass("cometchat_optionsimages").appendTo(a("#cometchat_base"));a("<div/>").attr("id","cometchat_optionsbutton_popup").addClass("cometchat_tabpopup").css("display","none").html('<div class="cometchat_userstabtitle">Comet Chat Options</div><div class="cometchat_tabcontent" style="background-image: url('+g+'images/tabbottomoptions.gif);padding:5px;height:156px;"><strong>My Status</strong><br/><textarea class="cometchat_statustextarea"></textarea><span style="float:left" class="cometchat_user_available"></span><span class="cometchat_optionsstatus available">Available</span><span class="cometchat_optionsstatus2 cometchat_user_busy"></span><span class="cometchat_optionsstatus busy">Busy</span><span class="cometchat_optionsstatus2 cometchat_user_invisible"></span><span class="cometchat_optionsstatus invisible">Invisible</span><br clear="all"/><div style="border-top:1px solid #eeeeee;margin-top:10px;padding-top:10px;"><span><strong>Add Friend</strong><br/><br/><a href="faq.php?faq=vb3_user_profile#faq_vb3_friends_contacts">Learn how to add friends</a></span></div>').appendTo(a("body"));a("#cometchat_optionsbutton_popup .available").click(function(ad){z();a("#cometchat_userstab_icon").addClass("cometchat_user_available2");a(this).css("text-decoration","underline");X("available")});a("#cometchat_optionsbutton_popup .busy").click(function(ad){z();a("#cometchat_userstab_icon").addClass("cometchat_user_busy2");a(this).css("text-decoration","underline");X("busy")});a("#cometchat_optionsbutton_popup .invisible").click(function(ad){z();a("#cometchat_userstab_icon").addClass("cometchat_user_invisible2");a(this).css("text-decoration","underline");X("invisible")});a("#cometchat_optionsbutton_popup .cometchat_statustextarea").keydown(function(ad){return V(ad,this)});a("#cometchat_optionsbutton").mouseover(function(){if(!a("#cometchat_optionsbutton_popup").hasClass("cometchat_tabopen")){if(t==0){L("cometchat_optionsbutton","Comet Chat Options")}else{L("cometchat_optionsbutton","Please login to use Comet Chat")}}a(this).addClass("cometchat_tabmouseover")});a("#cometchat_optionsbutton").mouseout(function(){a(this).removeClass("cometchat_tabmouseover");a("#cometchat_tooltip").css("display","none")});a("#cometchat_optionsbutton").click(function(){if(t==0){if(r==1){r=0;a("#cometchat_userstab_text").html("Who's Online");B();a("#cometchat_optionsbutton_popup .available").click()}a("#cometchat_tooltip").css("display","none");a("#cometchat_optionsbutton_popup").css("left",a("#cometchat_optionsbutton").position().left-171).css("bottom","24px");a(this).toggleClass("cometchat_tabclick");a("#cometchat_optionsbutton_popup").toggleClass("cometchat_tabopen");a("#cometchat_optionsbutton").toggleClass("cometchat_optionsimages_click");a("#cometchat_userstab_popup").removeClass("cometchat_tabopen");a("#cometchat_userstab").removeClass("cometchat_userstabclick").removeClass("cometchat_tabclick");F("buddylist","0")}});a("#cometchat_optionsbutton_popup .cometchat_userstabtitle").click(function(){a("#cometchat_optionsbutton").click()});a("#cometchat_optionsbutton_popup .cometchat_userstabtitle").mouseenter(function(){a(this).addClass("cometchat_chatboxtabtitlemouseover2")});a("#cometchat_optionsbutton_popup .cometchat_userstabtitle").mouseleave(function(){a(this).removeClass("cometchat_chatboxtabtitlemouseover2")})}function c(){var ad="";a("#cometchat_chatboxes_wide span").each(function(){var af=a(this).attr("id").substr(15);var ae=0;if(a("#cometchat_user_"+af+" .cometchat_tabalert").length>0){ae=parseInt(a("#cometchat_user_"+af+" .cometchat_tabalert").html())}ad+=af+"|"+ae+","});ad=ad.slice(0,-1);F("activeChatboxes",ad)}function G(aj,ag,ad,ai,ae,ah){if(aj==""){return}if(a("#cometchat_user_"+aj).length>0){if(!a("#cometchat_user_"+aj).hasClass("cometchat_tabclick")){if(ae!=1){if(Y!=""){a("#cometchat_user_"+Y+"_popup").removeClass("cometchat_tabopen");a("#cometchat_user_"+Y).removeClass("cometchat_tabclick").removeClass("cometchat_usertabclick");Y=""}if((a("#cometchat_user_"+aj).offset().left<(a("#cometchat_chatboxes").offset().left+a("#cometchat_chatboxes").width()))&&(a("#cometchat_user_"+aj).offset().left-a("#cometchat_chatboxes").offset().left)>=0){a("#cometchat_user_"+aj).click()}else{a(".cometchat_tabalert").css("display","none");var af=800;if(e("initialize")==1||e("updatesession")==1){af=0}a("#cometchat_chatboxes").scrollTo("#cometchat_user_"+aj,af,function(){a("#cometchat_user_"+aj).click();aa();C()})}}}aa();return}a("#cometchat_chatboxes_wide").width(a("#cometchat_chatboxes_wide").width()+152);s();if(ag.length>14){shortname=ag.substr(0,14)+"..."}else{shortname=ag}if(ag.length>24){longname=ag.substr(0,24)+"..."}else{longname=ag}a("<span/>").attr("id","cometchat_user_"+aj).addClass("cometchat_tab").html('<div style="float:left">'+shortname+"</div>").appendTo(a("#cometchat_chatboxes_wide"));a("#cometchat_user_"+aj).append('<div class="cometchat_closebox_bottom_status cometchat_'+ad+'"></div>');a("#cometchat_user_"+aj).append('<div class="cometchat_closebox_bottom"></div>');a("#cometchat_user_"+aj+" .cometchat_closebox_bottom").mouseenter(function(){a(this).addClass("cometchat_closebox_bottomhover")});a("#cometchat_user_"+aj+" .cometchat_closebox_bottom").mouseleave(function(){a(this).removeClass("cometchat_closebox_bottomhover")});a("#cometchat_user_"+aj+" .cometchat_closebox_bottom").click(function(){a("#cometchat_user_"+aj+"_popup").remove();a("#cometchat_user_"+aj).remove();if(Y==aj){Y="";F("openChatboxId","")}a("#cometchat_chatboxes_wide").width(a("#cometchat_chatboxes_wide").width()-152);a("#cometchat_chatboxes").scrollTo("-=152px");s();c()});a("<div/>").attr("id","cometchat_user_"+aj+"_popup").addClass("cometchat_tabpopup").css("display","none").html('<div class="cometchat_tabtitle"><div class="cometchat_name">'+longname+'</div></div><div class="cometchat_tabsubtitle">'+ai+'</div><div class="cometchat_tabcontent"><div class="cometchat_tabcontenttext"></div><div class="cometchat_tabcontentinput"><textarea class="cometchat_textarea" ></textarea></div></div>').appendTo(a("body"));a("#cometchat_user_"+aj+"_popup .cometchat_textarea").keydown(function(ak){return D(ak,this,aj)});a("#cometchat_user_"+aj+"_popup .cometchat_textarea").keyup(function(ak){return S(ak,this,aj)});a("#cometchat_user_"+aj+"_popup .cometchat_tabtitle").append('<div class="cometchat_closebox"></div><br clear="all"/>');a("#cometchat_user_"+aj+"_popup .cometchat_tabtitle .cometchat_closebox").mouseenter(function(){a(this).addClass("cometchat_chatboxmouseoverclose");a("#cometchat_user_"+aj+"_popup .cometchat_tabtitle").removeClass("cometchat_chatboxtabtitlemouseover")});a("#cometchat_user_"+aj+"_popup .cometchat_tabtitle .cometchat_closebox").mouseleave(function(){a(this).removeClass("cometchat_chatboxmouseoverclose");a("#cometchat_user_"+aj+"_popup .cometchat_tabtitle").addClass("cometchat_chatboxtabtitlemouseover")});a("#cometchat_user_"+aj+"_popup .cometchat_tabtitle .cometchat_closebox").click(function(){a("#cometchat_user_"+aj+"_popup").remove();a("#cometchat_user_"+aj).remove();if(Y==aj){Y="";F("openChatboxId","")}a("#cometchat_chatboxes_wide").width(a("#cometchat_chatboxes_wide").width()-152);a("#cometchat_chatboxes").scrollTo("-=152px");s();c()});a("#cometchat_user_"+aj+"_popup .cometchat_tabtitle").click(function(){a("#cometchat_user_"+aj).click()});a("#cometchat_user_"+aj+"_popup .cometchat_tabtitle").mouseenter(function(){a(this).addClass("cometchat_chatboxtabtitlemouseover")});a("#cometchat_user_"+aj+"_popup .cometchat_tabtitle").mouseleave(function(){a(this).removeClass("cometchat_chatboxtabtitlemouseover")});a("#cometchat_user_"+aj).mouseenter(function(){a(this).addClass("cometchat_tabmouseover");a("#cometchat_user_"+aj+" div").addClass("cometchat_tabmouseovertext")});a("#cometchat_user_"+aj).mouseleave(function(){a(this).removeClass("cometchat_tabmouseover");a("#cometchat_user_"+aj+" div").removeClass("cometchat_tabmouseovertext")});a("#cometchat_user_"+aj).click(function(){if(a("#cometchat_user_"+aj+" .cometchat_tabalert").length>0){a("#cometchat_user_"+aj+" .cometchat_tabalert").remove();c()}if(a(this).hasClass("cometchat_tabclick")){a(this).removeClass("cometchat_tabclick").removeClass("cometchat_usertabclick");a("#cometchat_user_"+aj+"_popup").removeClass("cometchat_tabopen");a("#cometchat_user_"+aj+" .cometchat_closebox_bottom").removeClass("cometchat_closebox_bottom_click");Y="";F("openChatboxId","")}else{if(Y!=""){a("#cometchat_user_"+Y+"_popup").removeClass("cometchat_tabopen");a("#cometchat_user_"+Y).removeClass("cometchat_tabclick").removeClass("cometchat_usertabclick");a("#cometchat_user_"+Y+" .cometchat_closebox_bottom").removeClass("cometchat_closebox_bottom_click");Y=""}if((a("#cometchat_user_"+aj).offset().left-a("#cometchat_chatboxes").offset().left)<0){a("#cometchat_chatboxes").scrollTo("#cometchat_user_"+aj);aa()}a("#cometchat_user_"+aj+"_popup").css("left",a("#cometchat_user_"+aj).position().left-62).css("bottom","24px");a(this).addClass("cometchat_tabclick").addClass("cometchat_usertabclick");a("#cometchat_user_"+aj+"_popup").addClass("cometchat_tabopen");a("#cometchat_user_"+aj+" .cometchat_closebox_bottom").addClass("cometchat_closebox_bottom_click");F("openChatboxId",aj);Y=aj;if(a("#cometchat_user_"+aj+"_popup .cometchat_tabcontenttext").html()==""&&e("initialize")!=1){H(aj)}if(w){a("#cometchat_user_"+Y+"_popup").css("position","absolute");a("#cometchat_user_"+Y+"_popup").css("top",parseInt(a(window).height())-parseInt(a("#cometchat_user_"+Y+"_popup").css("bottom"))-parseInt(a("#cometchat_user_"+Y+"_popup").height())+a(window).scrollTop()+"px")}}a("#cometchat_user_"+aj+"_popup .cometchat_tabcontenttext").scrollTop(a("#cometchat_user_"+aj+"_popup .cometchat_tabcontenttext")[0].scrollHeight);a("#cometchat_user_"+aj+"_popup .cometchat_textarea").focus()});if(ae!=1){a("#cometchat_user_"+aj).click()}c();if(a("#cometchat_user_"+aj+"_popup .cometchat_tabcontenttext").html()==""&&e("initialize")!=1){H(aj)}}function H(ad){a.ajax({async:false,url:g+"cometchat_receive.php",data:{chatbox:ad},type:"post",cache:false,dataType:"json",success:function(ag){if(ag){a("#cometchat_user_"+ad+"_popup .cometchat_tabcontenttext").html("");var ae="";var af=n[ad];a.each(ag,function(ah,ai){if(ah=="messages"){a.each(ai,function(ak,aj){if(aj.self==1){fromname="Me"}else{fromname=af}aj.message=aj.message.replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/\"/g,"&quot;");ae+=('<div class="cometchat_chatboxmessage" id="cometchat_message_'+aj.id+'"><span class="cometchat_chatboxmessagefrom"><strong>'+fromname+'</strong>:&nbsp;&nbsp;</span><span class="cometchat_chatboxmessagecontent">'+aj.message+"</span></div>")})}});a("#cometchat_user_"+ad+"_popup .cometchat_tabcontenttext").append(ae);a("#cometchat_user_"+ad+"_popup .cometchat_tabcontenttext").scrollTop(a("#cometchat_user_"+ad+"_popup .cometchat_tabcontenttext")[0].scrollHeight)}}})}function U(af,ad,ae){Q(af);if(ae==1){if(a("#cometchat_user_"+af+" .cometchat_tabalert").length>0){ad=parseInt(a("#cometchat_user_"+af+" .cometchat_tabalert").html())+parseInt(ad)}}if(ad==0){a("#cometchat_user_"+af+" .cometchat_tabalert").remove()}else{if(a("#cometchat_user_"+af+" .cometchat_tabalert").length>0){a("#cometchat_user_"+af+" .cometchat_tabalert").html(ad)}else{a("<div/>").css("top","-5px").addClass("cometchat_tabalert").html(ad).appendTo(a("#cometchat_user_"+af))}}c();C()}function J(){a("<span/>").attr("id","cometchat_userstab").addClass("cometchat_tab").html('<span id="cometchat_userstab_icon"></span><span id="cometchat_userstab_text" style="float:left">Who\'s Online</span>').appendTo(a("#cometchat_base"));a("<div/>").attr("id","cometchat_userstab_popup").addClass("cometchat_tabpopup").css("display","none").html('<div class="cometchat_userstabtitle">Who\'s Online?</div><div class="cometchat_tabsubtitle"><a class="cometchat_gooffline">Go Offline</a></div><div class="cometchat_tabcontent" style="background-image: url('+g+'images/tabbottomwhosonline.gif);height:200px;padding-top:5px;padding-bottom:5px;"><div class="cometchat_userscontent"><div class="cometchat_userslist_available"></div><div class="cometchat_userslist_busy"></div><div class="cometchat_userslist_away"></div><div class="cometchat_userslist_offline"></div></div>').appendTo(a("body"));a("#cometchat_userstab_popup .cometchat_gooffline").click(function(){O()});a("#cometchat_userstab_popup .cometchat_userstabtitle").click(function(){a("#cometchat_userstab").click()});a("#cometchat_userstab_popup .cometchat_userstabtitle").mouseenter(function(){a(this).addClass("cometchat_chatboxtabtitlemouseover2")});a("#cometchat_userstab_popup .cometchat_userstabtitle").mouseleave(function(){a(this).removeClass("cometchat_chatboxtabtitlemouseover2")});a("#cometchat_userstab").mouseover(function(){a(this).addClass("cometchat_tabmouseover")});a("#cometchat_userstab").mouseout(function(){a(this).removeClass("cometchat_tabmouseover")});a("#cometchat_userstab").click(function(){if(r==1){r=0;a("#cometchat_userstab_text").html("Who's Online");B();a("#cometchat_optionsbutton_popup .available").click()}a("#cometchat_optionsbutton_popup").removeClass("cometchat_tabopen");a("#cometchat_optionsbutton").removeClass("cometchat_tabclick");if(a(this).hasClass("cometchat_tabclick")){F("buddylist","0")}else{F("buddylist","1")}a("#cometchat_userstab_popup").css("left",a("#cometchat_userstab").position().left+16).css("bottom","24px");a(this).toggleClass("cometchat_tabclick").toggleClass("cometchat_userstabclick");a("#cometchat_userstab_popup").toggleClass("cometchat_tabopen")})}function s(){var ae=a(window).width();if(ae<520){ae=520}a("#cometchat_base").css("width",ae-31);var ag=0;if(!a("#cometchat_chatbox_right").hasClass("cometchat_chatbox_lr")){ag=19}if(a("#cometchat_chatboxes_wide").width()<=(a("#cometchat_base").width()-226-ag-75)){a("#cometchat_chatboxes").css("width",a("#cometchat_chatboxes_wide").width());a("#cometchat_chatboxes").scrollTo("0px",0)}else{var ah=a("#cometchat_chatboxes").width();a("#cometchat_chatboxes").css("width",Math.floor((a("#cometchat_base").width()-226-ag-75)/152)*152);var ad=a("#cometchat_chatboxes").width();if(ah!=ad){a("#cometchat_chatboxes").scrollTo("-=152px",0)}}a("#cometchat_optionsbutton_popup").css("left",a("#cometchat_optionsbutton").position().left-171).css("bottom","24px");a("#cometchat_userstab_popup").css("left",a("#cometchat_userstab").position().left+16).css("bottom","24px");if(Y!=""){if((a("#cometchat_user_"+Y).offset().left<(a("#cometchat_chatboxes").offset().left+a("#cometchat_chatboxes").width()))&&(a("#cometchat_user_"+Y).offset().left-a("#cometchat_chatboxes").offset().left)>=0){a("#cometchat_user_"+Y+"_popup").css("left",a("#cometchat_user_"+Y).position().left-62).css("bottom","24px")}else{a("#cometchat_user_"+Y+"_popup").removeClass("cometchat_tabopen");a("#cometchat_user_"+Y).removeClass("cometchat_tabclick").removeClass("cometchat_usertabclick");var af=((a("#cometchat_user_"+Y).offset().left-a("#cometchat_chatboxes_wide").offset().left))-((Math.floor((a("#cometchat_chatboxes").width()/152))-1)*152);a("#cometchat_chatboxes").scrollTo(af,0,function(){a("#cometchat_user_"+Y).click()})}}C();aa();if(w){E()}}function C(){a("#cometchat_chatbox_left .cometchat_tabalertlr").html("0");a("#cometchat_chatbox_right .cometchat_tabalertlr").html("0");a("#cometchat_chatbox_left .cometchat_tabalertlr").css("display","none");a("#cometchat_chatbox_right .cometchat_tabalertlr").css("display","none");a(".cometchat_tabalert").each(function(){if((a(this).parent().offset().left<(a("#cometchat_chatboxes").offset().left+a("#cometchat_chatboxes").width()))&&(a(this).parent().offset().left-a("#cometchat_chatboxes").offset().left)>=0){a(this).css("display","block");a(this).css("left",a(this).parent().offset().left+a(this).parent().width()-30)}else{a(this).css("display","none");if((a(this).parent().offset().left-a("#cometchat_chatboxes").offset().left)>=0){var ad=a("#cometchat_chatbox_right").offset().left+a("#cometchat_chatbox_right").width()-30;a("#cometchat_chatbox_right .cometchat_tabalertlr").css("left",ad);a("#cometchat_chatbox_right .cometchat_tabalertlr").html(parseInt(a("#cometchat_chatbox_right .cometchat_tabalertlr").html())+parseInt(a(this).html()));a("#cometchat_chatbox_right .cometchat_tabalertlr").css("display","block")}else{var ad=a("#cometchat_chatbox_left").offset().left+a("#cometchat_chatbox_left").width()-22;a("#cometchat_chatbox_left .cometchat_tabalertlr").css("left",ad);a("#cometchat_chatbox_left .cometchat_tabalertlr").html(parseInt(a("#cometchat_chatbox_left .cometchat_tabalertlr").html())+parseInt(a(this).html()));a("#cometchat_chatbox_left .cometchat_tabalertlr").css("display","block")}}})}function aa(){var af=0;var ag=0;var ad=0;if(a("#cometchat_chatbox_right").hasClass("cometchat_chatbox_right_last")){ag=1}if(a("#cometchat_chatbox_right").hasClass("cometchat_chatbox_lr")){ad=1}if(a("#cometchat_chatboxes").scrollLeft()==0){a("#cometchat_chatbox_left").unbind("click",d);a("#cometchat_chatbox_left .cometchat_tabtext").html("0");a("#cometchat_chatbox_left").addClass("cometchat_chatbox_left_last");af++}else{var ae=Math.floor(a("#cometchat_chatboxes").scrollLeft()/152);a("#cometchat_chatbox_left").bind("click",d);a("#cometchat_chatbox_left .cometchat_tabtext").html(ae);a("#cometchat_chatbox_left").removeClass("cometchat_chatbox_left_last")}if((a("#cometchat_chatboxes").scrollLeft()+a("#cometchat_chatboxes").width())==a("#cometchat_chatboxes_wide").width()){a("#cometchat_chatbox_right").unbind("click",k);a("#cometchat_chatbox_right .cometchat_tabtext").html("0");a("#cometchat_chatbox_right").addClass("cometchat_chatbox_right_last");af++}else{var ae=Math.floor((a("#cometchat_chatboxes_wide").width()-(a("#cometchat_chatboxes").scrollLeft()+a("#cometchat_chatboxes").width()))/152);a("#cometchat_chatbox_right").bind("click",k);a("#cometchat_chatbox_right .cometchat_tabtext").html(ae);a("#cometchat_chatbox_right").removeClass("cometchat_chatbox_right_last")}if(af==2){a("#cometchat_chatbox_right").addClass("cometchat_chatbox_lr");a("#cometchat_chatbox_left").addClass("cometchat_chatbox_lr")}else{a("#cometchat_chatbox_right").removeClass("cometchat_chatbox_lr");a("#cometchat_chatbox_left").removeClass("cometchat_chatbox_lr")}if((!a("#cometchat_chatbox_right").hasClass("cometchat_chatbox_right_last")&&ag==1)||(a("#cometchat_chatbox_right").hasClass("cometchat_chatbox_right_last")&&ag==0)||(!a("#cometchat_chatbox_right").hasClass("cometchat_chatbox_lr")&&ad==1)||(a("#cometchat_chatbox_right").hasClass("cometchat_chatbox_lr")&&ad==0)){s()}}function q(ae){if(Y!=""){a("#cometchat_user_"+Y+"_popup").removeClass("cometchat_tabopen");a("#cometchat_user_"+Y).removeClass("cometchat_tabclick").removeClass("cometchat_usertabclick")}a(".cometchat_tabalert").css("display","none");var ad=800;if(e("initialize")==1||e("updatesession")==1){ad=0}a("#cometchat_chatboxes").scrollTo(ae,ad,function(){if(Y!=""){if((a("#cometchat_user_"+Y).offset().left<(a("#cometchat_chatboxes").offset().left+a("#cometchat_chatboxes").width()))&&(a("#cometchat_user_"+Y).offset().left-a("#cometchat_chatboxes").offset().left)>=0){a("#cometchat_user_"+Y).click()}else{Y=""}}C();aa()})}function d(){q("-=152px")}function k(){q("+=152px")}function b(ad,ae){v[ad]=ae}function e(ad){if(v[ad]){return v[ad]}else{return""}}function R(ad,ae){f[ad]=ae}function T(ad){if(f[ad]){return f[ad]}else{return""}}function F(ad,ae){u[ad]=ae;if(e("initialize")!=1&&e("updatesession")!=1&&T("updatingsession")!=1){W=1;clearTimeout(Z);Z=setTimeout(function(){B()},1000)}}function o(ad,ae){if(u[ad]){return u[ad]}else{return""}}function A(ae){var ad=parseInt(a(ae).attr("id").substr(19));G(ad,n[ad],buddylistStatus[ad],m[ad])}function Q(ae){var ad=ae;G(ad,n[ad],buddylistStatus[ad],m[ad],1)}function P(ah,ad,ag,af,ae){G(ah,n[ah],buddylistStatus[ah],m[ah],1,1);if(parseInt(ag)==1){fromname="Me"}else{fromname=n[ah]}ad=ad.replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/\"/g,"&quot;");if(a("#cometchat_message_"+ae).length>0){}else{a("#cometchat_user_"+ah+"_popup .cometchat_tabcontenttext").append('<div class="cometchat_chatboxmessage" id="cometchat_message_'+ae+'"><span class="cometchat_chatboxmessagefrom"><strong>'+fromname+'</strong>:&nbsp;&nbsp;</span><span class="cometchat_chatboxmessagecontent">'+ad+"</span></div>")}if(Y!=ah&&af!=1){U(ah,1,1)}}function B(){for(vars in u){v["sessionvars["+vars+"]"]=u[vars]}if(W==1){b("updatesession","1");W=0}v.timestamp=p;var ad="";var ae={};ae.available="";ae.busy="";ae.offline="";buddylistreceived=0;tempBuddylistStatus={};tempBuddylistMessage={};tempBuddylistName={};a.ajax({url:g+"cometchat_receive.php",data:v,type:"post",cache:false,dataType:"json",success:function(ag){if(ag){var af=0;a.each(ag,function(ah,ai){if(ah=="buddylist"){buddylistreceived=1;a.each(ai,function(ak,aj){if(aj.name.length>24){longname=aj.name.substr(0,24)+"..."}else{longname=aj.name}if(a("#cometchat_user_"+aj.id).length>0){a("#cometchat_user_"+aj.id+" .cometchat_closebox_bottom_status").removeClass("cometchat_available");a("#cometchat_user_"+aj.id+" .cometchat_closebox_bottom_status").removeClass("cometchat_busy");a("#cometchat_user_"+aj.id+" .cometchat_closebox_bottom_status").removeClass("cometchat_offline");a("#cometchat_user_"+aj.id+" .cometchat_closebox_bottom_status").addClass("cometchat_"+aj.status);if(a("#cometchat_user_"+aj.id+"_popup").length>0){a("#cometchat_user_"+aj.id+"_popup .cometchat_tabsubtitle").html(aj.message)}}ae[aj.status]+='<div id="cometchat_userlist_'+aj.id+'" class="cometchat_userlist" onmouseover="jQuery(this).addClass(\'cometchat_userlist_hover\');" onmouseout="jQuery(this).removeClass(\'cometchat_userlist_hover\');"><span class="cometchat_userscontentname">'+longname+'</span><span class="cometchat_userscontentdot cometchat_'+aj.status+'"></span></div>';tempBuddylistStatus[aj.id]=aj.status;tempBuddylistMessage[aj.id]=aj.message;tempBuddylistName[aj.id]=aj.name})}if(buddylistreceived==1){buddylistStatus=tempBuddylistStatus;m=tempBuddylistMessage;n=tempBuddylistName;for(buddystatus in ae){a("#cometchat_userstab_popup .cometchat_tabcontent .cometchat_userscontent .cometchat_userslist_"+buddystatus).html(ae[buddystatus]);a("#cometchat_userstab_popup .cometchat_tabcontent .cometchat_userscontent .cometchat_userslist_"+buddystatus).children().click(function(){A(this)})}buddylistreceived=0}if(ah=="loggedout"){a("#cometchat_optionsbutton").addClass("cometchat_optionsimages_exclamation");a("#cometchat_userstab").hide();a("#cometchat_chatboxes").hide();a("#cometchat_chatbox_left").hide();a("#cometchat_chatbox_right").hide();a("#cometchat_optionsbutton_popup").hide();a("#cometchat_userstab_popup").hide();a(".cometchat_tabopen").css("cssText","display: none !important;");if(Y!=""){a("#cometchat_user_"+Y+"_popup").hide();Y=""}t=1}if(ah=="userstatus"){a.each(ai,function(aj,ak){if(aj=="message"){a("#cometchat_optionsbutton_popup .cometchat_statustextarea").val(ak)}if(aj=="status"){if(ak=="offline"){O(1)}else{z();a("#cometchat_userstab_icon").addClass("cometchat_user_"+ak+"2");a("#cometchat_optionsbutton_popup ."+ak).css("text-decoration","underline")}}})}if(ah=="initialize"){a.each(ai,function(aj,al){if(aj=="buddylist"){if(al==1){a("#cometchat_userstab").click()}}if(aj=="activeChatboxes"){var am=al.split(/,/);for(i=0;i<am.length;i++){var ak=am[i].split(/\|/);Q(ak[0]);if(parseInt(ak[1])>0){U(ak[0],ak[1],0)}}}if(aj=="openChatboxId"){if(al!=""){a("#cometchat_userlist_"+al).click()}}});b("initialize","0")}if(ah=="updatesession"&&W!=1&&e("updatesession")!=1){R("updatingsession","1");a.each(ai,function(aj,am){if(aj=="buddylist"){if((am==0&&a("#cometchat_userstab").hasClass("cometchat_tabclick"))||(am==1&&!(a("#cometchat_userstab").hasClass("cometchat_tabclick")))){a("#cometchat_userstab").click()}}if(aj=="activeChatboxes"){if(am!=an){var ao=new Array;var al=new Array;if(am!=""){var an=am.split(/,/);for(i=0;i<an.length;i++){var ak=an[i].split(/\|/);ao[ak[0]]=ak[1]}}if(o("activeChatboxes")!=""){var an=o("activeChatboxes").split(/,/);for(i=0;i<an.length;i++){var ak=an[i].split(/\|/);al[ak[0]]=ak[1]}}for(x in ao){if(a("#cometchat_user_"+x).length>0){}else{Q(x)}}for(y in al){if(ao[y]==null){a("#cometchat_user_"+y+"_popup .cometchat_tabtitle .cometchat_closebox").click()}}}}if(aj=="openChatboxId"){if(am!=Y){if(Y!=""){a("#cometchat_user_"+Y).click()}if(am!=""){a("#cometchat_user_"+am).click()}}}});R("updatingsession","0");b("updatesession","0")}if(ah=="messages"){a.each(ai,function(al,aj){p=aj.id;if(parseInt(Y)==parseInt(aj.from)){++af;var ak=n[aj.from];if(aj.self==1){fromname="Me"}else{fromname=ak}aj.message=aj.message.replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/\"/g,"&quot;");if(a("#cometchat_message_"+aj.id).length>0){}else{ad+=('<div class="cometchat_chatboxmessage" id="cometchat_message_'+aj.id+'"><span class="cometchat_chatboxmessagefrom"><strong>'+fromname+'</strong>:&nbsp;&nbsp;</span><span class="cometchat_chatboxmessagecontent">'+aj.message+"</span></div>")}}else{P(aj.from,aj.message,aj.self,aj.old,aj.id)}});h=1;N=ab}});if(Y!=""&&af>0){a("#cometchat_user_"+Y+"_popup .cometchat_tabcontenttext").append(ad);a("#cometchat_user_"+Y+"_popup .cometchat_tabcontenttext").scrollTop(a("#cometchat_user_"+Y+"_popup .cometchat_tabcontenttext")[0].scrollHeight)}}b("initialize","0");b("updatesession","0");if(t!=1&&r!=1){h++;if(h>4){N*=2;h=1}if(N>I){N=I}clearTimeout(Z);Z=setTimeout(function(){B()},N)}}})}function j(){K();J();a("<div/>").attr("id","cometchat_chatbox_right").appendTo(a("#cometchat_base"));a("<span/>").addClass("cometchat_tabtext").appendTo(a("#cometchat_chatbox_right"));a("<span/>").css("top","-5px").css("display","none").addClass("cometchat_tabalertlr").appendTo(a("#cometchat_chatbox_right"));a("#cometchat_chatbox_right").bind("click",k);a("<div/>").attr("id","cometchat_chatboxes").appendTo(a("#cometchat_base"));a("<div/>").attr("id","cometchat_chatboxes_wide").appendTo(a("#cometchat_chatboxes"));a("<div/>").attr("id","cometchat_chatbox_left").appendTo(a("#cometchat_base"));a("<span/>").addClass("cometchat_tabtext").appendTo(a("#cometchat_chatbox_left"));a("<span/>").css("top","-5px").css("display","none").addClass("cometchat_tabalertlr").appendTo(a("#cometchat_chatbox_left"));a("#cometchat_chatbox_left").bind("click",d);s();aa();a("#cometchat_chatbox_right").mouseover(function(){a(this).addClass("cometchat_chatbox_lr_mouseover")});a("#cometchat_chatbox_right").mouseout(function(){a(this).removeClass("cometchat_chatbox_lr_mouseover")});a("#cometchat_chatbox_left").mouseover(function(){a(this).addClass("cometchat_chatbox_lr_mouseover")});a("#cometchat_chatbox_left").mouseout(function(){a(this).removeClass("cometchat_chatbox_lr_mouseover")});a(window).bind("resize",s);b("buddylist","1");b("initialize","1");b("updatesession","0");if(typeof document.body.style.maxHeight==="undefined"){w=true;a("#cometchat_base").css("position","absolute");a("#cometchat_tooltip").css("position","absolute");a("#cometchat_userstab_popup").css("position","absolute");a("#cometchat_optionsbutton_popup").css("position","absolute");a(window).bind("scroll",function(){E()})}a([window,document]).blur(function(){M=false}).focus(function(){if(M==false){l=1}M=true});B()}function E(){a("#cometchat_base").css("top",a(window).scrollTop()+a(window).height()-25);a("#cometchat_userstab_popup").css("top",parseInt(a(window).height())-parseInt(a("#cometchat_userstab_popup").css("bottom"))-parseInt(a("#cometchat_userstab_popup").height())+a(window).scrollTop()+"px");a("#cometchat_optionsbutton_popup").css("top",parseInt(a(window).height())-parseInt(a("#cometchat_optionsbutton_popup").css("bottom"))-parseInt(a("#cometchat_optionsbutton_popup").height())+a(window).scrollTop()+"px");if(a("#cometchat_tooltip").length>0){a("#cometchat_tooltip").css("top",parseInt(a(window).height())-parseInt(a("#cometchat_tooltip").css("bottom"))-parseInt(a("#cometchat_tooltip").height())+a(window).scrollTop()+"px")}if(Y!=""){a("#cometchat_user_"+Y+"_popup").css("position","absolute");a("#cometchat_user_"+Y+"_popup").css("top",parseInt(a(window).height())-parseInt(a("#cometchat_user_"+Y+"_popup").css("bottom"))-parseInt(a("#cometchat_user_"+Y+"_popup").height())+a(window).scrollTop()+"px")}}j()}})(jQuery);

/*
 * jQuery.ScrollTo
 * Copyright (c) 2007-2009 Ariel Flesler - aflesler(at)gmail(dot)com | http://flesler.blogspot.com
 * Dual licensed under MIT and GPL.
 * Date: 5/25/2009
 */

(function(c){var a=c.scrollTo=function(f,e,d){c(window).scrollTo(f,e,d)};a.defaults={axis:"xy",duration:parseFloat(c.fn.jquery)>=1.3?0:1};a.window=function(d){return c(window)._scrollable()};c.fn._scrollable=function(){return this.map(function(){var e=this,d=!e.nodeName||c.inArray(e.nodeName.toLowerCase(),["iframe","#document","html","body"])!=-1;if(!d){return e}var f=(e.contentWindow||e).document||e.ownerDocument||e;return c.browser.safari||f.compatMode=="BackCompat"?f.body:f.documentElement})};c.fn.scrollTo=function(f,e,d){if(typeof e=="object"){d=e;e=0}if(typeof d=="function"){d={onAfter:d}}if(f=="max"){f=9000000000}d=c.extend({},a.defaults,d);e=e||d.speed||d.duration;d.queue=d.queue&&d.axis.length>1;if(d.queue){e/=2}d.offset=b(d.offset);d.over=b(d.over);return this._scrollable().each(function(){var l=this,j=c(l),k=f,i,g={},m=j.is("html,body");switch(typeof k){case"number":case"string":if(/^([+-]=)?\d+(\.\d+)?(px|%)?$/.test(k)){k=b(k);break}k=c(k,this);case"object":if(k.is||k.style){i=(k=c(k)).offset()}}c.each(d.axis.split(""),function(q,r){var s=r=="x"?"Left":"Top",u=s.toLowerCase(),p="scroll"+s,o=l[p],n=a.max(l,r);if(i){g[p]=i[u]+(m?0:o-j.offset()[u]);if(d.margin){g[p]-=parseInt(k.css("margin"+s))||0;g[p]-=parseInt(k.css("border"+s+"Width"))||0}g[p]+=d.offset[u]||0;if(d.over[u]){g[p]+=k[r=="x"?"width":"height"]()*d.over[u]}}else{var t=k[u];g[p]=t.slice&&t.slice(-1)=="%"?parseFloat(t)/100*n:t}if(/^\d+$/.test(g[p])){g[p]=g[p]<=0?0:Math.min(g[p],n)}if(!q&&d.queue){if(o!=g[p]){h(d.onAfterFirst)}delete g[p]}});h(d.onAfter);function h(n){j.animate(g,e,d.easing,n&&function(){n.call(this,f,d)})}}).end()};a.max=function(j,i){var h=i=="x"?"Width":"Height",e="scroll"+h;if(!c(j).is("html,body")){return j[e]-c(j)[h.toLowerCase()]()}var g="client"+h,f=j.ownerDocument.documentElement,d=j.ownerDocument.body;return Math.max(f[e],d[e])-Math.min(f[g],d[g])};function b(d){return typeof d=="object"?d:{top:d,left:d}}})(jQuery);

jQuery(document).ready(function () { jQuery.cometchat(); });