using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using NHibernate;
using beans;
using System.Collections.Generic;

public partial class inPage : System.Web.UI.MasterPage
{

    public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);
    public DataRow village1;
    private beans.Village village = null;
    public beans.Village CurrentVillage
    {
        get
        {
            return this.village;
        }
    }

    public inPage()
    {
        this.Init += new EventHandler(inPage_Init);
    }

    void inPage_Init(object sender, EventArgs e)
    {

        DateTime start = DateTime.Now;
        int id;
        ISession session;
        ITransaction trans;
        if (object.Equals(Session["user"], null))
        {
            Response.Redirect("index.aspx", true);
            return;
        }

        session = NHibernateHelper.CreateSession();

        
        beans.User currentUser = session.Load<beans.User>((int)Session["user"]);
        
        if (currentUser == null)
        {
            session.Close();
            Response.Redirect("index.aspx", true);
        }

        trans = session.BeginTransaction();
        currentUser.Update(DateTime.Now, session);
        
        
        
        if (object.Equals(Request["id"], null) || (!int.TryParse(Request["id"], out id)))
            this.village = currentUser.Villages[0];
        else
            this.village = currentUser.GetVillage(id);

        if (this.village == null)
            this.village = currentUser.Villages[0];

        this.lblCoord.Text = this.village.X.ToString() + "|" + this.village.Y.ToString();
        this.currentVillage.Text = this.village.Name;
        this.currentVillage.NavigateUrl = "village.aspx?id=" + this.village.ID.ToString();

        this.wood.Text = this.village.Wood.ToString();
        this.clay.Text = this.village.Clay.ToString();
        this.iron.Text = this.village.Iron.ToString();
        this.iron_url.NavigateUrl = "iron.aspx?id=" + this.village.ID.ToString();
        this.clay_url.NavigateUrl = "clay.aspx?id=" + this.village.ID.ToString();
        this.wood_url.NavigateUrl = "wood.aspx?id=" + this.village.ID.ToString();
        this.lblReport.NavigateUrl = "list_report.aspx?id=" + this.village.ID.ToString();
        this.map.NavigateUrl = "map.aspx?id=" + this.village.ID.ToString();

        this.resource.Text = this.village.MaxResources.ToString();
        this.pop.Text = this.village.MaxPopulation.ToString();
        this.res_url.NavigateUrl = "resource.aspx?id=" + this.village.ID.ToString();
        this.pop_url.NavigateUrl = "population.aspx?id=" + this.village.ID.ToString();

        int incomingAttackCount = village.GetIncomingAttackCount(session);
        int incomingSupportCount = village.GetIncomingSupportCount(session);

        

        DateTime stop = DateTime.Now;
        this.delay.Text = (stop - start).Milliseconds.ToString();
        this.time.Text = start.ToString("dd/MM/yyyy hh:mm:ss");
        trans.Commit();
        session.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}