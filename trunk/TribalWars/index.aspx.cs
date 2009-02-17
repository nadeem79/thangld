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

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void login_Click(object sender, ImageClickEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);

        SqlCommand cmdCheckLogin = conn.CreateCommand();
        cmdCheckLogin.CommandText = "select username from users where username=@username and password=@password";
        cmdCheckLogin.Parameters.Add("@username", SqlDbType.NVarChar, 200).Value = this.username.Text;
        cmdCheckLogin.Parameters.Add("@password", SqlDbType.NVarChar, 200).Value = this.password.Text;

        conn.Open();
        string username = (string)cmdCheckLogin.ExecuteScalar();
        conn.Close();
        if (object.Equals(username, null))
        {
            this.error.Text = "Tài khoản không tồn tại";
        }
        else
        {
            Session.Add("username", username);
            Response.Redirect("overview.aspx", true);
        }
    }
}
