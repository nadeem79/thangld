﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using NHibernate;
using beans;
using NHibernate.Criterion;
using System.Collections.Generic;

public partial class rally : System.Web.UI.Page
{
    
    protected beans.Village village;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        inPage p = (inPage)this.Master;
        village = p.CurrentVillage;

        
        ISession session = NHibernateHelper.CreateSession();
        IList<MovingCommand> incomings = this.village.GetTroopMovement(session);

        string sOutwardsCommand = "";
        string sInwardsCommand = "";

        foreach (MovingCommand command in incomings)
            if (command.Type == MoveType.Attack)
            {
                if (command.To == this.village)
                {
                    sInwardsCommand += "<tr><td><a href='command.aspx?id=" + this.village.ID.ToString() + "&command=" + command.ID.ToString() + "'>";
                    sInwardsCommand += "<img src='images/attack.png'/> Tấn công từ ";
                    sInwardsCommand += command.To.Name + " (" + command.From.X.ToString("000") + "|" + command.From.Y.ToString("000") + ")</td>";
                    sInwardsCommand += "<td>" + command.LandingTime.ToString() + "</td>";
                    sInwardsCommand += "<td><span class='timer'>" + Functions.FormatTime(command.LandingTime - DateTime.Now) + "</span></td></tr>";
                }
                else if (command.From==this.village)
                {
                    sOutwardsCommand += "<tr><td><a href='command.aspx?id=" + this.village.ID.ToString() + "&command=" + command.ID.ToString() + "'>";
                    sOutwardsCommand += "<img src='images/attack.png'/> Tấn công thành phố ";
                    sOutwardsCommand += command.To.Name + " (" + command.To.X.ToString("000") + "|" + command.To.Y.ToString("000") + ")</td>";
                    sOutwardsCommand += "<td>" + command.LandingTime.ToString() + "</td>";
                    sOutwardsCommand += "<td><span class='timer'>" + Functions.FormatTime(command.LandingTime - DateTime.Now) + "</span></td></tr>";
                }
            }
            else if (command.Type == MoveType.Support)
            {
                if (command.To == this.village)
                {
                    sInwardsCommand += "<tr><td><a href='command.aspx?id=" + this.village.ID.ToString() + "&command=" + command.ID.ToString() + "'>";
                    sInwardsCommand += "<img src='images/support.png'/> Hỗ trợ từ ";
                    sInwardsCommand += command.To.Name + " (" + command.From.X.ToString("000") + "|" + command.From.Y.ToString("000") + ")</td>";
                    sInwardsCommand += "<td>" + command.LandingTime.ToString() + "</td>";
                    sInwardsCommand += "<td><span class='timer'>" + Functions.FormatTime(command.LandingTime - DateTime.Now) + "</span></td></tr>";
                }
                else if (command.From == this.village)
                {
                    sOutwardsCommand += "<tr><td><a href='command.aspx?id=" + this.village.ID.ToString() + "&command=" + command.ID.ToString() + "'>";
                    sOutwardsCommand += "<img src='images/support.png'/> Hỗ trợ thành phố ";
                    sOutwardsCommand += command.To.Name + " (" + command.To.X.ToString("000") + "|" + command.To.Y.ToString("000") + ")</td>";
                    sOutwardsCommand += "<td>" + command.LandingTime.ToString() + "</td>";
                    sOutwardsCommand += "<td><span class='timer'>" + Functions.FormatTime(command.LandingTime - DateTime.Now) + "</span></td></tr>";
                }
            }
            else if (command.Type == MoveType.Return)
            {
                sInwardsCommand += "<tr><td><a href='command.aspx?id=" + this.village.ID.ToString() + "&command=" + command.ID.ToString() + "'>";
                sInwardsCommand += "<img src='images/return.png'/> Quay về từ ";
                sInwardsCommand += command.To.Name + " (" + command.From.X.ToString("000") + "|" + command.From.Y.ToString("000") + ")</td>";
                sInwardsCommand += "<td>" + command.LandingTime.ToString() + "</td>";
                sInwardsCommand += "<td><span class='timer'>" + Functions.FormatTime(command.LandingTime - DateTime.Now) + "</span></td></tr>";
            }

        
        this.lblOutwardsCommand.Text = sOutwardsCommand;
        this.lblInwardsCommand.Text = sInwardsCommand;

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

        session.Close();
        
    }
    

    protected void bttnAttack_Click(object sender, EventArgs e)
    {
        int spear, sword, axe, scout, light, heavy, ram, catapult, noble, x, y, i;
        ISession session = null;

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
            session = NHibernateHelper.CreateSession();
            ITransaction trans = session.BeginTransaction();
            Attack.CreateAttack(session, this.village, x, y, spear, sword, axe, scout, light, heavy, ram, catapult, noble, BuildingType.NoBuiding);
            trans.Commit();
            Response.Redirect("rally.aspx?id=" + this.village.ID.ToString(), true);
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
            return;
        }
        finally
        {
            session.Close();
        }

        
    }
    protected void bttnSupport_Click(object sender, EventArgs e)
    {
        int spear, sword, axe, scout, light, heavy, ram, catapult, noble, x, y, i;
        ISession session = null;

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

            session = NHibernateHelper.CreateSession();
            ITransaction trans = session.BeginTransaction();
            Support.CreateSupport(session, this.village, x, y, spear, sword, axe, scout, light, heavy, ram, catapult, noble);
            trans.Commit();
            Response.Redirect("rally.aspx?id=" + this.village.ID.ToString(), true);
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
            return;
        }
        finally
        {
            session.Close();
        }
    }
}