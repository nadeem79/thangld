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

public partial class user_info : System.Web.UI.Page
{
    protected DataRow player;

    protected void Page_Load(object sender, EventArgs e)
    {
        inPage parent = (inPage)this.Master;

        SqlCommand cmd = parent.conn.CreateCommand();
        cmd.CommandText = "select * from users where username=@username";
        cmd.Parameters.Add("@username", SqlDbType.NVarChar, 200).Value = Request["username"];
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            player = dt.Rows[0];
            this.pUserExists.Visible = true;
            this.pUserNotFound.Visible = false;

            SqlCommand cmdGetVillages = parent.conn.CreateCommand();
            cmdGetVillages.CommandText = "select @current as current_village, id, name, convert(varchar(3), x, 1) + '|' + convert(varchar(3), y, 1) as coord from villages where userid=@userid";
            cmdGetVillages.Parameters.Add("@userid", SqlDbType.NVarChar, 200).Value = Request["username"];
            cmdGetVillages.Parameters.Add("@current", SqlDbType.Int).Value = int.Parse(Request["id"]);

            SqlDataAdapter daGetVillages = new SqlDataAdapter(cmdGetVillages);
            DataTable dtVillages = new DataTable();
            daGetVillages.Fill(dtVillages);

            this.gvVillages.DataSource = dtVillages;
            this.gvVillages.DataBind();

            if (!object.Equals(player["birthdate"], null))
                lblAge.Text = ((DateTime)player["birthdate"]).ToString("dd/MM/yyyy");

            if (!(player["yahoo"] == System.DBNull.Value) && !object.Equals(player["yahoo"], string.Empty))
                this.imgYahoo.ImageUrl = "http://opi.yahoo.com/online?m=g&t=2&u=" + player["yahoo"].ToString();
            if (!(player["skype"] == System.DBNull.Value) && !object.Equals(player["skype"], string.Empty))
                this.imgSkype.ImageUrl = "http://opi.yahoo.com/online?m=g&t=2&u=" + player["skype"].ToString();
            if (!(player["avatar"] == System.DBNull.Value) && !object.Equals(player["avatar"], string.Empty))
                this.imgAvatar.ImageUrl = "data/user/" + player["avatar"].ToString() + ".jpg";
        }
        else
        {
            this.pUserExists.Visible = false;
            this.pUserNotFound.Visible = true;
        }
    }
}
