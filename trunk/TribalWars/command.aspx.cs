﻿using System;
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

public partial class command : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        int id = int.Parse(Request["id"]);

        int command;
        if (object.Equals(Request["command"], null) || (!int.TryParse(Request["command"], out command)))
        {
            Response.Redirect("village.aspx?id=" + Request["id"], true);
            return;
        }

        SqlCommand cmdGetCommandInfo = conn.CreateCommand();
        cmdGetCommandInfo.CommandText = "select m.*, v1.id as id1, v1.x as x1, v1.y as y1, v1.name as name1, v1.userid as userid1, v2.id as id2, v2.x as x2, v2.y as y2, v2.name as name2, v2.userid as userid2 from movement m inner join villages v1 on (v1.id=m.[from]) inner join villages v2 on (v2.id=m.[to]) where m.landing_time>getdate() and (m.[from]=@village_id1 or m.[to]=@village_id2) and m.id=@id";
        cmdGetCommandInfo.Parameters.Add("@village_id1", SqlDbType.Int).Value = id;
        cmdGetCommandInfo.Parameters.Add("@village_id2", SqlDbType.Int).Value = id;
        cmdGetCommandInfo.Parameters.Add("@id", SqlDbType.Int).Value = command;

        SqlDataAdapter daCommand = new SqlDataAdapter(cmdGetCommandInfo);
        DataTable tb = new DataTable();
        daCommand.Fill(tb);

        if (tb.Rows.Count == 0)
        {
            Response.Write("Lệnh không tồn tại");
            return;
        }

        DataRow row = tb.Rows[0];
        switch((int)row["type"])
	    {
            case 2:
                this.to_village_label.Text = "Tấn công thành phố " + (string)row["name2"] + " (" + row["x2"].ToString() + "|" + row["y2"].ToString() + ")";
                break;
            case 3:
                this.to_village_label.Text = "Gửi quân tới thành phố " + (string)row["name2"] + " (" + row["x2"].ToString() + "|" + row["y2"].ToString() + ")";
                break;
            case 4:
                this.to_village_label.Text = "Quay về từ thành phố " + (string)row["name1"] + " (" + row["x1"].ToString() + "|" + row["y1"].ToString() + ")";
                break;
		    default:
                break;
	    }
        this.from_player.Text = (string)row["userid1"];
        this.from_player.NavigateUrl = "player.aspx?id=" + id.ToString() + "&userid=" + (string)row["userid1"];
        this.from_village.Text = (string)row["name1"] + " (" + row["x1"].ToString() + "|" + row["y1"].ToString() + ")";
        this.from_village.NavigateUrl = "village_info.aspx?id=" + id.ToString() + "&village=" + row["id1"].ToString();
        this.to_player.Text = (string)row["userid2"];
        this.to_player.NavigateUrl = "player.aspx?id=" + id.ToString() + "&userid=" + (string)row["userid2"];
        this.to_village.Text = (string)row["name2"] + " (" + row["x2"].ToString() + "|" + row["y2"].ToString() + ")";
        this.to_village.NavigateUrl = "village_info.aspx?id=" + id.ToString() + "&village=" + row["id2"].ToString();

        this.land_time.Text = row["landing_time"].ToString();
        this.timer.Text = ((DateTime)row["landing_time"] - DateTime.Now).ToString();
        this.rally_url.NavigateUrl = "rally.aspx?id=" + id.ToString();

        string sTroop = "";
        if (((string)row["userid1"] == (string)Session["username"]) || ((int)row["type"] == 4))
        {
            sTroop =  "<table><tbody><tr><th width='50'><img src='images/unit_spear.png' title='Spear fighter' alt=''></th><th width='50'><img src='images/unit_sword.png' title='Swordsman' alt=''></th><th width='50'><img src='images/unit_axe.png' title='Axeman' alt=''></th><th width='50'><img src='images/unit_spy.png' title='Scout' alt=''></th><th width='50'><img src='images/unit_light.png' title='Light cavalry' alt=''></th><th width='50'><img src='images/unit_heavy.png' title='Heavy cavalry' alt=''></th><th width='50'><img src='images/unit_ram.png' title='Ram' alt=''></th><th width='50'><img src='images/unit_catapult.png' title='Catapult' alt=''></th><th width='50'><img src='images/unit_snob.png' title='Nobleman' alt=''></th></tr>";
            sTroop += "<tr><td>" + row["spear"] + "</td><td>" + row["sword"] + "</td><td>" + row["axe"] + "</td><td>" + row["scout"] + "</td><td>" + row["light"] + "</td><td>" + row["heavy"] + "</td><td>" + row["ram"] + "</td><td>" + row["catapult"] + "</td><td>" + row["noble"] + "</td></tr></tbody></table>";
        }

        string sResources = "";

        if ((int)row["type"] == 4)
        {
            sResources = "<table><tbody><tr><th width='50'><img src='images/lehm.png' title='Đá' alt=''></th><th width='50'><img src='images/holz.png' title='Gỗ' alt=''></th><th width='50'><img src='images/eisen.png' title='Kim loại' alt=''></th>";
            sResources += "<tr><td>" + row["clay"] + "</td><td>" + row["wood"] + "</td><td>" + row["iron"] + "</td></tr></table>";
        }

        this.lblResources.Text = sResources;
        this.lblTroop.Text = sTroop;
    }
}
