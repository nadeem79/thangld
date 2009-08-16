using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using NHibernate;
using beans;
using NHibernate.Criterion;
using System.Collections.Generic;
using Telerik.Web.UI;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public partial class rally : System.Web.UI.Page
{
    
    protected beans.Village village;
    protected Attack attack;
    protected Support support;

    protected string TypePrefix(MoveType type)
    {
        switch (type)
        {
            case MoveType.SendResources:
                throw new Exception("Hack");
            case MoveType.Attack:
                return "Tấn công từ";
            case MoveType.Support:
                return "Hỗ trợ từ";
            case MoveType.Return:
                return "Quay về từ";
            default:
                break;
        }
        return "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        inPage p = (inPage)this.Master;
        village = p.CurrentVillage;
        
        ISession session = (ISession)Context.Items["NHibernateSession"];

        this.village.PrepareTroopData(session);

        if (this.village.TroopFromMe.Count > 0)
        {
            this.outgoingRepeater.DataSource = this.village.TroopFromMe;
            this.outgoingRepeater.DataBind();
        }
        if (this.village.TroopToMe.Count > 0)
        {
            this.incomingRepeater.DataSource = this.village.TroopToMe;
            this.incomingRepeater.DataBind();
        }

        if (IsPostBack)
            return;

        int target;

        if (object.Equals(Request["target"], null) || !int.TryParse(Request["target"], out target))
        {
            this.x.Text = "";
            this.y.Text = "";
        }
        else
        {
            beans.Village targetVillage = session.Load<beans.Village>(target);
            if (target != null)
            {
                this.x.Text = targetVillage.X.ToString("000");
                this.y.Text = targetVillage.Y.ToString("000");
            }
        }
        
    }

    protected void bttnAttack_Click(object sender, EventArgs e)
    {
        
        int spear, sword, axe, scout, light, heavy, ram, catapult, noble, x, y, i;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        try
        {
            spear = (int.TryParse(this.spear.Text, out i)) ? i : 0;
            sword = (int.TryParse(this.sword.Text, out i)) ? i : 0;
            axe = (int.TryParse(this.axe.Text, out i)) ? i : 0;
            scout = (int.TryParse(this.scout.Text, out i)) ? i : 0;
            light = (int.TryParse(this.light.Text, out i)) ? i : 0;
            heavy = (int.TryParse(this.heavy.Text, out i)) ? i : 0;
            ram = (int.TryParse(this.ram.Text, out i)) ? i : 0;
            catapult = (int.TryParse(this.catapult.Text, out i)) ? i : 0;
            noble = (int.TryParse(this.noble.Text, out i)) ? i : 0;
            x = (int.TryParse(this.x.Text, out i)) ? i : 0;
            y = (int.TryParse(this.y.Text, out i)) ? i : 0;
            
            this.attack = this.village.CreateAttack(session, x, y, spear, sword, axe, scout, light, heavy, ram, catapult, noble, BuildingType.NoBuiding);

            this.commandTypeSpan.Text = this.typeSpan.Text = "Tấn công";

            this.toVillageIdSpan.Text = this.attack.ToVillage.ID.ToString();
            this.toVillageName.Text = this.attack.ToVillage.Name;
            this.toVillageXSpan.Text = this.attack.ToVillage.X.ToString("000");
            this.toVillageYSpan.Text = this.attack.ToVillage.Y.ToString("000");
            this.toVillageOwnerIdSpan.Text = this.attack.ToVillage.Player.ID.ToString();
            this.toVillageOwnerNameSpan.Text = this.attack.ToVillage.Player.Username;
            this.durationSpan.Text = Functions.FormatTime(this.attack.LandingTime - DateTime.Now);
            this.landingTimeSpan.Text = this.attack.LandingTime.ToString("HH:mm:ss:'<span class=\"small hidden\">'fff'</span> ngày 'dd/MM");
            this.spearSpan.Text = (spear > 0) ? spear.ToString() : "<span class=\"hidden\">0</span>";
            this.swordSpan.Text = (sword > 0) ? sword.ToString() : "<span class=\"hidden\">0</span>";
            this.axeSpan.Text = (axe > 0) ? axe.ToString() : "<span class=\"hidden\">0</span>";
            this.scoutSpan.Text = (scout > 0) ? scout.ToString() : "<span class=\"hidden\">0</span>";
            this.ramSpan.Text = (ram > 0) ? ram.ToString() : "<span class=\"hidden\">0</span>";
            this.catapultSpan.Text = (catapult > 0) ? catapult.ToString() : "<span class=\"hidden\">0</span>";
            this.lightCavalrySpan.Text = (light > 0) ? light.ToString() : "<span class=\"hidden\">0</span>";
            this.heavyCavalrySpan.Text = (heavy > 0) ? heavy.ToString() : "<span class=\"hidden\">0</span>";
            this.nobleSpan.Text = (noble > 0) ? noble.ToString() : "<span class=\"hidden\">0</span>";
            //this.buttonNameSpan.Text = this.confirmAttackButton.UniqueID;
            this.buttonNameSpan.Text = string.Format("<input type=\"button\"  value=\"Confirm\" onclick=\"__doPostBack('{0}', '')\" />", this.confirmAttackButton.UniqueID);
            ScriptManager.RegisterStartupScript(bttnAttack, bttnAttack.GetType(), "Confirm", "$.facebox($('#commandPanel').html());", true);
            //RadScriptManager.RegisterStartupScript(bttnAttack, bttnAttack.GetType(), "DisplayAttack", "window.radopen('dialogs/attack_confirm.aspx?id=" + this.village.ID.ToString() + "&command=" + this.attack.ID.ToString() + "', 'ConfirmAttack');", true);
        }
        catch (Exception exc)
        {
            RadScriptManager.RegisterStartupScript(bttnAttack, bttnAttack.GetType(), "ShowException", "jQuery.facebox('" + exc.Message + "');", true);
            return;
        }
    }

    protected void bttnSupport_Click(object sender, EventArgs e) 
    {
        int spear, sword, axe, scout, light, heavy, ram, catapult, noble, x, y, i;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        try
        {
            spear = (int.TryParse(this.spear.Text, out i)) ? i : 0;
            sword = (int.TryParse(this.sword.Text, out i)) ? i : 0;
            axe = (int.TryParse(this.axe.Text, out i)) ? i : 0;
            scout = (int.TryParse(this.scout.Text, out i)) ? i : 0;
            light = (int.TryParse(this.light.Text, out i)) ? i : 0;
            heavy = (int.TryParse(this.heavy.Text, out i)) ? i : 0;
            ram = (int.TryParse(this.ram.Text, out i)) ? i : 0;
            catapult = (int.TryParse(this.catapult.Text, out i)) ? i : 0;
            noble = (int.TryParse(this.noble.Text, out i)) ? i : 0;
            x = (int.TryParse(this.x.Text, out i)) ? i : 0;
            y = (int.TryParse(this.y.Text, out i)) ? i : 0;

            this.support = this.village.CreateSupport(session, x, y, spear, sword, axe, scout, light, heavy, ram, catapult, noble);

            this.commandTypeSpan.Text = this.typeSpan.Text = "Hỗ trợ";

            this.toVillageIdSpan.Text = this.support.ToVillage.ID.ToString();
            this.toVillageName.Text = this.support.ToVillage.Name;
            this.toVillageXSpan.Text = this.support.ToVillage.X.ToString("000");
            this.toVillageYSpan.Text = this.support.ToVillage.Y.ToString("000");
            this.toVillageOwnerIdSpan.Text = this.support.ToVillage.Player.ID.ToString();
            this.toVillageOwnerNameSpan.Text = this.support.ToVillage.Player.Username;
            this.durationSpan.Text = Functions.FormatTime(this.support.LandingTime - DateTime.Now);
            this.landingTimeSpan.Text = this.support.LandingTime.ToString("HH:mm:ss:'<span class=\"small hidden\">'fff'</span> ngày 'dd/MM");
            this.spearSpan.Text = (spear > 0) ? spear.ToString() : "<span class=\"hidden\">0</span>";
            this.swordSpan.Text = (sword > 0) ? sword.ToString() : "<span class=\"hidden\">0</span>";
            this.axeSpan.Text = (axe > 0) ? axe.ToString() : "<span class=\"hidden\">0</span>";
            this.scoutSpan.Text = (scout > 0) ? scout.ToString() : "<span class=\"hidden\">0</span>";
            this.ramSpan.Text = (ram > 0) ? ram.ToString() : "<span class=\"hidden\">0</span>";
            this.catapultSpan.Text = (catapult > 0) ? catapult.ToString() : "<span class=\"hidden\">0</span>";
            this.lightCavalrySpan.Text = (light > 0) ? light.ToString() : "<span class=\"hidden\">0</span>";
            this.heavyCavalrySpan.Text = (heavy > 0) ? heavy.ToString() : "<span class=\"hidden\">0</span>";
            this.nobleSpan.Text = (noble > 0) ? noble.ToString() : "<span class=\"hidden\">0</span>";
            //this.buttonSpan.Text = "<input type=\"button\" value=\"Confirm\"";
            this.buttonNameSpan.Text = string.Format("<input type=\"button\" value=\"Confirm\" onclick=\"__doPostBack('{0}', '')\" />", this.confirmSupportButton.UniqueID);

            ScriptManager.RegisterStartupScript(bttnSupport, bttnSupport.GetType(), "Confirm", "$.facebox($('#commandPanel').html());", true);
        }
        catch (Exception exc)
        {
            RadScriptManager.RegisterStartupScript(bttnSupport, bttnSupport.GetType(), "ShowException", "jQuery.facebox('" + exc.Message + "');", true);
            return;
        }
    }
    protected void confirmAttackButton_Click(object sender, EventArgs e)
    {
        int spear, sword, axe, scout, light, heavy, ram, catapult, noble, x, y, i;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        spear = (int.TryParse(this.spear.Text, out i)) ? i : 0;
        sword = (int.TryParse(this.sword.Text, out i)) ? i : 0;
        axe = (int.TryParse(this.axe.Text, out i)) ? i : 0;
        scout = (int.TryParse(this.scout.Text, out i)) ? i : 0;
        light = (int.TryParse(this.light.Text, out i)) ? i : 0;
        heavy = (int.TryParse(this.heavy.Text, out i)) ? i : 0;
        ram = (int.TryParse(this.ram.Text, out i)) ? i : 0;
        catapult = (int.TryParse(this.catapult.Text, out i)) ? i : 0;
        noble = (int.TryParse(this.noble.Text, out i)) ? i : 0;
        x = (int.TryParse(this.x.Text, out i)) ? i : 0;
        y = (int.TryParse(this.y.Text, out i)) ? i : 0;

        try
        {
            this.attack = this.village.CreateAttack(session, x, y, spear, sword, axe, scout, light, heavy, ram, catapult, noble, BuildingType.NoBuiding);
            this.attack.Save(session);
            Response.Redirect(string.Format("rally.aspx?id={0}", this.village.ID), false);
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
            return;
        }
    }
    protected void confirmSupportButton_Click(object sender, EventArgs e)
    {

        int spear, sword, axe, scout, light, heavy, ram, catapult, noble, x, y, i;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        spear = (int.TryParse(this.spear.Text, out i)) ? i : 0;
        sword = (int.TryParse(this.sword.Text, out i)) ? i : 0;
        axe = (int.TryParse(this.axe.Text, out i)) ? i : 0;
        scout = (int.TryParse(this.scout.Text, out i)) ? i : 0;
        light = (int.TryParse(this.light.Text, out i)) ? i : 0;
        heavy = (int.TryParse(this.heavy.Text, out i)) ? i : 0;
        ram = (int.TryParse(this.ram.Text, out i)) ? i : 0;
        catapult = (int.TryParse(this.catapult.Text, out i)) ? i : 0;
        noble = (int.TryParse(this.noble.Text, out i)) ? i : 0;
        x = (int.TryParse(this.x.Text, out i)) ? i : 0;
        y = (int.TryParse(this.y.Text, out i)) ? i : 0;

        try
        {
            this.support = this.village.CreateSupport(session, x, y, spear, sword, axe, scout, light, heavy, ram, catapult, noble);
            this.support.Save(session);
            Response.Redirect(string.Format("rally.aspx?id={0}", this.village.ID), false);
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
            return;
        }

        //ISession session = (ISession)Context.Items["NHibernateSession"];
        //int clay = 0, wood = 0, iron = 0, x = 0, y = 0;

        //int.TryParse(this.txtClay.Text, out clay);
        //int.TryParse(this.txtWood.Text, out wood);
        //int.TryParse(this.txtIron.Text, out iron);

        //if (!(int.TryParse(this.txtX.Text, out x) && int.TryParse(this.txtY.Text, out y)))
        //{
        //    ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox.close", true);
        //    ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox('Nhập tài nguyên');", true);
        //    return;
        //}

        //try
        //{
        //    this.PendingCommand = this.Village.CreateSendResource(session, x, y, clay, wood, iron);
        //    this.PendingCommand.Save(session);
        //    this.lblAvailableMerchant.Text = this.Village.VillageBuildingData.Merchant.ToString();

        //    int pos = 0;
        //    int max = this.Village.TransportFromMe.Count;
        //    for (int i = 0; i < max; i++)
        //        if (this.Village.TransportFromMe[i].LandingTime > this.PendingCommand.LandingTime)
        //        {
        //            pos = i;
        //            break;
        //        }
        //    this.Village.TransportFromMe.Insert(pos, this.PendingCommand);

        //    this.rMyTransport.DataSource = this.Village.TransportFromMe;
        //    this.rMyTransport.DataBind();
        //    this.txtClay.Text = "";
        //    this.txtWood.Text = "";
        //    this.txtIron.Text = "";



        //}
        //catch (Exception exception)
        //{
        //    ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox.close", true);
        //    ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox('" + exception.Message + "');", true);
        //}
    }
}
