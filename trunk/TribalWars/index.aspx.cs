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
        
        
    }

    protected void login_Click(object sender, ImageClickEventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();
        try
        {
            int id = beans.Player.Authentication(this.username.Text, this.password.Text, session);
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
