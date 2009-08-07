using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class administrator_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void authenticationButton_Click(object sender, EventArgs e)
    {

        if (this.usernameTextBox.Text.Trim().Equals(string.Empty))
        {
            this.errorLabel.Text = "Nhập tên đăng nhập";
            return;
        }

        if (this.passwordTextBox.Text.Trim().Equals(string.Empty))
        {
            this.errorLabel.Text = "Nhập mật khẩu";
            return;
        }

        ISession session = NHibernateHelper.CreateSession();

        int staffID = Admin.StaffAuthentication(this.usernameTextBox.Text, this.passwordTextBox.Text, session);
        if (staffID == 0)
        {
            this.errorLabel.Text = "Tên đăng nhập hoặc mật khẩu không tồn tại";
            session.Close();
            return;
        }

        Session["staffID"] = staffID;
        session.Close();
        Response.Redirect("index.aspx", false);
    }
}
