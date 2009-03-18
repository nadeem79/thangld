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

public partial class village_info : System.Web.UI.Page
{

    protected DataRow village_description;

    protected void Page_Load(object sender, EventArgs e)
    {
        inPage parent = (inPage)this.Master;
        int village_id;
        int.TryParse(Request["village"], out village_id);
        SqlCommand cmd = parent.conn.CreateCommand();
        cmd.CommandText = "select id, name, userid, x, y from villages where id=@id";
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            village_description = dt.Rows[0];
            this.pHasVillage.Visible = true;
            this.pVillageNotFound.Visible = false;
            if ((string)Session["username"] != (string)village_description["userid"])
                pIsOwner.Visible = false;
        }
        else
        {
            this.pHasVillage.Visible = false;
            this.pVillageNotFound.Visible = true;
        }
    }
}
