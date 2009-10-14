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

public partial class LoginBox : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void login_Click(object sender, ImageClickEventArgs e)
    {

        
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        try
        {
            int id = beans.Player.Authentication(this.username.Text, this.password.Text, session);
            if (id < 0)
            {
                this.error.Text = "Tên đăng nhập hoặc mật khẩu không đúng";
                Session.Remove("user");
            }
            else
            {
                Session[Constant.NormalUserSessionSign] = id;
                Session[Constant.Username] = this.username.Text;
                //Session.Add(Constant.NormalUserSessionSign, id);
                //Session.Add(Constant.Username, this.username.Text);
                if (this.chkRemember.Checked)
                {
                    Request.Cookies.Remove("username");
                    Request.Cookies.Remove("password");
                    HttpCookie cookieUsername = new HttpCookie("username", this.username.Text);
                    cookieUsername.Expires = DateTime.Now.AddYears(2);
                    HttpCookie cookiePassword = new HttpCookie("password", this.password.Text);
                    cookiePassword.Expires = DateTime.Now.AddYears(2);
                    Request.Cookies.Add(cookieUsername);
                    Request.Cookies.Add(cookiePassword);
                }
                if (this.chkPlayGame.Checked)
                    Response.Redirect("overview.aspx", false);
                else
                    Response.Redirect("index.aspx", false);
            }
        }
        catch (Exception exc)
        {
            this.error.Text = exc.Message;
        }
    }
}
