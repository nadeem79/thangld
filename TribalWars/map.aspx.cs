using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Drawing;
using System.Data.SqlClient;
using NHibernate;
using beans;
using System.Collections.Generic;
using NHibernate.Criterion;
using Telerik.Web.UI;

public partial class map : System.Web.UI.Page
{

    private int x, y;
    protected Village village;
    protected Village targetVillage;

    protected void Page_Load(object sender, EventArgs e)
    {

        village = ((inPage)this.Master).CurrentVillage;
        ISession session;

        int target = 0;
        int.TryParse(Request["target"], out target);

        session = NHibernateHelper.CreateSession();
        targetVillage = session.Get<Village>(target);

        if (target == 0 || targetVillage == null)
            targetVillage = this.village;
        this.x = targetVillage.X;
        this.y = targetVillage.Y;
        IList<Village> villages = beans.Map.GetMap(targetVillage, session);
        
        session.Close();
        Random r = new Random();
        this.tbVillages.Style.Add("border", "1px solid black");
        TableRow cRow = new TableRow();
        for (int i = 0; i < 15; i++)
        {
            TableCell rCell = new TableCell();
            rCell.Text = (this.x - 7 + i).ToString();
            //height="38" width="20"
            rCell.Width = 20;
            rCell.Height = 38;
            TableRow rRow = new TableRow();
            rRow.Cells.Add(rCell);
            this.tbRows.Rows.Add(rRow);

            TableCell cCell = new TableCell();
            cCell.Text = (this.y - 7 + i).ToString();
            cCell.Width = 49;
            cRow.Cells.Add(cCell);

            TableRow row = new TableRow();
            for (int j = 0; j < 15; j++)
            {
                TableCell cell = new TableCell();
                cell.CssClass = "space-left-new space-bottom-new background" + (r.Next(4) + 1 + 17).ToString();
                row.Cells.Add(cell);
            }
            this.tbVillages.Rows.Add(row);
        }
        this.tbColumns.Rows.Add(cRow);

        foreach (Village v in villages)
        {
            TableCell cell = this.tbVillages.Rows[7 + v.X - targetVillage.X].Cells[7 + v.Y - targetVillage.Y];
            cell.CssClass = "space-left-new space-bottom-new";
            cell.BackColor = Color.Red;
            if (v.Player.ID == (int)Session["user"])
                cell.BackColor = Color.Yellow;
            HyperLink link = new HyperLink();
            link.Style.Add("margin", "0px");
            link.Style.Add("padding", "0px");
            link.ImageUrl = @"images/v6.png";
            
            link.NavigateUrl = "village_info.aspx?id=" + this.village.ID.ToString() + "&village=" + v.ID.ToString();

            link.ToolTip = "Thành phố: " + v.Name + " (" + v.X.ToString("000") + "|" + v.Y.ToString("000") + ")<br />" + Environment.NewLine;
            link.ToolTip += "Chủ thành: " + v.Player.Username;
            cell.Controls.Add(link);
        }
        

    }
}
