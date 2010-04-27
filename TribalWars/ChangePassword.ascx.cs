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

public partial class ChangePassword : System.Web.UI.UserControl
{

    protected Player player;

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        this.player = session.Load<Player>(Session["user"]);
    }

    protected void bttnChangePassword_Click(object sender, EventArgs e)
    {
        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            this.player = session.Load<Player>(Session["user"]);
            if (beans.Utilities.Encrypt(this.txtOldPassword.Text) == this.player.Password)
            {
                this.player.Password = beans.Utilities.Encrypt(this.txtNewPassword.Text);
                session.Update(this.player);
            }
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
        }
    }
}
