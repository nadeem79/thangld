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
using NHibernate;
using beans;

public partial class index : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
        //ISession session = NHibernateHelper.SessionFactory.OpenSession();
        //ITransaction trans = session.BeginTransaction();
        //User u = session.Load<User>(1);
        //u.Villages[0].LastUpdate = DateTime.Now.AddDays(-1);
        //this.error.Text = u.Villages[0].LastUpdate.Millisecond.ToString();
        //session.Save(u.Villages[0]);
        //session.Save(u);
        //trans.Commit();
        ISession session = NHibernateHelper.SessionFactory.OpenSession();

        IQuery query = session.CreateQuery("select count(*) from Village as v where v.Owner = (from User where Username=:username)");
        query.SetString("username", "drea");
        IList result = query.List();
        this.error.Text = result[0].ToString();
        this.error.Text = session.CacheMode.ToString();
        session.Close();
        
    }

    protected void login_Click(object sender, ImageClickEventArgs e)
    {
        ISession session = NHibernateHelper.SessionFactory.OpenSession();
        try
        {
            bool authenticated = beans.User.Authentication(this.username.Text, this.password.Text, session);
            if (!authenticated)
            {
                this.error.Text = "Tên đăng nhập hoặc mật khẩu không đúng";
                Session.Remove("user");
            }
            else
            {
                Session.Add("user", this.username.Text);
                Response.Redirect("overview.aspx", true);
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
