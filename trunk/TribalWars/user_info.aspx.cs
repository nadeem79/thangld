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
using System.Xml.Linq;
using System.Data.SqlClient;
using beans;
using NHibernate;

public partial class user_info : System.Web.UI.Page
{
    protected Village village = null;
    protected Player player = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        inPage p = (inPage)this.Master;
        village = p.CurrentVillage;

        int player_id = 0;
        int.TryParse(Request["player"], out player_id);
        if (player_id == 0)
        {
            this.pUserExists.Visible = false;
            this.pUserNotFound.Visible = true;
            return;
        }

        ISession session = NHibernateHelper.CreateSession();
        this.player = session.Get<Player>(player_id);
        session.Close();

        if (this.player == null)
        {
            this.pUserExists.Visible = false;
            this.pUserNotFound.Visible = true;
            return;
        }

        this.pUserNotFound.Visible = false;
        this.pUserExists.Visible = true;

        //this.imgAvatar.ImageUrl = "data/user/" + player["avatar"].ToString() + ".jpg";
        //this.imgSkype.ImageUrl = "http://opi.yahoo.com/online?m=g&t=2&u=" + player["skype"].ToString();
        //this.imgYahoo.ImageUrl = "http://opi.yahoo.com/online?m=g&t=2&u=" + player["yahoo"].ToString();
    }
}
