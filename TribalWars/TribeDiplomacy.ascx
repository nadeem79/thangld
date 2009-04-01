<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TribeDiplomacy.ascx.cs"
    Inherits="TribeDiplomacy" %>
<p>
    On this page your relations with other tribes are administered. The settings are
    <strong>non-binding within the game</strong>, but villages will be coloured accordingly
    on the map. The status is visible only to tribe members and may be changed by tribal
    diplomats only.</p>
    
<table class="vis" width="300">
    <tr>
        <th colspan="2">
            Allies
        </th>
    </tr>
</table>
<br />
<table class="vis" width="300">
    <tr>
        <th colspan="2">
            Non-Aggression-Pact (NAP)
        </th>
    </tr>
</table>
<br />
<table class="vis" width="300">
    <tr>
        <th colspan="2">
            Enemies
        </th>
    </tr>
</table>
<h3>
    Add relationship</h3>
<form action="/game.php?village=114479&amp;screen=ally&amp;mode=contracts&amp;action=add_contract&amp;h=7d02"
method="post">
Tribe tag:
<input type="text" name="tag" />
<select name="type">
    <option value="partner">Ally</option>
    <option value="nap">Non-Aggression-Pact (NAP)</option>
    <option value="enemy">Enemy</option>
</select>
<input type="submit" value="OK" />
</form>
