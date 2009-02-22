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

public partial class report_details : System.Web.UI.Page
{
    protected DataRow report_info;
    protected string sWinningSide = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        int report_id;
        int.TryParse(Request["report"], out report_id);

        inPage parent = (inPage)this.Master;

        SqlCommand cmdGetReport = parent.conn.CreateCommand();
        cmdGetReport.CommandText = "select r.*, v1.userid as user1, v1.x as x1, v1.y as y1, v1.name as name1, v2.x as x2, v2.y as y2, v2.userid as user2, v2.name as name2 from reports r inner join villages v1 on (r.village_1=v1.id) inner join villages v2 on (r.village_2=v2.id) where r.id=@id and owner=@owner";
        cmdGetReport.Parameters.Add("@id", SqlDbType.Int).Value = report_id;
        cmdGetReport.Parameters.Add("@owner", SqlDbType.NVarChar, 200).Value = Session["username"];
        DataTable dt = new DataTable("report");
        SqlDataAdapter da = new SqlDataAdapter(cmdGetReport);
        da.Fill(dt);

        
        

        if (dt.Rows.Count == 0)
        {
            this.pHasReport.Visible = false;
            this.pNoReport.Visible = true;
        }
        else
        {
            this.pHasReport.Visible = true;
            this.pNoReport.Visible = false;
            report_info = dt.Rows[0];
            if ((bool)report_info["winningside"])
                sWinningSide = "Quân tấn công chiến thắng";
            else
                sWinningSide = "Quân phòng thủ chiến thắng";

            SqlCommand cmd = parent.conn.CreateCommand();
            cmd.CommandText = "update reports set unread=0 where id=@id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = report_id;

            parent.conn.Open();
            cmd.ExecuteNonQuery();
            parent.conn.Close();


            string id = Request["id"];
            this.urlAllReports.NavigateUrl += "&id=" + id;
            this.urlAttackReports.NavigateUrl += "&id=" + id;
            this.urlDefenseReports.NavigateUrl += "&id=" + id;
            this.urlMarketReports.NavigateUrl += "&id=" + id;
            this.urlSupportReports.NavigateUrl += "&id=" + id;
            this.navigator.Rows[(int)report_info["type"]].Cells[0].Attributes["class"] = "selected";

        }
    }
}
