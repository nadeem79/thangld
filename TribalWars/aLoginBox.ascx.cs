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
using NHibernate;
using beans;
using NHibernate.Criterion;

public partial class aLoginBox : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void login_Click(object sender, ImageClickEventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();
        try
        {
            int id = beans.Admin.Authentication(this.username.Text, this.password.Text, session);
            if (id < 0)
            {
                this.error.Text = "Tên đăng nhập hoặc mật khẩu không đúng";
                Session.Remove("user");
            }
            else
            {
                Session.Add("user", id);
                Response.Redirect("aUser.aspx", true);
            }
        }
        catch (Exception exc)
        {
            this.error.Text = exc.Message;
        }
        finally
        {
            session.Close();
        }
    }
}
