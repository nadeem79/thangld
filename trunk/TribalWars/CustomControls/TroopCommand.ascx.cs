using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using beans;
using Telerik.Web.UI;

public partial class CustomControls_TroopCommand : System.Web.UI.UserControl
{

    public Village Village
    {
        get;
        set;
    }

    protected string TypePrefix(MoveType type)
    {
        switch (type)
        {
            case MoveType.SendResources:
                throw new Exception("Hack");
            case MoveType.Attack:
                return "Tấn công";
            case MoveType.Support:
                return "Hỗ trợ";
            case MoveType.Return:
                return "Quay về";
            default:
                break;
        }
        return "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];

        this.Village.VillageTroopMethods.PrepareTroopData(session);

        if (this.Village.VillageTroopMethods.TroopFromMe.Count > 0)
        {
            this.outgoingRepeater.DataSource = this.Village.VillageTroopMethods.TroopFromMe;
            this.outgoingRepeater.DataBind();
        }
        if (this.Village.VillageTroopMethods.TroopToMe.Count > 0)
        {
            this.incomingRepeater.DataSource = this.Village.VillageTroopMethods.TroopToMe;
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
            if (targetVillage != null)
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

            Attack attack = this.Village.VillageTroopMethods.CreateAttack(session, x, y, spear, sword, axe, scout, light, heavy, ram, catapult, noble, BuildingType.NoBuiding);

            this.commandTypeSpan.Text = this.typeSpan.Text = "Tấn công";

            this.toVillageIdSpan.Text = attack.ToVillage.ID.ToString();
            this.toVillageName.Text = attack.ToVillage.Name;
            this.toVillageXSpan.Text = attack.ToVillage.X.ToString("000");
            this.toVillageYSpan.Text = attack.ToVillage.Y.ToString("000");
            this.toVillageOwnerIdSpan.Text = attack.ToVillage.Player.ID.ToString();
            this.toVillageOwnerNameSpan.Text = attack.ToVillage.Player.Username;
            this.durationSpan.Text = Functions.FormatTime(attack.LandingTime - DateTime.Now);
            this.landingTimeSpan.Text = attack.LandingTime.ToString("HH:mm:ss:'<span class=\"small hidden\">'fff'</span> ngày 'dd/MM");
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

            Support support = this.Village.VillageTroopMethods.CreateSupport(session, x, y, spear, sword, axe, scout, light, heavy, ram, catapult, noble);

            this.commandTypeSpan.Text = this.typeSpan.Text = "Hỗ trợ";

            this.toVillageIdSpan.Text = support.ToVillage.ID.ToString();
            this.toVillageName.Text = support.ToVillage.Name;
            this.toVillageXSpan.Text = support.ToVillage.X.ToString("000");
            this.toVillageYSpan.Text = support.ToVillage.Y.ToString("000");
            this.toVillageOwnerIdSpan.Text = support.ToVillage.Player.ID.ToString();
            this.toVillageOwnerNameSpan.Text = support.ToVillage.Player.Username;
            this.durationSpan.Text = Functions.FormatTime(support.LandingTime - DateTime.Now);
            this.landingTimeSpan.Text = support.LandingTime.ToString("HH:mm:ss:'<span class=\"small hidden\">'fff'</span> ngày 'dd/MM");
            this.spearSpan.Text = (spear > 0) ? spear.ToString() : "<span class=\"hidden\">0</span>";
            this.swordSpan.Text = (sword > 0) ? sword.ToString() : "<span class=\"hidden\">0</span>";
            this.axeSpan.Text = (axe > 0) ? axe.ToString() : "<span class=\"hidden\">0</span>";
            this.scoutSpan.Text = (scout > 0) ? scout.ToString() : "<span class=\"hidden\">0</span>";
            this.ramSpan.Text = (ram > 0) ? ram.ToString() : "<span class=\"hidden\">0</span>";
            this.catapultSpan.Text = (catapult > 0) ? catapult.ToString() : "<span class=\"hidden\">0</span>";
            this.lightCavalrySpan.Text = (light > 0) ? light.ToString() : "<span class=\"hidden\">0</span>";
            this.heavyCavalrySpan.Text = (heavy > 0) ? heavy.ToString() : "<span class=\"hidden\">0</span>";
            this.nobleSpan.Text = (noble > 0) ? noble.ToString() : "<span class=\"hidden\">0</span>";
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
            Attack attack = this.Village.VillageTroopMethods.CreateAttack(session, x, y, spear, sword, axe, scout, light, heavy, ram, catapult, noble, BuildingType.NoBuiding);
            attack.Save(session);
            Response.Redirect(string.Format("rally.aspx?id={0}", this.Village.ID), false);
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
            Support support = this.Village.VillageTroopMethods.CreateSupport(session, x, y, spear, sword, axe, scout, light, heavy, ram, catapult, noble);
            support.Save(session);
            Response.Redirect(string.Format("rally.aspx?id={0}", this.Village.ID), false);
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
            return;
        }
    }
}
