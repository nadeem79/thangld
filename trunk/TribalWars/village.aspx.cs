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
using beans;
using NHibernate;

public partial class village : System.Web.UI.Page
{

    protected Village current;
    protected ISession NHibernateSession
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        current = ((inPage)(this.Master)).CurrentVillage;

        this.NHibernateSession = ((inPage)(this.Master)).NHibernateSession;

        Player currentPlayer = this.NHibernateSession.Load<Player>(Session["user"]);

        this.pSpears.Visible = (this.current.VillageTroopData.SpearInVillage != 0);
        this.pAxe.Visible = (this.current.VillageTroopData.AxeInVillage != 0);
        this.pSword.Visible = (this.current.VillageTroopData.SwordInVillage != 0);
        this.pScout.Visible = (this.current.VillageTroopData.ScoutInVillage != 0);
        this.pLight.Visible = (this.current.VillageTroopData.LightCavalry != 0);
        this.pHeavy.Visible = (this.current.VillageTroopData.HeavyCavalry != 0);
        this.pRam.Visible = (this.current.VillageTroopData.RamInVillage != 0);
        this.pCatapult.Visible = (this.current.VillageTroopData.CatapultInVillage != 0);
        this.pNoble.Visible = (this.current.VillageTroopData.NobleInVillage != 0);

        if (currentPlayer.GraphicalVillage)
        {
            GraphicVillageInfo pGraphicVillageInfo = (GraphicVillageInfo)Page.LoadControl("GraphicVillageInfo.ascx");
            pGraphicVillageInfo.CurrentVillage = current;
            pGraphicVillageInfo.DisplayBuildingLevel = currentPlayer.ShowBuildingLevel;
            this.pVillageInfo.Controls.Add(pGraphicVillageInfo);
            return;
        }
        else
        {
            TextVillageInfo pTextVillageInfo = (TextVillageInfo)Page.LoadControl("TextVillageInfo.ascx");
            pTextVillageInfo.CurrentVillage = current;
            this.pVillageInfo.Controls.Add(pTextVillageInfo);
            return;
        }

    }
}
