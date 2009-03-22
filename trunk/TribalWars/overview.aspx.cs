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

public partial class overview : System.Web.UI.Page
{
    protected Village village;

    protected void Page_Load(object sender, EventArgs e)
    {
        village = ((inPage)this.Master).CurrentVillage;
        ISession session = NHibernateHelper.CreateSession();
        beans.Player user = session.Load<beans.Player>(Session["user"]);
        if (user.GetVillageCount(session) <= 1)
        {
            session.Close();
            Response.Redirect("village.aspx", true);
        }
        System.Collections.Generic.IList<Village> v = user.Villages;
        session.Close();
    }
}
