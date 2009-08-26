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

public partial class ChangeEmailAddress : System.Web.UI.UserControl
{

    protected Player player;

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        this.player = session.Load<Player>(Session["user"]);
    }
    protected void bttnChangeEmail_Click(object sender, EventArgs e)
    {
        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            this.player = session.Load<Player>(Session["user"]);
            if (this.password.Text == this.player.Password)
            {
                this.player.Email = this.email.Text;
                session.Update(this.player);
            }
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
            trans.Rollback();
        }
        finally
        {
            session.Close();
        }
    }
}
