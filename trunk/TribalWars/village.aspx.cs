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

    protected void Page_Load(object sender, EventArgs e)
    {
        current = ((inPage)(this.Master)).CurrentVillage;
        
        ISession session =  NHibernateHelper.CreateSession();

        Player currentPlayer = session.Load<Player>(Session["user"]);
        session.Close();
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
