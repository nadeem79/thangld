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
        user.Password = beans.Utilities.Encrypt(this.password.Text);
        user.Birthdate = dt;
        user.Email = this.email.Text; ;
        user.Description = "";
        user.Yahoo = "";
        user.Skype = "";
        user.Msn = "";

        ISession session = (ISession)Context.Items["NHibernateSession"];
        session.Save(user);
        Session.RemoveAll();
        Session.Add(Constant.NormalUserSessionSign, user.ID);
        Session.Add(Constant.Username, user.Username);
        Response.Redirect("village.aspx", true);

    }
}
