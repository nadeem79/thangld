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
        DateTime dt;
        try
        {
            dt = (DateTime)this.txtBirthdate.SelectedDate;
        }
        catch
        {
            this.lblError.Text = "Nhập sai định dạng ngày tháng";
            return;
        }

        beans.Player user = new beans.Player();
        user.Username = this.username.Text;
        user.Password = this.password.Text;
        user.Birthdate = dt;
        user.Email = this.email.Text; ;
        user.Description = "";
        user.Yahoo = "";
        user.Skype = "";
        user.Msn = "";

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
