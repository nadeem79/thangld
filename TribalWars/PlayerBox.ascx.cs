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

using beans;
using NHibernate;

public partial class PlayerBox : System.Web.UI.UserControl
{

    protected Player player;

    protected void Page_Load(object sender, EventArgs e)
    {
        //this.error.Text = Request.Cookies["username"].Value;
        ISession session = null;
        try
        {
            session = NHibernateHelper.CreateSession();
            this.player = session.Get<Player>(Session["user"]);
        }
        catch (Exception ex)
        {
            this.error.Text = ex.Message;
        }
        finally
        {
            if (session != null)
                session.Close();
        }
    }
}
