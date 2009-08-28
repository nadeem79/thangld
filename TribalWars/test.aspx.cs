using System;
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

using NHibernate;
using NHibernate.Linq;
using beans;
using Telerik.Web.UI;
using System.Collections.Generic;
using Iesi.Collections;

public partial class test : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];

        double b = 0.2;
        for (int i = 0; i < 200; i++)
        {
            b += b * 0.05;
            this.Label1.Text += i.ToString() + " - " + b.ToString() + "<br>";
        }

        //Village v1 = session.Load<Village>(23);
        //Village v2 = session.Load<Village>(24);
        //Attack a = new Attack();
        //a.Axe = 100;
        //a.FromVillage = v1;
        //a.ToVillage = v2;
        //a.StartingTime = DateTime.Now;
        //a.LandingTime = DateTime.Now.AddHours(1);
        //a.Building = BuildingType.NoBuiding;

        //v1.MovingCommandsFromMe.Add(a);
        //v2.MovingCommandsToMe.Add(a);

        //session.Update(v2);
        //session.Update(v1);
        //this.Label1.Text = v2.MovingCommandsToMe.Count.ToString();

        //MovingCommand command = session.Load<MovingCommand>(1373);

        //this.Label1.Text = command.FromVillage.MovingCommandsFromMe.Count.ToString();
        //command.FromVillage.MovingCommandsFromMe.Remove(command);
        //this.Label1.Text += command.FromVillage.MovingCommandsFromMe.Count.ToString();
        //command.ToVillage.MovingCommandsToMe.Remove(command);

        //Village v = session.Load<Village>(29);
        //Build b = session.Load<Build>(32771);
        
        //v.Builds.Remove(b);
        //session.Delete(b);
        
        //session.Update(v);
        //session.Update(command.FromVillage);
        //session.Update(command.ToVillage);
        
    }

    protected void bttnSend_Click(object sender, EventArgs e)
    {
        
    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Label1.Text += "gg";
    }
}
