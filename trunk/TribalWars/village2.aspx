<%@ Page Language="C#" AutoEventWireup="true" CodeFile="village2.aspx.cs" Inherits="village2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<?xml version="1.0" encoding="UTF-8" ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
		"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>001 Alpha (514|724) - Tribal Wars</title>
    <link rel="stylesheet" type="text/css" href="css/inventory.css" />
    <link rel="stylesheet" type="text/css" href="css/stamm_new_menu.css" />
    <link rel="stylesheet" type="text/css" href="css/stamm.css" />
    <link rel="stylesheet" type="text/css" href="css/overview.css" />

    <script src="/js/mootools.js" type="text/javascript"></script>



    <script src="js/ajax.js" type="text/javascript"></script>

    <script src="js/script.js" type="text/javascript"></script>

    <script src="js/menu.js" type="text/javascript"></script>

    <script type="text/javascript">
//<![CDATA[
var image_base = "/graphic";
//]]>
    </script>

</head>
<body id="ds_body">
    <form id="form1" runat="server">
    <div class="top_background">
    </div>
    <div style="text-align: center;">
        <table class="navi-border" style="width: 840px; border-collapse: collapse; margin: 11px auto auto;
            text-align: left;">
            <tr>
                <td>
                    <table class="menu nowrap" width="840">
                        <tr id="menu_row">
                            <td>
                                <a href="/game.php?village=51549&amp;screen=&amp;action=logout&amp;h=5157" target="_top">
                                    Log out</a>
                            </td>
                            <td>
                                <a href="http://forum.tribalwars.net/index.php" target="_blank">Forum</a>
                            </td>
                            <td>
                                <a href="help2.php" target="_blank">Help</a>
                            </td>
                            <td>
                                <a href="/game.php?village=51549&amp;screen=settings">Settings</a><br />
                                <table cellspacing="0" width="120" class="menu_column">
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=settings&amp;mode=profile">Profile</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=settings&amp;mode=email">Email address</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=settings&amp;mode=settings">Settings</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=settings&amp;mode=quickbar">Edit quick bar</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=settings&amp;mode=move">Start over</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=settings&amp;mode=delete">Delete account</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=settings&amp;mode=share">Share Internet
                                                connection</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=settings&amp;mode=vacation">Account Sitting</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=settings&amp;mode=logins">Logins</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=settings&amp;mode=change_passwd">Change
                                                password</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=settings&amp;mode=poll">Surveys</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <a href="/game.php?village=51549&amp;screen=premium">Premium</a><br />
                                <table cellspacing="0" width="120" class="menu_column">
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=premium&amp;mode=help">Advantages</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=premium&amp;mode=premium">Purchase</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=premium&amp;mode=points">Redeem</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=premium&amp;mode=log">Log</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <a href="/game.php?village=51549&amp;screen=ranking">Ranking</a> (114.|672<span class="grey">.</span>948
                                P)<br />
                                <table cellspacing="0" width="120" class="menu_column">
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=ranking&amp;mode=ally">Tribes</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=ranking&amp;mode=player">player</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=ranking&amp;mode=con_ally">Continent Tribes</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=ranking&amp;mode=con_player">Continent Players</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=ranking&amp;mode=kill_player">Opponents
                                                defeated</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=ranking&amp;mode=kill_ally">Opponents defeated
                                                tribal ranking</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <a href="/game.php?village=51549&amp;screen=ally&amp;mode=forum">
                                    <img src="/graphic/ally_forum.png" title="New post in private forum" alt="" /></a>
                                <a href="/game.php?village=51549&amp;screen=ally">Tribe</a><br />
                                <table cellspacing="0" width="120" class="menu_column">
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=ally&amp;mode=overview">Overview</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=ally&amp;mode=profile">Profile</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=ally&amp;mode=members">Members</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=ally&amp;mode=contracts">Diplomacy</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=ally&amp;redir_forum" target="_blank">Tribal
                                                forum</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <a href="/game.php?village=51549&amp;screen=report">Reports</a><br />
                                <table cellspacing="0" width="120" class="menu_column">
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=report&amp;mode=all">All reports</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=report&amp;mode=attack">Attacks</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=report&amp;mode=defense">Defenses</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=report&amp;mode=support">Support</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=report&amp;mode=trade">Trade</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=report&amp;mode=other">Miscellaneous</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=report&amp;mode=forwarded">Forwarded</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=report&amp;mode=filter">Filter</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=report&amp;mode=block">Block sender</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=report&amp;mode=public">Publicized reports</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <a href="/game.php?village=51549&amp;screen=mail">
                                    <img src="/graphic/new_mail.png" title="New message" alt="" />
                                    Mail</a><br />
                                <table cellspacing="0" width="120" class="menu_column">
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=mail&amp;mode=in">Mail</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=mail&amp;mode=mass_out">Circular mail</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=mail&amp;mode=new">Write message</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=mail&amp;mode=block">Block sender</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=mail&amp;mode=address">Address book</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="/game.php?village=51549&amp;screen=mail&amp;mode=groups">Groups</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <a href="/game.php?village=51549&amp;screen=memo">Notebook</a>
                            </td>
                            <td>
                                <a href="/game.php?village=51549&amp;screen=buddies">Friends</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <table align="center">
        <tr>
            <td>
                <table class="navi-border" style="border-collapse: collapse;">
                    <tr>
                        <td>
                            <ul class="menu nowrap quickbar">
                                <li><a href="/game.php?village=51549&amp;screen=main">
                                    <img src="/graphic/buildings/main.png" alt="Village Headquarters" />Village Headquarters</a></span></li>
                                <li><a href="/game.php?village=51549&amp;screen=train&amp;mode=mass">
                                    <img src="/graphic/buildings/barracks.png" alt="Recruit" />Recruit</a></span></li>
                                <li><a href="/game.php?village=51549&amp;screen=snob">
                                    <img src="/graphic/buildings/snob.png" alt="Academy" />Academy</a></span></li>
                                <li><a href="/game.php?village=51549&amp;screen=smith">
                                    <img src="/graphic/buildings/smith.png" alt="Smithy" />Smithy</a></span></li>
                                <li><a href="/game.php?village=51549&amp;screen=place">
                                    <img src="/graphic/buildings/place.png" alt="Rally point" />Rally point</a></span></li>
                                <li><a href="/game.php?village=51549&amp;screen=market">
                                    <img src="/graphic/buildings/market.png" alt="Market" />Market</a></span></li>
                                <li><a href="javascript:coords='648|790 647|797 644|781 658|793 640|780 645|787 643|786 644|790 641|777 644|779 644|787 640|784 645|785 642|787 627|783 636|786 654|795 627|788 639|780 634|795 632|797 636|787 633|796 630|792 642|774 636|770 637|769 615|786 617|793 631|799 625|788 616|789 617|781 617|782 635|786 666|777 661|778 662|777 673|778 668|776 665|777 665|752 674|753 673|755 659|757 632|775 636|785 647|787 613|789 643|797 643|796 605|797 620|781 624|782 622|786 624|790 628|777 618|783 621|781 625|797 621|795 622|797 625|791 623|796 622|795 632|787 622|796 629|786 625|786 632|796 634|797 654|807 648|808 646|806 638|800 652|809 626|804 639|821 624|808 635|814 642|822 640|817 624|806 640|801 614|804 633|817 623|809 631|809 622|806 629|813 631|813 626|809 635|817 628|802 632|813 642|804 641|813 637|810 642|803 634|808 635|811 641|810 648|804 647|801 634|823 628|819 620|821 622|820 621|824 622|836 631|806 634|804 635|803 616|846 615|841 625|830 610|846 612|840 616|833 618|827 619|830 683|807 693|803 684|810 613|802 631|816 620|837 657|815 661|816 655|815 619|809 627|811 619|814 646|818 646|811 622|817 652|815 633|837 629|832 629|833 629|800 649|834 625|802 627|804 624|823 624|816 683|822';var%20doc=document;if(window.frames.length&gt;0)doc=window.main.document;url=document.URL;if(url.indexOf('screen=place')==-1)alert('This%20script%20needs%20to%20be%20run%20from%20the%20rally%20point');coords=coords.split(&quot;%20&quot;);index=Math.round(Math.random()*(coords.length-1));counter=1;cookienoble=document.cookie.match('(^|;) ?noblefake=([^;]*)(;|$)');cookiecounter=document.cookie.match('(^|;) ?noblecounter=([^;]*)(;|$)');if(cookienoble!=null)index=parseInt(cookienoble[2]);if(cookiecounter!=null)counter=parseInt(cookiecounter[2]);if(counter==5)index=Math.round(Math.random()*(coords.length-1));if(counter==5)counter=1;coords=coords[index];coords=coords.split(&quot;|&quot;);counter=counter+1;cookie_date=new%20Date(2009,11,11);document.cookie=&quot;noblefake=&quot;+index+&quot;;expires=&quot;+cookie_date.toGMTString ();document.cookie =&quot;noblecounter=&quot;+counter+&quot;;expires=&quot;+cookie_date.toGMTString ();doc.forms[0].x.value=coords[0];doc.forms[0].y.value=coords[1];javascript:function i(){function j(b){function k(c,f,g){if(f==0){return 1;}if(g==0){return 0;}if(f&lt;0){f=g+f;}if(f&lt;=0){return 0;}if(f&lt;=g){c.value=f;return 1;}else{c.value=g;return 0;}}var d=document,g,c,e,l=1;if(window.frames.length&gt;0)d=window.main.document;var a=d.units.getElementsByTagName('input');for(var h=0;h&lt;(a.length-4)&amp;&amp;h&lt;b.length;h++){if(b[h]!=null&amp;&amp;b[h]!=0){e=a[h].nextSibling;do{e=e.nextSibling;}while(e.nodeType!=1);g=parseInt(e.firstChild.nodeValue.match(/(\d+)/)[1],10);l=l&amp;&amp;k(a[h],b[h],g);}}return l;}if(!j([,,,,,,1])){j([,,,,,,,1]);}}i();end();">
                                    random tribe</a></span></li>
                                <li><a href="javascript:var doc=document;if(window.frames.length&gt;0)doc=window.main.document;doc.forms[0].ram.value=1;end();">
                                    fillfakes</a><br />
                                    </span></li>
                                <li><a href="javascript:var doc=document;if(window.frames.length&gt;0)doc=window.main.document;url=document.URL;if(url.indexOf('screen=market&amp;mode=own_offer')==-1)alert('This%20script%20needs%20to%20be%20run%20from%20the%20market');doc.forms[0].sell.value=1000;doc.forms[0].buy.value=850;doc.forms[0].res_sell_stone.checked=true;doc.forms[0].res_buy_iron.checked=true;doc.forms[0].max_time.value=72;doc.forms[0].multi.value=50;doc.forms[0].submit();end();">
                                    iron</a></span></li>
                                <li><a href="/game.php?village=51549&amp;screen=market&amp;mode=own_offer">Offer page</a></span></li>
                                <li><a href="javascript:var doc=document;if(window.frames.length&gt;0)doc=window.main.document;var intDelayTime=500;var intCurrentTime;var intLaunchTime;function date(){var time=prompt(&quot;Sending Time&quot;, &quot;February, 02 2009 00:00:00&quot;);var launchTime=new Date();intCurrentTime = launchTime.getTime();launchTime.setTime(Date.parse(time));intLaunchTime=launchTime.getTime();setTimeout(&quot;checkTime()&quot;,intDelayTime);} function checkTime(){intCurrentTime+=intDelayTime;if(intCurrentTime&lt;intLaunchTime){setTimeout(&quot;checkTime()&quot;,intDelayTime);return;}doc.forms[0].submit.click();}date();end();">
                                    timer</a></span></li>
                                <li><a href="javascript:var i=1;var doc=document;if(window.frames.length&gt;0)doc=window.main.document;i+=2;doc.forms[0].ram.value=50;end();">
                                    statement</a></span></li>
                                <li><a href="javascript:var i;var doc=document;if(window.frames.length&gt;0)doc=window.main.document;i+=2;doc.forms[0].spy.value=50;doc.forms[0].light.value=i;end();">
                                    add</a></span></li>
                                <li><a href="javascript:var doc=document;if(window.frames.length&gt;0)doc=window.main.document;url=document.URL;if(url.indexOf('screen=market&amp;mode=own_offer')==-1)alert('This%20script%20needs%20to%20be%20run%20from%20the%20market');doc.forms[0].sell.value=1000;doc.forms[0].buy.value=850;doc.forms[0].res_sell_stone.checked=true;doc.forms[0].res_buy_wood.checked=true;doc.forms[0].max_time.value=72;doc.forms[0].multi.value=50;doc.forms[0].submit();end();">
                                    wood</a></span></li>
                                <li><a href="javascript:var%20configuration=[7110,0,0,200,0,2160,50,0,0,0];var%20archers=false;var%20units;var%20unitsNET;var%20costs;function%20arrayMin(array){var%20value=array[0];for%20(var%20t=1;t&lt;array.length;t++){if%20(array[t]&lt;value){value=array[t];}}return%20value;}function%20linearDivideArray(array1,%20array2){var%20value=[];if%20(array1.length==array2.length){for%20(var%20t=0;t&lt;array1.length;t++){if%20(array2[t]!=0){value[t]=array1[t]*1.0/array2[t];}else{value[t]=0;}}}return%20value;}function%20linearAddArray(array1,array2){var%20value=[];if%20(array1.length==array2.length){for%20(var%20t=0;t&lt;array1.length;t++){value[t]=array1[t]+array2[t];}}%20return%20value;}function%20getUnitId(unit){for%20(var%20t=0;t&lt;units.length;t++){if%20(unit%20==%20unitsNET[t]){return%20t;}}return%20-1;}function%20getTagsSubset(tagname,classname){var%20subset_t=document.getElementsByTagName(tagname);var%20subset_c=[];var%20u=0;for%20(var%20t=0;t&lt;subset_t.length;t++){if%20(subset_t[t].className==classname){subset_c[u++]=subset_t[t];}}return%20subset_c;}function%20getTable(){var%20candidates=getTagsSubset('table',%20'vis');%20var%20t;%20for%20(t=0;t&lt;candidates.length;t++){try%20{if%20(candidates[t].rows[0].cells[0].innerHTML=='Village'){break;}}catch%20(e){}}return%20candidates[t];}function%20getQueue(record){var%20value=[0,0,0,0,0,0,0,0,0,0];for%20(var%20u=3;u&lt;record.cells.length;u++){try{value[u%20-%203]=parseInt(record.cells[u].childNodes[1].childNodes[1].firstChild.title,10);}catch%20(e){}if%20(isNaN(value[u%20-%203])){value[u%20-%203]=0;}}return%20value;}function%20getResources(record){var%20value=[0,0,0,0];var%20res=record.cells[1].textContent.split(&quot;\n&quot;);var%20farm=record.cells[2].innerHTML.split('/');value[0]=parseInt(res[1].replace(&quot;.&quot;,&quot;&quot;),10);value[1]=parseInt(res[2].replace(&quot;.&quot;,&quot;&quot;),10);value[2]=parseInt(res[3].replace(&quot;.&quot;,&quot;&quot;),10);value[3]=farm[1]-farm[0];return%20value;}function%20getProduced(record){var%20value=[0,0,0,0,0,0,0,0,0,0];for%20(var%20u=3;u&lt;record.cells.length;u++){try{value[u%20-%203]=parseInt(record.cells[u].childNodes[1].textContent.split(&quot;\n&quot;)[2],10);}catch%20(e){}if%20(isNaN(value[u%20-%203])){value[u%20-%203]=0;}}return%20value;}function%20submitForm(){var%20candidates=document.getElementsByTagName(&quot;input&quot;);var%20t;for%20(t=0;t&lt;candidates.length;t++){if%20(candidates[t].type==&quot;submit&quot;){break;}}candidates[t].click();}if%20(document.URL.match('screen=train')&amp;&amp;document.URL.match('mode=mass')){var%20records=getTable().rows;if%20(archers){units=['spear','sword','axe','archer','spy','light','marcher','heavy','ram','catapult'];unitsNET=['Spear%20Fighter','Swordsman','Axeman','Archer','Scout','Light%20Cavalry','Mounted%20Archer',%20'Heavy%20Cavalry','Ram','Catapult'];costs=[[50,30,10,1],[30,30,70,1],[60,30,40,1],[100,30,60,1],[50,50,20,2],[125,100,250,4],[250,100,150,5],[200,150,600,6],%20[300,200,200,5],[320,400,100,8]];}else{units=['spear','sword','axe','spy','light','heavy','ram','catapult'];unitsNET=['Spear%20Fighter','Swordsman','Axeman','Scout','Light%20Cavalry','Heavy%20Cavalry','Ram','Catapult'];%20costs=[[50,30,10,1],[30,30,70,1],[60,30,40,1],[50,50,20,2],[125,100,250,4],[200,150,600,6],[300,200,200,5],[320,400,100,8]];}for%20(r=1;r&lt;records.length;r++){var%20subconf=[];var%20total_costs=[0,0,0,0];var%20i;var%20resources=getResources(records[r]);var%20queue=getQueue(records[r]);var%20produced=getProduced(records[r]);for%20(i=0;i&lt;units.length;i++){subconf[i]=configuration[i]-(queue[i]+produced[i]);if%20(subconf[i]&lt;0){subconf[i]=0;}for%20(var%20j=0;j&lt;4;j++){total_costs[j]+=costs[i][j]*subconf[i];}};var%20factor=arrayMin(linearDivideArray(resources,total_costs));if%20(factor&gt;1.0){factor=1.0;}for%20(i=0;i&lt;units.length;i++){var%20number=subconf[i]*factor;if%20(number&lt;0){number=0;}if%20(number!=0){if%20(records[r].cells[3%20+%20i].childNodes[3]){var%20ibox=records[r].cells[3%20+%20i].childNodes[3];try{ibox.defaultValue=parseInt(number,10);}catch%20(e){}}}}}stop();}else{alert('Script%20only%20works%20on%20the%20mass%20recruitment%20page');}">
                                    Massbuild D</a></span></li>
                                <li><a href="javascript:var%20configuration=[0,0,6620,100,3100,0,300,0,0,0];var%20archers=false;var%20units;var%20unitsNET;var%20costs;function%20arrayMin(array){var%20value=array[0];for%20(var%20t=1;t&lt;array.length;t++){if%20(array[t]&lt;value){value=array[t];}}return%20value;}function%20linearDivideArray(array1,%20array2){var%20value=[];if%20(array1.length==array2.length){for%20(var%20t=0;t&lt;array1.length;t++){if%20(array2[t]!=0){value[t]=array1[t]*1.0/array2[t];}else{value[t]=0;}}}return%20value;}function%20linearAddArray(array1,array2){var%20value=[];if%20(array1.length==array2.length){for%20(var%20t=0;t&lt;array1.length;t++){value[t]=array1[t]+array2[t];}}%20return%20value;}function%20getUnitId(unit){for%20(var%20t=0;t&lt;units.length;t++){if%20(unit%20==%20unitsNET[t]){return%20t;}}return%20-1;}function%20getTagsSubset(tagname,classname){var%20subset_t=document.getElementsByTagName(tagname);var%20subset_c=[];var%20u=0;for%20(var%20t=0;t&lt;subset_t.length;t++){if%20(subset_t[t].className==classname){subset_c[u++]=subset_t[t];}}return%20subset_c;}function%20getTable(){var%20candidates=getTagsSubset('table',%20'vis');%20var%20t;%20for%20(t=0;t&lt;candidates.length;t++){try%20{if%20(candidates[t].rows[0].cells[0].innerHTML=='Village'){break;}}catch%20(e){}}return%20candidates[t];}function%20getQueue(record){var%20value=[0,0,0,0,0,0,0,0,0,0];for%20(var%20u=3;u&lt;record.cells.length;u++){try{value[u%20-%203]=parseInt(record.cells[u].childNodes[1].childNodes[1].firstChild.title,10);}catch%20(e){}if%20(isNaN(value[u%20-%203])){value[u%20-%203]=0;}}return%20value;}function%20getResources(record){var%20value=[0,0,0,0];var%20res=record.cells[1].textContent.split(&quot;\n&quot;);var%20farm=record.cells[2].innerHTML.split('/');value[0]=parseInt(res[1].replace(&quot;.&quot;,&quot;&quot;),10);value[1]=parseInt(res[2].replace(&quot;.&quot;,&quot;&quot;),10);value[2]=parseInt(res[3].replace(&quot;.&quot;,&quot;&quot;),10);value[3]=farm[1]-farm[0];return%20value;}function%20getProduced(record){var%20value=[0,0,0,0,0,0,0,0,0,0];for%20(var%20u=3;u&lt;record.cells.length;u++){try{value[u%20-%203]=parseInt(record.cells[u].childNodes[1].textContent.split(&quot;\n&quot;)[2],10);}catch%20(e){}if%20(isNaN(value[u%20-%203])){value[u%20-%203]=0;}}return%20value;}function%20submitForm(){var%20candidates=document.getElementsByTagName(&quot;input&quot;);var%20t;for%20(t=0;t&lt;candidates.length;t++){if%20(candidates[t].type==&quot;submit&quot;){break;}}candidates[t].click();}if%20(document.URL.match('screen=train')&amp;&amp;document.URL.match('mode=mass')){var%20records=getTable().rows;if%20(archers){units=['spear','sword','axe','archer','spy','light','marcher','heavy','ram','catapult'];unitsNET=['Spear%20Fighter','Swordsman','Axeman','Archer','Scout','Light%20Cavalry','Mounted%20Archer',%20'Heavy%20Cavalry','Ram','Catapult'];costs=[[50,30,10,1],[30,30,70,1],[60,30,40,1],[100,30,60,1],[50,50,20,2],[125,100,250,4],[250,100,150,5],[200,150,600,6],%20[300,200,200,5],[320,400,100,8]];}else{units=['spear','sword','axe','spy','light','heavy','ram','catapult'];unitsNET=['Spear%20Fighter','Swordsman','Axeman','Scout','Light%20Cavalry','Heavy%20Cavalry','Ram','Catapult'];%20costs=[[50,30,10,1],[30,30,70,1],[60,30,40,1],[50,50,20,2],[125,100,250,4],[200,150,600,6],[300,200,200,5],[320,400,100,8]];}for%20(r=1;r&lt;records.length;r++){var%20subconf=[];var%20total_costs=[0,0,0,0];var%20i;var%20resources=getResources(records[r]);var%20queue=getQueue(records[r]);var%20produced=getProduced(records[r]);for%20(i=0;i&lt;units.length;i++){subconf[i]=configuration[i]-(queue[i]+produced[i]);if%20(subconf[i]&lt;0){subconf[i]=0;}for%20(var%20j=0;j&lt;4;j++){total_costs[j]+=costs[i][j]*subconf[i];}};var%20factor=arrayMin(linearDivideArray(resources,total_costs));if%20(factor&gt;1.0){factor=1.0;}for%20(i=0;i&lt;units.length;i++){var%20number=subconf[i]*factor;if%20(number&lt;0){number=0;}if%20(number!=0){if%20(records[r].cells[3%20+%20i].childNodes[3]){var%20ibox=records[r].cells[3%20+%20i].childNodes[3];try{ibox.defaultValue=parseInt(number,10);}catch%20(e){}}}}}stop();}else{alert('Script%20only%20works%20on%20the%20mass%20recruitment%20page');}">
                                    Massbuid O</a></span></li>
                                <li><a href="javascript:function createCookie(name,value){var expires = &quot;&quot;;document.cookie = name+&quot;=&quot;+value+expires+&quot;; path=/&quot;;};function readCookie(name){var nameEQ = name + &quot;=&quot;;var ca = document.cookie.split(';');for(var i=0;i &lt; ca.length;i++) {var c = ca[i];while (c.charAt(0)==' ') c = c.substring(1,c.length);if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);}return null;};coords=&quot;533|752 532|752 532|753 534|754 533|756 533|757 534|758 531|756 531|760 531|761 533|760 534|762 534|763 533|763 532|763 527|763 527|760 526|760 526|759 525|758 525|757 527|756 526|756 526|755 526|754 524|752 523|752 521|753 521|754 522|754 523|755 523|757 523|759 524|762 523|762 523|761 522|761 522|762 520|762 519|763 519|762 519|761 519|755 519|753 520|757 518|760 518|753 517|752 517|761 516|761 516|755 516|753 516|752 515|763 515|761 514|761 514|752 513|761 513|759 513|757 512|759 512|758 511|761 511|760 511|757 511|753 511|752 510|757 510|756 509|760 508|752 506|761 506|760 506|758 506|753 505|754 504|762 504|756 503|762 503|759 503|756 503|752 518|748 518|743 518|741 518|740 517|741 517|751 516|740 514|741 513|745 513|743 513|741 513|740 512|740 512|741 512|743 512|746 512|751 511|751 511|747 511|744 511|743 510|742 510|744 510|747 510|749 510|751 509|750 509|748 509|747 509|743 509|742 508|741 508|746 508|747 508|749 508|751 507|750 507|749 506|740 506|748 506|751 505|744 504|740 504|741 504|743 504|747 504|748 503|751 503|748 503|747 503|742 503|741 518|731 517|728 517|730 517|735 517|737 517|739 516|737 516|736 516|735 516|731 516|730 515|728 515|730 515|737 514|736 514|735 514|728 513|728 513|731 513|734 513|739 512|739 512|731 512|730 512|728 511|728 511|730 511|731 511|732 511|734 510|737 510|736 510|733 510|728 509|728 509|731 509|734 509|736 508|739 508|737 508|736 508|735 508|734 508|732 508|728 507|731 507|734 506|738 506|733 506|731 505|730 505|733 505|732 504|739 504|738 504|735 504|733 504|730 503|729 503|731 503|736 503|738 519|732 519|733 519|739 520|739 520|738 520|736 520|728 521|728 521|729 521|732 521|739 522|738 522|732 522|730 522|728 523|728 523|729 523|730 523|737 523|738 524|738 524|732 526|729 526|730 526|734 527|736 527|735 527|732 527|730 529|731 528|735 529|733 529|734 529|735 530|731 531|728 531|732 532|738 532|732 532|731 532|730 533|734 534|734 534|732 534|729 535|728 535|735 535|737 535|738 536|735 536|734 536|731 536|730 540|738 537|731 537|732 537|734 537|735 538|739 538|738 538|737 538|734 538|728 539|728 539|734 540|731 540|733 540|736 541|736 541|734 542|733 542|735 542|737 543|732 543|730 544|735 544|738 545|738 545|736 545|732 545|731 547|729 547|730 547|735 547|737 547|738 548|731 548|730 549|729 549|731 549|732 549|737 550|736 550|733 550|732 550|742 550|743 550|745 550|748 549|748 549|743 547|742 547|746 547|748 547|749 547|751 545|749 545|748 545|746 545|740 544|743 543|740 543|743 543|744 543|747 543|750 543|751 542|750 542|746 542|741 542|740 540|740 540|741 540|744 540|748 539|750 539|748 539|746 539|744 538|743 537|740 537|741 537|743 537|748 537|751 536|748 536|747 535|747 535|749 535|751 550|753 550|761 549|757 548|762 548|761 548|758 548|754 547|754 547|755 547|756 547|757 547|762 547|763 546|761 546|756 545|760 544|761 544|760 544|757 544|755 544|754 543|752 543|755 543|756 543|757 543|758 543|759 543|760 542|758 542|757 541|753 541|756 541|761 541|762 540|762 540|754 539|753 539|762 538|762 537|754 536|753 535|753 535|754 536|755 536|757 535|758 535|759 536|760 536|762 535|763 550|764 550|768 549|767 549|770 549|771 548|770 547|765 547|768 547|773 546|766 546|767 546|770 546|775 545|775 544|764 544|766 544|767 544|768 544|772 544|774 544|775 543|770 542|771 541|764 541|766 541|771 535|773 541|772 541|774 541|775 540|775 540|766 540|765 540|764 539|765 539|768 538|766 538|767 536|772 536|764 535|764 534|774 534|769 534|768 534|767 533|769 532|768 531|775 529|775 529|768 529|766 530|764 527|764 528|768 528|770 528|771 527|771 526|768 526|769 525|773 524|773 523|766 523|765 523|764 522|764 522|765 522|768 520|764 519|769 521|771 520|771 520|772 520|773 519|775 518|770 518|764 517|769 516|764 516|765 516|767 516|769 516|770 516|773 515|771 515|770 514|768 514|775 513|773 513|771 513|770 513|769 513|765 513|764 512|764 512|770 511|765 511|767 510|764 510|771 510|773 509|770 509|769 509|768 508|768 508|773 507|775 507|773 507|772 507|771 506|774 506|764 505|767 505|770 504|775 504|773 503|775 503|772 503|770 503|765 566|752 566|754 566|755 566|756 565|755 565|756 565|757 564|756 565|761 565|762 564|761 564|760 564|758 564|757 563|752 563|759 563|760 563|761 562|762 562|755 561|763 560|762 560|761 560|759 560|757 560|755 559|758 559|763 558|757 558|755 558|754 557|754 557|755 556|756 556|759 556|760 556|762 555|758 555|756 553|759 553|761 552|756 552|761 551|763 551|762 551|752&quot;;var doc=document;if(window.frames.length&gt;0)doc=window.main.document;url=document.URL;if(url.indexOf('screen=place')==-1)alert('This%20script%20needs%20to%20be%20run%20from%20the%20rally%20point');coords=coords.split(&quot; &quot;);var maxIndex=coords.length-1;var index=readCookie(&quot;farm&quot;);if (index==null) index=0;index++; if (index&gt;maxIndex)index=0;createCookie(&quot;farm&quot;, index);coords=coords[index];coords=coords.split(&quot;|&quot;);doc.forms[0].x.value=coords[0];doc.forms[0].y.value=coords[1];doc.forms[0].light.value=50;doc.forms[0].attack.click();end();">
                                    Farm1</a></span></li>
                                <li><a href="javascript:function createCookie(name,value){var expires = &quot;&quot;;document.cookie = name+&quot;=&quot;+value+expires+&quot;; path=/&quot;;};function readCookie(name){var nameEQ = name + &quot;=&quot;;var ca = document.cookie.split(';');for(var i=0;i &lt; ca.length;i++) {var c = ca[i];while (c.charAt(0)==' ') c = c.substring(1,c.length);if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);}return null;};coords=&quot;502|764 523|764 489|765 489|766 540|764 536|764 508|768 527|764 492|765 506|764 505|767 520|764 516|764 509|769 509|768 502|766 480|768 538|767 484|766 513|765 522|765 511|765 509|770 502|765 529|766 495|767 513|764 518|764 534|768 496|766 522|764 492|769 482|771 523|765 495|771 479|764 510|764 501|768 534|767 516|767 483|769 503|770 500|768 516|769 480|764 529|768 541|764 507|773 513|770 514|768 491|772 526|769 506|774 518|770 516|765 481|766 511|767 503|765 540|766 483|767 513|769 494|766 503|768 538|766 539|765 520|773 496|769 526|768 497|770 502|770 540|765 523|766 498|767 535|764 528|771 502|771 527|769 512|764 541|772 541|768 488|770 482|772 485|766 492|764 521|771 505|776 515|771 497|772 482|776 523|776 495|769 488|777 503|772 524|773 479|773 535|773 492|778 520|771 512|770 532|768 492|773 519|775 530|777 479|775 522|777 504|775 486|766 534|769 541|775 486|776 486|779 513|773 508|773 525|773 515|770 511|779 487|768 541|766 480|776 520|772 524|767 522|778 492|779 504|773 531|776 496|776 498|779 527|771 540|776 502|776 516|773 523|777 497|779 517|769 507|771 541|770 479|771 479|772 484|773 528|770 492|776 489|774 533|769 531|779 529|778 534|774 507|782 510|771 516|770 522|768 528|768 514|775 529|776 481|773 517|778 519|769 507|780 516|778 497|783 523|780 529|775 519|778 505|778 515|777 525|776 495|774 532|777 539|768 505|770 517|776 514|783 517|774 487|781 491|779 534|779 481|776 541|774 513|771 482|779 502|779 505|780 503|776 506|780 510|773 527|782 495|775 531|775 531|777 513|779 501|775 537|778 507|772 499|784 503|775 536|772 500|778 535|777 516|777 517|785 494|784 482|778 492|782 502|784 539|780 526|782 541|771 507|786 540|775 480|780 494|779 535|783 531|786 503|781 501|786 517|786 485|777 502|785 480|782 531|785 497|778 532|784 499|785 479|787 539|785 534|782 512|787 479|781 528|781 507|775 533|782 517|788 539|782 484|786 541|779 512|778 538|779 498|786 516|788 491|787 482|783 522|787 503|780 527|780 516|776 511|787 530|787 537|776 539|777 504|787 536|780 498|780 502|782 515|786 534|784 480|785 541|783 523|785 518|786 517|777 523|784 522|785 506|779 527|776 538|782 484|789 480|783 520|785 486|785 491|786 503|779 495|784 503|785 540|779 504|783 505|786 522|783 530|782 541|784 532|790 533|789 534|790 535|789 480|784 527|784 533|778 539|776 494|787 482|787 488|781 484|790 490|783 488|780 515|792 539|781 491|785 481|783 539|787 503|784 531|787 534|783 534|787 529|779 502|792 487|780 524|785 539|790 497|794 513|780 532|792 497|791 486|787 534|786 493|794 537|780 540|785 532|791 507|793 518|794 524|786 496|794 525|782 538|780 514|791 535|782 517|789 488|786 486|788 511|790 491|784 496|793 501|787 521|788 537|786 524|784 493|785 496|791 540|782 484|784 539|786 515|793 523|791 489|785 528|793 521|786 480|793 499|795 495|788 524|795 485|785 492|796 486|790 536|786 533|790 490|786 502|794 535|784 509|786 512|794 507|790 502|798 491|796 536|791 502|786 514|794 481|790 513|792 535|791 502|791 527|788 497|784 530|789 514|787 538|785 531|792 489|792 534|795 505|790 508|790 536|783 504|795 534|794 507|796 485|797 538|794 538|791 522|798 514|790 505|793 522|788 515|794 482|795 529|795 507|788 532|798 494|794 481|793 490|795 500|791 519|798 500|792 517|799 483|798 535|799 525|791 485|796 493|796 489|800 493|799 539|794 511|798 499|794 525|792 537|790 482|792 513|801 493|791 516|794 484|795 510|793 507|799 520|787 532|793 505|798 506|801 522|795 535|786 514|788 539|799 514|789 524|799 538|790 534|796 479|794 479|799 490|791 518|801 516|793 486|795 532|800 519|793 532|801 481|796 524|800 530|801 509|803 505|801 520|800 504|794 502|803 521|798 502|795 495|802 504|802 485|795 485|802 520|797 527|789 485|799 503|801 485|800 502|804 522|794 515|795 490|798 484|798 490|797 508|800 539|795 481|798 523|790 541|789 495|800 537|799 501|805 540|791 530|793 520|796 516|804 499|800 541|803 496|792 525|803 531|802 526|805 499|796 523|794 504|792 539|797 501|795 521|794 512|802 535|805 511|806 539|802 508|793 508|807 524|793 484|799 525|799 513|797 541|799 516|799 517|796 520|805 502|805 528|795 502|793 518|804 513|798 511|799 526|793 526|799 504|803 540|801 508|798 528|801 526|806 487|798 486|799 479|793 537|802 519|802 509|808 526|804 486|805 497|805 512|805 503|794 485|808 513|807 532|795 511|796 535|807 518|808 507|803 536|804 516|808 480|805 506|803 501|804 495|808 527|801 497|807 484|807 494|797 535|800 531|799 492|806 487|805 494|807 528|797 486|802 501|802 506|802 536|806 479|802 541|797 529|800 528|808 540|797 528|809 514|804 513|805 492|810 539|807 517|809 498|809 480|797 533|802 523|798 535|795 524|807 492|812 522|808 526|808 484|800 518|798 483|801 518|802 523|812 524|809 484|804 493|808 489|809 536|805 514|802 484|803 513|799 487|804 539|806 521|806 539|800 495|811 527|812 490|805 519|803 509|810 535|811 493|805 505|799 482|803 537|807 515|805 520|810 518|811 496|802 539|810 494|808 507|802 502|809 496|803 508|810 515|811 529|803 482|809 496|808 523|800 511|802 487|807 523|809 492|808 498|807 533|812 519|805 519|810 516|806 526|812 510|809 509|802 515|809 530|809 509|804 490|809 487|811 537|803 535|812 494|809 481|811 508|812 506|812 514|809 535|806 491|809 532|812 506|810 537|801 523|808 511|812 514|810 481|806 488|811 540|809 494|806 507|808 515|808 498|810 483|811 524|806 511|811 517|810 522|811 541|809 481|812 508|808 500|812 500|810 540|812 522|810 493|811 486|810 510|812 531|810 539|811 538|810 541|812&quot;;var doc=document;if(window.frames.length&gt;0)doc=window.main.document;url=document.URL;if(url.indexOf('screen=place')==-1)alert('This%20script%20needs%20to%20be%20run%20from%20the%20rally%20point');coords=coords.split(&quot; &quot;);var maxIndex=coords.length-1;var index=readCookie(&quot;farm2&quot;);if (index==null) index=0;index++; if (index&gt;maxIndex)index=0;createCookie(&quot;farm2&quot;, index);coords=coords[index];coords=coords.split(&quot;|&quot;);doc.forms[0].x.value=coords[0];doc.forms[0].y.value=coords[1];doc.forms[0].light.value=50;doc.forms[0].attack.click();end();">
                                    farm2</a></span></li>
                                <li><a href="javascript:function createCookie(name,value){var expires = &quot;&quot;;document.cookie = name+&quot;=&quot;+value+expires+&quot;; path=/&quot;;};function readCookie(name){var nameEQ = name + &quot;=&quot;;var ca = document.cookie.split(';');for(var i=0;i &lt; ca.length;i++) {var c = ca[i];while (c.charAt(0)==' ') c = c.substring(1,c.length);if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);}return null;};coords=&quot;662|722 667|724 658|730 659|725 658|722 659|729 665|724 660|731 658|733 662|728 660|725 662|729 671|722 662|731 667|723 674|722 665|728 664|731 669|724 658|735 658|737 662|730 660|726 659|726 672|723 677|722 670|732 681|722 666|735 666|732 661|739 672|730 661|725 671|730 668|727 666|728 674|726 662|740 663|739 675|724 674|729 681|723 674|731 660|741 670|723 666|726 674|728 663|740 658|732 676|724 662|732 659|736 670|725 672|733 676|725 673|728 658|736 670|729 671|733 671|729 688|723 664|737 664|736 668|724 669|730 664|726 659|746 669|726 674|724 667|732 684|726 678|722 662|734 680|727 668|728 674|732 681|724 658|734 667|735 667|743 661|738 665|737 685|722 672|729 660|747 681|734 660|738 675|728 670|726 660|740 663|746 683|722 668|742 663|734 694|724 688|729 661|740 682|722 677|724 659|752 681|726 675|740 672|732 685|725 678|728 678|731 667|744 693|722 668|735 679|726 685|728 676|736 682|728 669|733 668|738 680|732 691|728 674|739 661|753 682|726 668|743 697|725 667|739 683|726 665|748 688|734 679|733 662|739 668|747 664|746 689|728 684|728 686|730 668|740 658|751 701|723 677|729 680|740 693|727 681|727 700|726 702|724 663|738 669|738 660|751 678|729 686|724 697|722 665|746 687|735 672|744 675|734 677|743 699|725 667|746 672|736 677|744 661|748 663|756 692|723 678|740 669|743 678|732 676|745 662|741 678|736 690|724 696|729 692|730 660|744 682|740 678|741 687|737 683|737 671|746 675|746 676|740 690|732 692|731 679|744 691|733 689|733 695|726 676|732 703|727 697|734 702|728 662|756 670|745 688|738 691|736 682|744 664|753 678|733 702|723 663|751 673|736 672|749 685|741 690|734 669|747 660|756 697|731 665|753 674|743 663|745 686|736 696|733 678|734 677|736 700|731 689|741 701|728 669|742 686|728 683|744 678|750 664|751 692|735 668|748 700|725 696|728 679|747 678|735 680|741 664|744 686|734 683|734 681|740 675|742 670|743 670|757 687|727 658|764 675|736 684|739 681|746 678|744 696|738 658|757 671|755 678|737 671|753 667|759 695|738 698|729 684|744 667|758 661|755 687|729 704|725 658|762 679|742 699|736 678|752 668|745 675|749 670|749 682|736 691|744 694|727 676|750 676|748 670|744 686|740 690|731 685|736 658|750 698|730 680|751 675|743 681|748 695|740 682|750 687|744 678|754 678|747 677|740 696|734 663|757 686|748 697|733 673|749 669|758 685|735 671|745 659|756 658|752 682|743 698|725 659|765 671|750 674|748 673|757 677|738 694|741 696|725 693|743 690|738 689|747 697|739 688|730 700|729 667|762 672|758 687|748 675|744 680|744 681|750 666|751 668|760 662|755 696|739 664|766 671|757 658|753 661|764 683|736 670|760 664|761 663|761 676|744 695|736 667|750 661|751 662|762 688|735 704|728 671|761 700|734 661|765 684|742 699|732 660|759 702|727 698|739 674|761 660|760 688|744 690|737 686|739 670|752 699|738 666|764 665|750 667|757 704|723 689|738 690|743 664|762 688|748 697|735 672|764 685|755 683|742 689|737 700|736 698|726 681|742 677|755 671|765 679|750 666|766 682|753 668|764 676|754 676|756 695|741 691|741 675|759 670|751 666|761 690|742 678|761 670|764 695|739 704|737 658|756 682|749 702|736 692|737 698|728 698|731 697|728 703|736 694|734 677|747 658|767 659|767 689|739 686|743 680|760 695|734 699|735 689|743 696|748 684|743 666|767 696|741 702|741 682|745 658|759 672|760 664|764 676|763 688|755 677|763 704|743 692|746 670|759 696|745 695|733 663|764 694|733 682|758 688|752 697|746 661|760 684|749 681|759 694|742 676|749 659|759 693|753 685|745 697|749 680|748 676|765 696|736 665|762 683|760 662|766 661|766 676|764 697|744 693|744 678|764 686|745 691|757 697|736 663|765 694|757 704|731 671|763 659|764 668|762 682|763 688|762 675|763 680|761 692|747 683|750 675|754 685|765 670|765 686|758 698|754 684|752 669|765 704|747 677|754 703|747 690|748 695|760 687|765 686|756 701|747 681|752 676|759 678|762 691|755 689|748 697|751 671|762 682|767 692|760 686|766 686|763 697|761 673|760 691|758 697|760 693|752 668|765 694|760 696|757 701|756 675|766 698|752 693|763 695|757 694|754 700|761 683|764 694|755 697|763 673|763 696|751 699|751 681|763 701|755 696|752 690|758 683|757 693|761 689|765 693|762 690|757 701|743 694|765 702|755 677|765 679|767 685|767 700|763 687|759 695|758 677|764 704|760 698|767 685|763 689|755 702|747 699|761 681|765 697|764 683|763 700|760 684|765 686|760 693|766 697|752 689|759 691|765 694|756 699|767 699|754 703|758 703|749 682|764 688|761 700|766 695|756 701|766 687|763 703|755 696|756 685|766 699|763 704|756 694|764 691|764 699|757 695|764 700|767 702|763 701|759 695|767 693|767 704|767 694|767 704|761 704|764 670|742&quot;;var doc=document;if(window.frames.length&gt;0)doc=window.main.document;url=document.URL;if(url.indexOf('screen=place')==-1)alert('This%20script%20needs%20to%20be%20run%20from%20the%20rally%20point');coords=coords.split(&quot; &quot;);var maxIndex=coords.length-1;var index=readCookie(&quot;farm2&quot;);if (index==null) index=0;index++; if (index&gt;maxIndex)index=0;createCookie(&quot;farm2&quot;, index);coords=coords[index];coords=coords.split(&quot;|&quot;);doc.forms[0].x.value=coords[0];doc.forms[0].y.value=coords[1];doc.forms[0].light.value=50;doc.forms[0].attack.click();end();">
                                    farm3</a></span></li>
                                <li><a href="javascript:var troop_quantity=60;var doc=document;if(window.frames.length&gt;0)doc=window.main.document;doc.forms[0].light.value=troop_quantity;doc.forms[0].attack.click();end();">
                                    fill</a></span></li>
                                <li><a href="javascript:var troop_quantity=60;var doc=document;if(window.frames.length&gt;0)doc=window.main.document;url=document.URL;function gup(name, url){name=name.replace(/[\[]/,&quot;\\\[&quot;).replace(/[\]]/,&quot;\\\]&quot;);var regexS=&quot;[\\?&amp;]&quot;+name+&quot;=([^&amp;#]*)&quot;;var regex=new RegExp(regexS);var results=regex.exec(url);if(results==null)return &quot;&quot;;else return results[1];};function troop_count(troop,d){var g,e;var h=d.units[troop];if(h==null)return 0;e=h.nextSibling;do{e=e.nextSibling;}while(e.nodeType!=1);g=parseInt(e.firstChild.nodeValue.match(/(\d+)/)[1],10);return g;};function createCookie(name,value){var expires = &quot;&quot;;document.cookie = name+&quot;=&quot;+value+expires+&quot;; path=/&quot;;};function readCookie(name){var nameEQ = name + &quot;=&quot;;var ca = document.cookie.split(';');for(var i=0;i &lt; ca.length;i++) {var c = ca[i];while (c.charAt(0)==' ') c = c.substring(1,c.length);if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);}return null;};var page_count=parseInt(troop_count('light', doc))/troop_quantity;var village=gup(&quot;village&quot;, url);var farm=&quot;52033 52957 53104 53241 53557 53654 53753 53754 53886 53914 53943 54044 54076 54107 54182 54239 54326 54653 54717 54872 54879 54942 54996 55031 55139 55185 55258 55287 55369 55416 55489 55525 55527 55597 55624 55640 55646 55650 55684 55766 55804 55831 55901 55902 55927 56024 56037 56145 56156 56396 56474 56512 56572 56583 56607 56636 56640 56642 56660 56668 56680 56702 56977 56982 57016 57089 57177 57217 57245 57267 57278 57324 57346 57376 57380 57400 57428 57477 57578 57593 57614 57616 57661 57761 57775 57778 57798 57838 57904 57976 57977 57984 58051 58080 58168 58185 58208 58221 58240 58274 58300 58361 58370 58455 58478 58533 58551 58579 58725 58744 58762 58815 58865 58892 58895 58965 59082 59090 59147 59263 59272 59299 59480 59531 59565 59665 59689 59692 59716 59748 59773 59775 59801 59944 60001 60032 60056 60063 60073 60245 60247 60281 60382 60459 60465 60559 60724 60746 60796 60808 60828 60980 60988 61003 61025 61030 61034 61064 61100 61118 61126 61221 61228 61317 61406 61410 61449 61466 61569 61576 61582 61619 61669 61712 61717 61821 61915 61933 61945 61952 61987 62116 62136 62172 62244 62250 62263 62357 62380 62399 62410 62478 62578 62579 62589 62604 62686 62856 62860 62947 62977 63002 63011 63042 63052 63076 63077 63121 63146 63239 63240 63246 63281 63285 63299 63330 63333 63443 63458 63484 63489 63496 63503 63565 63566 63580 63588 63653 63683 63706 63756 63765 63826 63841 63887 63890 63914 63918 64005 64092 64096 64104 64117 64133 64224 64413 64444 64445 64536 64616 64676 64703 64701 64702 64730 64743 64821 64889 64910 64982 65022 65055 65071 65101 65144 65169 65212 65300 65305 65428 65448 65463 65703 65775 65780 65999 66003 66057 66151 66193 66217 66220 66227 66242 66304 66362 66370 66453 66473 66535 66544 66587 66702 66772 66779 66791 66820 66934 66946 66952 66961 67080 67116 67138 67171 67366 67439 67509 67775 67790 67812 67846 67928 68016 68068 68097 68123 68194 68361 68435 68441 68458 68780 68837 68849 68885 68995 69046 69056 69107 69151 69170 69361 69407 69411 69541 69577 69686 69722 69734 69761 69781 69799 69844 69878 69989 70009 70046 70128 70145 70164 70335 70423 70494 70594 71144 71400 71468 71655 71719 71762 71816 72010 72031 72186 72274 72354 72388 72394 72487 72766 72989 73052&quot;;farm=farm.split(&quot; &quot;);var maxIndex=farm.length-1;page_count=parseInt(page_count);var index=readCookie(&quot;f1&quot;);if (index==null) index=0;var i;for (i=1;i&lt;page_count;i++){index++;if (index&gt;maxIndex)index=0; farm1=farm[index];window.open(&quot;http://en21.tribalwars.net/staemme.php?village=&quot;+village+&quot;&amp;screen=place&amp;mode=command&amp;target=&quot;+farm1)}createCookie(&quot;f1&quot;, index);end();">
                                    f1</a></span></li>
                                <li><a href="javascript:var troop_quantity=60;var doc=document;if(window.frames.length&gt;0)doc=window.main.document;url=document.URL;function gup(name, url){name=name.replace(/[\[]/,&quot;\\\[&quot;).replace(/[\]]/,&quot;\\\]&quot;);var regexS=&quot;[\\?&amp;]&quot;+name+&quot;=([^&amp;#]*)&quot;;var regex=new RegExp(regexS);var results=regex.exec(url);if(results==null)return &quot;&quot;;else return results[1];};function troop_count(troop,d){var g,e;var h=d.units[troop];if(h==null)return 0;e=h.nextSibling;do{e=e.nextSibling;}while(e.nodeType!=1);g=parseInt(e.firstChild.nodeValue.match(/(\d+)/)[1],10);return g;};function createCookie(name,value){var expires = &quot;&quot;;document.cookie = name+&quot;=&quot;+value+expires+&quot;; path=/&quot;;};function readCookie(name){var nameEQ = name + &quot;=&quot;;var ca = document.cookie.split(';');for(var i=0;i &lt; ca.length;i++) {var c = ca[i];while (c.charAt(0)==' ') c = c.substring(1,c.length);if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);}return null;};var page_count=parseInt(troop_count('light', doc))/troop_quantity;var village=gup(&quot;village&quot;, url);var farm=&quot;66145 66779 66791 67080 67657 68016 68043 68390 68755 69046 69056 69068 69107 69151 69173 69194 69361 69577 69686 69750 69781 69941 70046 70128 70145 70164 70311 70335 70407 70494 70495 70619 70642 70838 70870 71144 71326 71180 71229 71363 71477 71658 71618 71655 71718 71719 71794 71816 71923 72206 72274 72296 72361 72365 72394 72428 72623 72766 72814 72989 73065 73066 73077 73114 73249 73294 73313 73342 73376 73569 73654 73792 73939 74008 74143 74161 74236 74373 74467 74595 74631 74641 74705 74716 74756 74837 74984 75113 75116 75583 75241 75308 75330 75339 75384 75429 75444 75687 75710 75892 76016 76043 76107 76199 76276 76285 76296 76301 76303 76351 76363 76410 76471 76577 76598 76732 76801 76826 76889 77026 77175 77225 77310 77330 77338 77405 77468 77712 77711 77773 77835 78005 78061 78077 78093 78101 78220 78246 78663 78748 78824 78834 78841 78869 78974 79076 79203 79257 79341 79513 79550 79570 79732 79797 79960 79993 80005 80102 80176 80233 80301 80380 80459 80483 80500 80508 80534 80835 80864 80903 80953 80971 80996 81151 81200 81143 81553 81643 81752 81774 81785 81962 82045 82142 82238 82241 82329 82402 82467 82513 82707 82744 82751 82899 83006 83032 83067 83178 83183 83293 83350 83375 83380 83443 83466 83471 83623 83631 83674 83833 83849 83933 83955 84171 84177 84221 84290 84402 84530 84534 84565 84570 84595 84615 84639 84673 84723 84971 84915 84975 84979 85078 85216 85356 85431 85507 85512 85528 85708 85764 85981 85990 86005 86008 86052 86321 86402 86433 86503 86580 86595 86613 86631 86731 86761 86825 86895 86893 86915 86964 86982 87003 87067 87123 87443 87493 87514 87553 87651 87864 88032 87962 87975 87997 88028 88040 88059 88215 88223 88402 88535 88600 88648 88657 88662 88675 89017 89349 89448 89457 89498 89581 89648 89696 89721 89731 90057 89980 90087 90096 90134 90219 90333 90341 90363 90415 90432 90460 90493 90622 90812 91380 91247 91879 92158 92167 92229 92708 92978 93149 93494 93650 93958 94150 94841 94874 94962 95298 95353 95920&quot;;farm=farm.split(&quot; &quot;);var maxIndex=farm.length-1;page_count=parseInt(page_count);var index=readCookie(&quot;f1&quot;);if (index==null) index=0;var i;for (i=0;i&lt;page_count;i++){index++;if (index&gt;maxIndex)index=0; farm1=farm[index];window.open(&quot;http://en21.tribalwars.net/staemme.php?village=&quot;+village+&quot;&amp;screen=place&amp;mode=command&amp;target=&quot;+farm1)}createCookie(&quot;f1&quot;, index);end();">
                                    f2</a></span></li>
                                <li><a href="javascript:var troop_quantity=60;var doc=document;if(window.frames.length&gt;0)doc=window.main.document;url=document.URL;function gup(name, url){name=name.replace(/[\[]/,&quot;\\\[&quot;).replace(/[\]]/,&quot;\\\]&quot;);var regexS=&quot;[\\?&amp;]&quot;+name+&quot;=([^&amp;#]*)&quot;;var regex=new RegExp(regexS);var results=regex.exec(url);if(results==null)return &quot;&quot;;else return results[1];};function troop_count(troop,d){var g,e;var h=d.units[troop];if(h==null)return 0;e=h.nextSibling;do{e=e.nextSibling;}while(e.nodeType!=1);g=parseInt(e.firstChild.nodeValue.match(/(\d+)/)[1],10);return g;};function createCookie(name,value){var expires = &quot;&quot;;document.cookie = name+&quot;=&quot;+value+expires+&quot;; path=/&quot;;};function readCookie(name){var nameEQ = name + &quot;=&quot;;var ca = document.cookie.split(';');for(var i=0;i &lt; ca.length;i++) {var c = ca[i];while (c.charAt(0)==' ') c = c.substring(1,c.length);if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);}return null;};var page_count=parseInt(troop_count('light', doc))/troop_quantity;var village=gup(&quot;village&quot;, url);var farm=&quot;84769 85329 85698 86623 87589 87731 88024 88068 88083 88439 88481 88509 88523 88590 88615 88707 88989 89065 89072 89337 89747 89770 89985 90028 90144 90180 90343 90357 90405 90423 90542 90546 90554 90814 90588 90699 90882 90997 91200 91232 91479 91351 91375 91409 91530 91536 91677 91740 91841 91857 91867 92109 91972 92014 92026 92091 92102 92130 92409 92543 92583 92602 92621 92872 92709 92749 92815 92818 92857 92865 92938 93146 93252 93260 93526 93715 93719 93772 93814 94017 94140 94379 94391 94461 94843 94665 94669 94670 94905 94910 94936 94972 94993 95001 95012 95109 95113 95194 95203 95290 95387 95432 95442 95443 95689 95730 95897 95928 96057 96204 96218 96221 96521 96523 96554 96574 96576 96587 96593 96676 96709 96922 97002 97013 97119 97183 97195 97214 97256 97282 97328 97566 97611 97747 97855 97911 97983 98068 98740 98804 98877 99055 99085 99478 99503 99580 99828 99850 99886 99928 99970 100008 100070 100182 100316 100329 100387 100402 100546 100563 100726 100879 100896 101084 101158 101188 101290 101311 101421 101487 101630 101651 101697 101923 101987 102152 102285 102396 102511 102574 102756 102883 102926 103036 103106 103137 103143 103179 103243 103278 103316 103612 103496 103469 103528 103548 103590 103613 103648 103658 103897 103790 103794 103902 104091 104188 104221 104224 104443 104315 104371 104400 104439 104490 104562 104600 104903 104945 104951 104955 105017 105022 105138 105193 105349 105394 105553 105608 105626 105709 105765 105856 105963 105973 106017 106070 106193 106445 106481 106632 106719 107011 107066 107095 107118 107246 107532 107553 107723 107739 107855 107856 107913 108033 108178 108196 108291 108299 108377 108380 108394 108445 108454 108514 108531 108776 108815 108834 109026 109103 109424 109635 109885 109896 110288 110320 110488 110502 110657 110698 110837 110835 110882 110904 110992 111227 111316 111375 111427 111481 111538 111561 111685 111711 111767 112033 112080 112347 112722 112776 112943 113068 113234 113374 113813 113854 113873 113919 114011 114221 114227 114353 114962 115548 116030 116392 116695 116717 116857 116848 117990 118113 120138 123653&quot;;farm=farm.split(&quot; &quot;);var maxIndex=farm.length-1;page_count=parseInt(page_count);var index=readCookie(&quot;f1&quot;);if (index==null) index=0;var i;for (i=0;i&lt;page_count;i++){index++;if (index&gt;maxIndex)index=0; farm1=farm[index];window.open(&quot;http://en21.tribalwars.net/staemme.php?village=&quot;+village+&quot;&amp;screen=place&amp;mode=command&amp;target=&quot;+farm1)}createCookie(&quot;f1&quot;, index);end();">
                                    f3</a></span></li>
                                <li><a href="javascript:coords='463|790 478|785 461|795 430|796 485|822 481|782 482|827 464|790 460|796 478|790 480|830 439|791 472|783 482|783 468|789 479|796 468|788 472|787 480|784 467|803 475|789 473|784 471|789 462|793 486|782 468|798 432|798 472|784 471|782 467|804 468|790 471|781 453|779 452|776 481|875 435|793 455|827 455|777 460|785 448|787 454|830 442|791 475|795 453|806 479|784 474|798 449|802 475|792 467|799 459|786 464|772 462|772 464|771 465|774';var%20doc=document;if(window.frames.length&gt;0)doc=window.main.document;url=document.URL;if(url.indexOf('screen=place')==-1)alert('This%20script%20needs%20to%20be%20run%20from%20the%20rally%20point');coords=coords.split(&quot;%20&quot;);index=Math.round(Math.random()*(coords.length-1));counter=1;cookienoble=document.cookie.match('(^|;) ?noblefake=([^;]*)(;|$)');cookiecounter=document.cookie.match('(^|;) ?noblecounter=([^;]*)(;|$)');if(cookienoble!=null)index=parseInt(cookienoble[2]);if(cookiecounter!=null)counter=parseInt(cookiecounter[2]);if(counter==5)index=Math.round(Math.random()*(coords.length-1));if(counter==5)counter=1;coords=coords[index];coords=coords.split(&quot;|&quot;);counter=counter+1;cookie_date=new%20Date(2009,11,11);document.cookie=&quot;noblefake=&quot;+index+&quot;;expires=&quot;+cookie_date.toGMTString ();document.cookie =&quot;noblecounter=&quot;+counter+&quot;;expires=&quot;+cookie_date.toGMTString ();doc.forms[0].x.value=coords[0];doc.forms[0].y.value=coords[1];javascript:function i(){function j(b){function k(c,f,g){if(f==0){return 1;}if(g==0){return 0;}if(f&lt;0){f=g+f;}if(f&lt;=0){return 0;}if(f&lt;=g){c.value=f;return 1;}else{c.value=g;return 0;}}var d=document,g,c,e,l=1;if(window.frames.length&gt;0)d=window.main.document;var a=d.units.getElementsByTagName('input');for(var h=0;h&lt;(a.length-4)&amp;&amp;h&lt;b.length;h++){if(b[h]!=null&amp;&amp;b[h]!=0){e=a[h].nextSibling;do{e=e.nextSibling;}while(e.nodeType!=1);g=parseInt(e.firstChild.nodeValue.match(/(\d+)/)[1],10);l=l&amp;&amp;k(a[h],b[h],g);}}return l;}if(!j([,,,,,,1])){j([,,,,,,,1]);}}i();end();">
                                    fake</a></span></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <hr width="840" size="2" />
    <table align="center" width="840" cellspacing="0" style="padding: 0; margin-bottom: 4px">
        <tr>
            <td>
                <table class="navi-border" style="border-collapse: collapse;">
                    <tr>
                        <td>
                            <table class="menu nowrap" style="width: 100%;">
                                <tr id="menu_row2">
                                    <td>
                                        <a href="/game.php?village=51549&amp;screen=overview_villages" accesskey="s">Overviews</a><br />
                                        <table cellspacing="0" width="120" class="menu_column">
                                            <tr>
                                                <td>
                                                    <a href="/game.php?village=51549&amp;screen=overview_villages&amp;mode=combined">Combined</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="/game.php?village=51549&amp;screen=overview_villages&amp;mode=prod">Production</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="/game.php?village=51549&amp;screen=overview_villages&amp;mode=trader">Transports</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="/game.php?village=51549&amp;screen=overview_villages&amp;mode=units">Troops</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="/game.php?village=51549&amp;screen=overview_villages&amp;mode=commands">Commands</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="/game.php?village=51549&amp;screen=overview_villages&amp;mode=incomings">Incoming</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="/game.php?village=51549&amp;screen=overview_villages&amp;mode=buildings">Buildings</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="/game.php?village=51549&amp;screen=overview_villages&amp;mode=tech">Research</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="/game.php?village=51549&amp;screen=overview_villages&amp;mode=groups">Groups</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <a href="/game.php?village=51549&amp;screen=map">Map</a>
                                    </td>
                                    <td class="no_hover">
                                        <a href="game.php?screen=overview&amp;village=p51549" accesskey="a">
                                            <img src="/graphic/links.png" alt="" />
                                        </a><a href="game.php?screen=overview&amp;village=n51549" accesskey="d">
                                            <img src="/graphic/rechts.png" alt="" />
                                        </a>
                                    </td>
                                    <td style="white-space: normal;">
                                        <a href="/game.php?village=51549&amp;screen=overview">001 Alpha</a> <b class="nowrap">
                                            (514|724) K75</b>
                                    </td>
                                    <td>
                                        <a href="javascript:popup_scroll('villages.php?&amp;group_id=0&amp;village_id=51549#v51549', 320, 520);">
                                            <img src="/graphic/villages.png" alt="" /></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right">
                <table align="right" class="navi-border" style="border-collapse: collapse;">
                    <tr>
                        <td>
                            <table class="box" cellspacing="0">
                                <tr style="height: 20px;">
                                    <td>
                                        <a href="/game.php?village=51549&amp;screen=wood">
                                            <img src="/graphic/holz.png" title="Wood" alt="" /></a>
                                    </td>
                                    <td>
                                        <span id="wood" title="2400">179214</span>&nbsp;
                                    </td>
                                    <td>
                                        <a href="/game.php?village=51549&amp;screen=stone">
                                            <img src="/graphic/lehm.png" title="Clay" alt="" /></a>
                                    </td>
                                    <td>
                                        <span id="stone" title="2400">178119</span>&nbsp;
                                    </td>
                                    <td>
                                        <a href="/game.php?village=51549&amp;screen=iron">
                                            <img src="/graphic/eisen.png" title="Iron" alt="" /></a>
                                    </td>
                                    <td>
                                        <span id="iron" title="2400">232527</span>&nbsp;
                                    </td>
                                    <td style="border-left: dotted 1px;">
                                        &nbsp;<a href="/game.php?village=51549&amp;screen=storage"><img src="/graphic/res.png"
                                            title="Storage capacity" alt="" /></a>
                                    </td>
                                    <td id="storage">
                                        264611
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center">
                <table class="navi-border" style="border-collapse: collapse;">
                    <tr>
                        <td style="margin: 0; padding: 0;">
                            <table class="box" cellspacing="0" style="margin: 0; padding: 0;">
                                <tr style="margin: 0; padding: 0;">
                                    <td width="18" height="20" align="center" style="margin: 0; padding: 0;">
                                        <a href="/game.php?village=51549&amp;screen=farm">
                                            <img src="/graphic/face.png" title="Villagers" alt="" /></a>
                                    </td>
                                    <td align="center" style="margin: 0; padding: 0;">
                                        24000/24000
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table class="navi-border" style="margin: auto; border-collapse: collapse;">
                    <tr>
                        <td>
                            <table class="box" cellspacing="0">
                                <tr>
                                    <td width="60" height="20" align="center">
                                        <a href="/game.php?village=51549&amp;screen=overview_villages&amp;mode=incomings">
                                            <img src="/graphic/unit/att.png" alt="" />
                                            (4)</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!--[if IE ]>
<script type="text/javascript">initMenuList("menu_row");</script>
<script type="text/javascript">initMenuList("menu_row2");</script>
<![endif]-->
    <table align="center">
        <tr>
            <td>
                <table class="content-border">
                    <tr>
                        <td>
                            <table class="main" width="840" align="center">
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <a href="/game.php?village=51549&amp;screen=overview&amp;action=set_labels&amp;labels=0&amp;h=1bf6">
                                                                    Hide upgrade levels</a>
                                                            </td>
                                                            <td align="right">
                                                                <a href="/game.php?village=51549&amp;screen=overview&amp;action=set_visual&amp;visual=0&amp;h=1bf6">
                                                                    to classical village overview</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellspacing="0" cellpadding="0" style="border-width: 1px; border-style: solid;
                                                        border-color: #804000; background-color: #F1EBDD; direction: ltr;" align="center">
                                                        <tr>
                                                            <td style="padding: 0;">
                                                                <div style="position: relative">
                                                                    <img width="600" height="418" src="images/back_none.jpg" alt="" /><img
                                                                        class="p_church" src="images/church_disabled.png" alt="" /><img class="p_main_flag"
                                                                            src="images/mainflag3.gif" /><img class="p_main" src="images/main3.png"
                                                                                alt="Village Headquarters" /><img class="p_church" src="images/church_disabled.png"
                                                                                    alt="" /><img class="p_barracks" src="images/barracks3.png" alt="Barracks" /><img
                                                                                        class="p_church" src="images/church_disabled.png" alt="" /><img class="p_stable"
                                                                                            src="images/stable3.png" alt="Stable" /><img class="p_church" src="images/church_disabled.png"
                                                                                                alt="" /><img class="p_garage" src="images/garage2.png" alt="Workshop" /><img
                                                                                                    class="p_church" src="images/church_disabled.png" alt="" /><img class="p_snob"
                                                                                                        src="images/snob1.png" alt="Academy" /><img class="p_church" src="images/church_disabled.png"
                                                                                                            alt="" /><img class="p_smith" src="images/smith3.png" alt="Smithy" /><img
                                                                                                                class="p_church" src="images/church_disabled.png" alt="" /><img class="p_place"
                                                                                                                    src="images/place1.png" alt="Rally point" /><img class="p_church" src="images/church_disabled.png"
                                                                                                                        alt="" /><img class="p_market" src="images/market3.png" alt="Market" /><img
                                                                                                                            class="p_church" src="images/church_disabled.png" alt="" /><img class="p_wood"
                                                                                                                                src="images/wood3.gif" alt="Timber camp" /><img class="p_church" src="images/church_disabled.png"
                                                                                                                                    alt="" /><img class="p_stone" src="images/stone3.gif" alt="Clay pit" /><img
                                                                                                                                        class="p_church" src="images/church_disabled.png" alt="" /><img class="p_iron"
                                                                                                                                            src="images/iron3.gif" alt="Iron mine" /><img class="p_church" src="images/church_disabled.png"
                                                                                                                                                alt="" /><img class="p_farm_field" src="images/farm3_field.png" alt="Farm" /><img
                                                                                                                                                    class="p_farm" src="images/farm3.png" alt="Farm" /><img class="p_church"
                                                                                                                                                        src="images/church_disabled.png" alt="" /><img class="p_storage" src="images/storage3.png"
                                                                                                                                                            alt="Warehouse" /><img class="p_church" src="images/church_disabled.png"
                                                                                                                                                                alt="" /><img class="p_wall" src="images/wall3.png" alt="Wall" /><img
                                                                                                                                                                    class="empty" src="/graphic/map/empty.png" alt="" usemap="#map" /><map name="map"
                                                                                                                                                                        id="map"><area shape="poly" coords="373,187,417,129,407,72,329,65,306,99,311,150"
                                                                                                                                                                            href="/game.php?village=51549&amp;screen=main" alt="Village Headquarters" title="Village Headquarters" /><area
                                                                                                                                                                                shape="poly" coords="392,289,444,313,506,283,481,235,442,216,392,252" href="/game.php?village=51549&amp;screen=barracks"
                                                                                                                                                                                alt="Barracks" title="Barracks" /><area shape="poly" coords="64,241,70,265,150,307,189,289,184,232,99,202"
                                                                                                                                                                                    href="/game.php?village=51549&amp;screen=stable" alt="Stable" title="Stable" /><area
                                                                                                                                                                                        shape="poly" coords="284,358,362,361,402,321,369,283,346,278,291,320" href="/game.php?village=51549&amp;screen=garage"
                                                                                                                                                                                        alt="Workshop" title="Workshop" /><area shape="poly" coords="206,149,257,125,229,60,185,80,156,111"
                                                                                                                                                                                            href="/game.php?village=51549&amp;screen=snob" alt="Academy" title="Academy" /><area
                                                                                                                                                                                                shape="poly" coords="174,335,222,361,271,342,283,301,216,262" href="/game.php?village=51549&amp;screen=smith"
                                                                                                                                                                                                alt="Smithy" title="Smithy" /><area shape="poly" coords="315,271,379,275,401,229,375,206,343,207"
                                                                                                                                                                                                    href="/game.php?village=51549&amp;screen=place" alt="Rally point" title="Rally point" /><area
                                                                                                                                                                                                        shape="poly" coords="214,149,234,228,313,230,330,169,273,122" href="/game.php?village=51549&amp;screen=market"
                                                                                                                                                                                                        alt="Market" title="Market" /><area shape="poly" coords="472,379,523,417,583,373,528,330"
                                                                                                                                                                                                            href="/game.php?village=51549&amp;screen=wood" alt="Timber camp" title="Timber camp" /><area
                                                                                                                                                                                                                shape="poly" coords="34,300,0,349,15,399,67,417,91,402,92,341" href="/game.php?village=51549&amp;screen=stone"
                                                                                                                                                                                                                alt="Clay pit" title="Clay pit" /><area shape="poly" coords="0,55,45,90,93,58,89,6,39,9"
                                                                                                                                                                                                                    href="/game.php?village=51549&amp;screen=iron" alt="Iron mine" title="Iron mine" /><area
                                                                                                                                                                                                                        shape="poly" coords="456,0,477,41,526,75,583,88,597,18,597,0" href="/game.php?village=51549&amp;screen=farm"
                                                                                                                                                                                                                        alt="Farm" title="Farm" /><area shape="poly" coords="96,192,153,218,195,215,193,148,133,121"
                                                                                                                                                                                                                            href="/game.php?village=51549&amp;screen=storage" alt="Warehouse" title="Warehouse" /><area
                                                                                                                                                                                                                                shape="poly" coords="428,333,430,382,472,363,470,318" href="/game.php?village=51549&amp;screen=wall"
                                                                                                                                                                                                                                alt="Wall" title="Wall" /></map><div id="l_main" class="l_main" title="Village Headquarters">
                                                                                                                                                                                                                                    <div class="label">
                                                                                                                                                                                                                                        <a href="/game.php?village=51549&amp;screen=main">
                                                                                                                                                                                                                                            <img src="/graphic/buildings/main.png" class="middle" alt="Village Headquarters" />
                                                                                                                                                                                                                                            20</a></div>
                                                                                                                                                                                                                                </div>
                                                                    <div id="l_barracks" class="l_barracks" title="Barracks">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=barracks">
                                                                                <img src="/graphic/buildings/barracks.png" class="middle" alt="Barracks" />
                                                                                25</a></div>
                                                                    </div>
                                                                    <div id="l_stable" class="l_stable" title="Stable">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=stable">
                                                                                <img src="/graphic/buildings/stable.png" class="middle" alt="Stable" />
                                                                                20</a></div>
                                                                    </div>
                                                                    <div id="l_garage" class="l_garage" title="Workshop">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=garage">
                                                                                <img src="/graphic/buildings/garage.png" class="middle" alt="Workshop" />
                                                                                5</a></div>
                                                                    </div>
                                                                    <div id="l_snob" class="l_snob" title="Academy">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=snob">
                                                                                <img src="/graphic/buildings/snob.png" class="middle" alt="Academy" />
                                                                                2</a></div>
                                                                    </div>
                                                                    <div id="l_smith" class="l_smith" title="Smithy">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=smith">
                                                                                <img src="/graphic/buildings/smith.png" class="middle" alt="Smithy" />
                                                                                20</a></div>
                                                                    </div>
                                                                    <div id="l_place" class="l_place" title="Rally point">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=place">
                                                                                <img src="/graphic/buildings/place.png" class="middle" alt="Rally point" />
                                                                                1</a></div>
                                                                    </div>
                                                                    <div id="l_market" class="l_market" title="Market">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=market">
                                                                                <img src="/graphic/buildings/market.png" class="middle" alt="Market" />
                                                                                20</a><br />
                                                                            <span style="font-size: 7px; font-weight: bold">110/110</span></div>
                                                                    </div>
                                                                    <div id="l_wood" class="l_wood" title="Timber camp">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=wood">
                                                                                <img src="/graphic/buildings/wood.png" class="middle" alt="Timber camp" />
                                                                                30</a></div>
                                                                    </div>
                                                                    <div id="l_stone" class="l_stone" title="Clay pit">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=stone">
                                                                                <img src="/graphic/buildings/stone.png" class="middle" alt="Clay pit" />
                                                                                30</a></div>
                                                                    </div>
                                                                    <div id="l_iron" class="l_iron" title="Iron mine">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=iron">
                                                                                <img src="/graphic/buildings/iron.png" class="middle" alt="Iron mine" />
                                                                                30</a></div>
                                                                    </div>
                                                                    <div id="l_farm" class="l_farm" title="Farm">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=farm">
                                                                                <img src="/graphic/buildings/farm.png" class="middle" alt="Farm" />
                                                                                30</a></div>
                                                                    </div>
                                                                    <div id="l_storage" class="l_storage" title="Warehouse">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=storage">
                                                                                <img src="/graphic/buildings/storage.png" class="middle" alt="Warehouse" />
                                                                                28</a><br />
                                                                            <span style="font-size: 7px; font-weight: bold"><span class="timer">13:22:05</span></span></div>
                                                                    </div>
                                                                    <div id="l_wall" class="l_wall" title="Wall">
                                                                        <div class="label">
                                                                            <a href="/game.php?village=51549&amp;screen=wall">
                                                                                <img src="/graphic/buildings/wall.png" class="middle" alt="Wall" />
                                                                                20</a></div>
                                                                    </div>
                                                                    <img class="npc_conversation" src="images/conversation.gif" /><img class="npc_guard"
                                                                        src="images/guard.gif" /></div>

                                                                <script type="text/javascript">overviewShowLevel();</script>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td valign="top" width="100%">
                                                    <table class="vis" width="100%">
                                                        <tr>
                                                            <th colspan="2">
                                                                Production
                                                            </th>
                                                        </tr>
                                                        <tr class="nowrap">
                                                            <td width="70">
                                                                <img src="/graphic/holz.png" title="Wood" alt="" />
                                                                Wood
                                                            </td>
                                                            <td>
                                                                <strong>2400</strong> per hour
                                                            </td>
                                                        </tr>
                                                        <tr class="nowrap">
                                                            <td>
                                                                <img src="/graphic/lehm.png" title="Clay" alt="" />
                                                                Clay
                                                            </td>
                                                            <td>
                                                                <strong>2400</strong> per hour
                                                            </td>
                                                        </tr>
                                                        <tr class="nowrap">
                                                            <td>
                                                                <img src="/graphic/eisen.png" title="Iron" alt="" />
                                                                Iron
                                                            </td>
                                                            <td>
                                                                <strong>2400</strong> per hour
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <table class="vis" width="100%">
                                                        <tr>
                                                            <th>
                                                                Units
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img src="/graphic/unit/unit_spear.png" alt="" />
                                                                <strong>7293</strong> Spear fighters
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img src="/graphic/unit/unit_sword.png" alt="" />
                                                                <strong>499</strong> Swordsmen
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img src="/graphic/unit/unit_axe.png" alt="" />
                                                                <strong>2</strong> Axemen
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img src="/graphic/unit/unit_spy.png" alt="" />
                                                                <strong>131</strong> Scouts
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img src="/graphic/unit/unit_light.png" alt="" />
                                                                <strong>1</strong> Light cavalry
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img src="/graphic/unit/unit_heavy.png" alt="" />
                                                                <strong>2100</strong> Heavy cavalry
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img src="/graphic/unit/unit_ram.png" alt="" />
                                                                <strong>12</strong> Rams
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <a href="/game.php?village=51549&amp;screen=train">&raquo; recruit</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <table class="vis" width="100%">
                                                        <tr>
                                                            <th>
                                                                group association
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                DEFENSE
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <a href="javascript:popup_scroll('groups.php?&amp;mode=village&amp;village_id=51549', 300, 400);">
                                                                    &raquo; edit</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                        <p align="right" class="server_info">
                                            generated in 86ms Server time: <span id="serverTime">14:59:28</span> <span id="serverDate">
                                                26/03/2009</span></p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <script type="text/javascript">startTimer();</script>

    <script src="http://www.google-analytics.com/urchin.js" type="text/javascript">
    </script>

    <script type="text/javascript">
_uacct = "UA-1897727-3";
urchinTracker();
    </script>

    </form>
</body>
</html>
