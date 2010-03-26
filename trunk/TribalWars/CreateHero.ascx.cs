using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using Telerik.Web.UI;

public partial class CreateHero : System.Web.UI.UserControl
{
    public Village Village
    {
        get;
        set;
    }
    protected Price Price
    {
        get;
        set;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        

        this.Price = Recruit.GetPrice(TroopType.Nobleman);
        int heroCount = this.Village.Heroes.Count + 1;
        this.Price = new Price(this.Price.Name, 0, this.Price.Wood * heroCount, this.Price.Clay * heroCount, this.Price.Iron * heroCount, this.Price.Population);


    }

    protected void bttnCreateHero_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];

        int heroType = 0;
        if (!int.TryParse(this.rdoHeroType.SelectedValue, out heroType))
            return;

        HeroType type = (HeroType)heroType;

        try
        {
              
            Hero hero = this.Village.VillageHeroMethods.CreateHero(this.txtName.Text, type, session);
            //RecruitHero recruit = this.Village.VillageHeroMethods.
            Response.Redirect(string.Format("academy.aspx?id={0}&page=details&hero={1}", this.Village.ID, hero.ID), false);
        }
        catch (TribalWarsException ex)
        {
            RadScriptManager.RegisterStartupScript(bttnCreateHero, bttnCreateHero.GetType(), "ShowException", "jQuery.facebox('" + ex.Message + "');", true);
        }

    }
}
