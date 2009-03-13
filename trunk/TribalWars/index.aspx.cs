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
using NHibernate.Criterion;
using System.Collections.Generic;

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
        //ISession session = NHibernateHelper.SessionFactory.OpenSession();

        //IQuery query = session.CreateQuery("select count(*) from Village as v where v.Owner = (from User where Username=:username)");
        //query.SetString("username", "drea");
        //IList result = query.List();
        //this.error.Text = result[0].ToString();
        //this.error.Text = session.CacheMode.ToString();
        //session.Close();

        //ISession session = NHibernateHelper.SessionFactory.OpenSession();
        //beans.User user = session.Load<beans.User>(2);

        //ICriteria criteria = session.CreateCriteria(typeof(beans.Village));
        //criteria.Add(Expression.Eq("Owner", user));
        //IList<beans.Village> lst = criteria.List<beans.Village>();
        //beans.Village v = lst[0];
        //v.Owner.Username = "hahahahaa";

        //this.error.Text = user.Username;
        ISession session = NHibernateHelper.CreateSession();

        IQuery query = session.CreateQuery("select ID from User as user where user.Username=:username");
        query.SetString("username", "drea");
        this.error.Text = ((int)query.List()[0]).ToString();
        
        
        
    }

    protected void login_Click(object sender, ImageClickEventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();
        try
        {
            int id = beans.User.Authentication(this.username.Text, this.password.Text, session);
            if (id<0)
            {
                this.error.Text = "Tên đăng nhập hoặc mật khẩu không đúng";
                Session.Remove("username");
            }
            else
            {
                Session.Add("user", id);
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
