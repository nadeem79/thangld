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
using System.Drawing;
using System.Data.SqlClient;

public partial class map : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int target;
        int.TryParse(Request["target"], out target);

        for (int r = 0; r < 100; r++)
        {
            TableRow row = new TableRow();
            for (int c = 0; c < 100; c++)
            {
                TableCell cell = new TableCell();
                cell.CssClass = "cell_no_village";
                row.Controls.Add(cell);
            }
            tbWorldMap.Controls.Add(row);
        }

        inPage parent = (inPage)this.Master;

        SqlCommand cmdGetVillages = parent.conn.CreateCommand();
        cmdGetVillages.CommandText = "select id, name, x, y, userid from villages";
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmdGetVillages);
        da.Fill(dt);
        
        foreach (DataRow row in dt.Rows)
        {
            HyperLink link = new HyperLink();
            link.NavigateUrl = "village_info.aspx?id=" + Request["id"] + "&village=" + row["id"].ToString();
            int x = (int)row["x"];
            int y = (int)row["y"];
            TableCell cell = tbWorldMap.Rows[x].Cells[y];
            cell.CssClass = "cell_map";
            cell.Controls.Add(link);
            if ((string)row["userid"] == (string)Session["username"])
                cell.BackColor = Color.Blue;
            else if ((int)row["id"] == target)
                cell.BackColor = Color.White;
            else
                cell.BackColor = Color.Red;
            cell.Controls.Add(link);
            cell.ToolTip = "Thành phố: " + (string)row["name"] + Environment.NewLine;
            cell.ToolTip += "Chủ thành: " + (string)row["userid"] + Environment.NewLine;
            cell.ToolTip += "Toạ độ: " + (string)row["x"].ToString() + "|" + (string)row["y"].ToString() + Environment.NewLine;
            cell.Style.Add("cursor", "pointer");
            cell.Attributes.Add("onclick", "window.location='village_info.aspx?id=" + Request["id"] + "&village=" + row["id"].ToString() + "'");
            
        }
        
        
    }
}
