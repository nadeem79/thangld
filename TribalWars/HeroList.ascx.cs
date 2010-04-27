using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class HeroList : System.Web.UI.UserControl
{
    public beans.Village Village
    {
        get;
        set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player currentPlayer = session.Load<Player>(Session[Constant.NormalUserSessionSign]);
        this.rptHeroes.DataSource = currentPlayer.Heroes;
        this.rptHeroes.DataBind();
    }

    protected Hero Hero
    {
        get;
        set;
    }
    protected string SetHero(Hero hero)
    {
        this.Hero = hero;
        return "";
    }
    protected string GetHeroStatus(Hero hero)
    {
        if (hero.IsDead)
            return "Chết";
        else if (hero.InMovingCommand != null)
            return "Unavailable";
        else
            return "Available";

    }
}
