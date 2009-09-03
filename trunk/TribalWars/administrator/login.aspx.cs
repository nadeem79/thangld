using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using Telerik.Web.UI;

public partial class administrator_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        int staffID = ServicesList.SecurityService.Authentication(this.usernameTextBox.Text, this.passwordTextBox.Text, true, session); //Admin.StaffAuthentication(this.usernameTextBox.Text, this.passwordTextBox.Text, session);
        if (staffID == 0)
        {

            this.AuthenticationValidator.IsValid = false;
            RadScriptManager.RegisterStartupScript(AuthenticationValidator, AuthenticationValidator.GetType(), "ShowException", "jQuery.facebox('Sai tên đăng nhập hoặc mật khẩu');", true);
            return;
        }

        this.AuthenticationValidator.IsValid = true;
        Session["staffID"] = staffID;
        Response.Redirect("default.aspx", false);
    }
}
