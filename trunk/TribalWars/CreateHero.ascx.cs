using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

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
        if (IsPostBack)
            return;

        this.Price = Recruit.GetPrice(TroopType.Nobleman);
        int heroCount = this.Village.Heroes.Count + 1;
        this.Price = new Price(this.Price.Name, 0, this.Price.Wood * heroCount, this.Price.Clay * heroCount, this.Price.Iron * heroCount, this.Price.Population);
        
        

    }
    protected void bttnCreateHero_Click(object sender, EventArgs e)
    {

    }
}
