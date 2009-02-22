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

public partial class list_report : System.Web.UI.Page
{
    protected int type;
    protected void Page_Load(object sender, EventArgs e)
    {

        

        string id = Request["id"];
        int.TryParse(Request["type"], out type);
        if (type > 4) type = 0;
        string s = "";

        if (type>0)
            s = " and type=@type";

        inPage parent = (inPage)this.Master;
        SqlCommand cmd = parent.conn.CreateCommand();
        cmd.CommandText = "select top 20 id, type, village_1, village_2, winningside, title, create_time, @current_village as current_village from reports where owner=@owner " + s + " order by id desc";
        cmd.Parameters.Add("@owner", SqlDbType.NVarChar, 200).Value = Session["username"];
        cmd.Parameters.Add("@type", SqlDbType.Int).Value = type;
        cmd.Parameters.Add("@current_village", SqlDbType.Int).Value = parent.village["id"];
        DataTable dt = new DataTable("reports");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        this.gvReports.DataSource = dt;
        this.gvReports.DataMember = "reports";
        this.gvReports.DataBind();

        this.urlAllReports.NavigateUrl += "&id=" + id;
        this.urlAttackReports.NavigateUrl += "&id=" + id;
        this.urlDefenseReports.NavigateUrl += "&id=" + id;
        this.urlMarketReports.NavigateUrl += "&id=" + id;
        this.urlSupportReports.NavigateUrl += "&id=" + id;
        this.navigator.Rows[type].Cells[0].Attributes["class"] = "selected";

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
}
