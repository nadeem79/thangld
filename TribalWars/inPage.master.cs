using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using NHibernate;
using beans;
using System.Collections.Generic;
using Telerik.Web.UI;

public partial class inPage : System.Web.UI.MasterPage
{
    public ISession NHibernateSession
    {
        get;
        set;
    }

    DateTime start, stop;
    private Player player;
    private beans.Village village;
    public beans.Village CurrentVillage
    {
        get
        {
            return this.village;
        }
    }
    public Player Player
    {
        get { return this.player; }
    }
    public Label WoodLabel
    {
        get { return this.lblWood; }
    }
    public Label ClayLabel 
    { 
        get { return this.lblClay; }
    }
    public Label IronLabel 
    {
        get { return this.lblIron; }
    }
    



    public inPage()
    {
        this.Init += new EventHandler(inPage_Init);
        this.PreRender += new EventHandler(inPage_Unload);
    }

    void inPage_Unload(object sender, EventArgs e)
    {
        //this.NHibernateSession.Close();
        this.stop = DateTime.Now;
        this.delay.Text = (stop - start).Milliseconds.ToString();
    }

    void inPage_Init(object sender, EventArgs e)
    {

        if (object.Equals(Session["user"], null))
        {
            //Response.Redirect("session_expired.aspx", true);
            //return;
            Session["user"] = 3;
        }

        this.start = DateTime.Now;
        int id;

        this.NHibernateSession = (ISession)Context.Items["NHibernateSession"];



        this.player = this.NHibernateSession.Load<beans.Player>((int)Session["user"]);
        if (this.player == null)
        {
            Response.Redirect("index.aspx", false);
        }
        this.player.Update(DateTime.Now, this.NHibernateSession);

        if (object.Equals(Request["id"], null) || (!int.TryParse(Request["id"], out id)))
            this.village = this.player.Villages[0];
        else
            this.village = this.player.GetVillage(id);

        if (this.village == null)
            this.village = this.player.Villages[0];

        //this.village.VillageResourceData.ResourceChanged+=new ResourceChangeHandler();

        int incomingAttackCount = this.Player.GetIncomingAttackCount(this.NHibernateSession);
        int incomingSupportCount = this.Player.GetIncomingSupportCount(this.NHibernateSession);

        this.lblClay.Text = this.CurrentVillage.VillageResourceData.Clay.ToString();
        this.lblWood.Text = this.CurrentVillage.VillageResourceData.Wood.ToString();
        this.lblIron.Text = this.CurrentVillage.VillageResourceData.Iron.ToString();

        if (this.CurrentVillage.VillageResourceData.Wood == this.CurrentVillage.MaxResources)
            this.lblWood.ForeColor = System.Drawing.Color.Red;
        if (this.CurrentVillage.VillageResourceData.Clay == this.CurrentVillage.MaxResources)
            this.lblClay.ForeColor = System.Drawing.Color.Red;
        if (this.CurrentVillage.VillageResourceData.Iron == this.CurrentVillage.MaxResources)
            this.lblIron.ForeColor = System.Drawing.Color.Red;
        this.RadToolBar1.DataBind();
        foreach (RadToolBarButton menuItem in this.menu.Items)
            menuItem.NavigateUrl += string.Format("?id={0}", this.village.ID);
        foreach (RadMenuItem item in this.RadToolBar1.Items)
        {
            if (item.NavigateUrl.Contains("?"))
                item.NavigateUrl += string.Format("&id={0}", this.village.ID);
            else
                item.NavigateUrl += string.Format("?id={0}", this.village.ID);
            foreach (RadMenuItem subItem in item.Items)
                if (subItem.NavigateUrl.Contains("?"))
                    subItem.NavigateUrl += string.Format("&id={0}", this.village.ID);
                else
                    subItem.NavigateUrl += string.Format("?id={0}", this.village.ID);
        }
    }

    protected void VillageResourceData_ResourceChanged(ResourcesType type, int value, int max)
    {
        switch (type)
        {
            case ResourcesType.Clay:
                this.ClayLabel.Text = value.ToString();
                //if (value == max)
                //this.ClayLabel.CssClass
                break;
            case ResourcesType.Wood:
                this.WoodLabel.Text = value.ToString();
                break;
            case ResourcesType.Iron:
                this.IronLabel.Text = value.ToString();
                break;
            default:
                break;
        }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }


}