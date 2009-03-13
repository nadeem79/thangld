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
using CaptchaDLL;
using System.Data.SqlClient;
using NHibernate;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void bttnRegister_Click(object sender, EventArgs e)
    {
        if (!this.chkAgreement.Checked)
        {
            this.lblError.Text = "Bạn phải chấp nhận các điều khoản thoả thuận trước để có thể đăng ký";
            return;
        }

        beans.User user = new beans.User();
        user.Username = this.username.Text;
        user.Password = this.password.Text;
        user.Email = this.email.Text;

        NHibernate.ISession session = null;
        try
        {
            session = NHibernateHelper.CreateSession();
            ITransaction trans = session.BeginTransaction();
            session.Save(user);
            trans.Commit();
            Session.RemoveAll();
            Session.Add("user", user.ID);
            Response.Redirect("overview.aspx", true);
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
        }
        finally
        {
            session.Close();
        }

    }
}
