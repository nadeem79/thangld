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
using CaptchaDLL;
using System.Data.SqlClient;

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

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);

        SqlCommand cmdCheckLogin = conn.CreateCommand();
        cmdCheckLogin.CommandText = "INSERT INTO users (username, password, email) values (@username, @password, @email)";
        cmdCheckLogin.Parameters.Add("@username", SqlDbType.NVarChar, 200).Value = this.username.Text;
        cmdCheckLogin.Parameters.Add("@password", SqlDbType.NVarChar, 200).Value = this.password.Text;
        cmdCheckLogin.Parameters.Add("@email", SqlDbType.NVarChar, 200).Value = this.email.Text;

        conn.Open();
        int success = cmdCheckLogin.ExecuteNonQuery();
        conn.Close();
        if (success > 0)
        {
            Session.Add("username", username.Text);
            Response.Redirect("overview.aspx", true);
        }
        else
        {

        }
    }
}
