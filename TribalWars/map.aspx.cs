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

    protected int x = 0, y = 0;
    protected Village village;
    protected Village targetVillage;

    protected void Page_Load(object sender, EventArgs e)
    {

        village = ((inPage)this.Master).CurrentVillage;
        ISession session;
        if (this.IsPostBack)
        {
            this.x = (int)ViewState["x"];
            this.y = (int)ViewState["y"];
            return;
        }
            
        int target = 0;
        int.TryParse(Request["target"], out target);
        int.TryParse(Request["x"], out this.x);
        int.TryParse(Request["y"], out this.y);
        IList<Village> villages = null;

        session = (ISession)Context.Items["NHibernateSession"];

        // x!=0 và y!=0 => center x,y
        // x hoặc y = 0, target = 0 => center this village
        // x hoặc y =0, target !=0, targetVillage != null => center targetVillage
        // x hoặc y =0, target !=0, targetVillage == null => center this village
        
        if (this.x != 0 && this.y != 0)
        {
            villages = beans.Map.GetMap(this.x, this.y, session);
            this.targetVillage = this.village;

        }
        else if (target == 0)
        {
            villages = beans.Map.GetMap(this.village, session);
            this.targetVillage = this.village;
            this.x = targetVillage.X;
            this.y = targetVillage.Y;
        }
        else
        {
            targetVillage = session.Get<Village>(target);
            if (targetVillage == null)
                targetVillage = this.village;
            villages = beans.Map.GetMap(targetVillage, session);
            this.x = targetVillage.X;
            this.y = targetVillage.Y;
        }

        ViewState["x"] = this.x;
        ViewState["y"] = this.y;

        this.FillMap(villages);

    }

    private void FillMap(IList<Village> villages)
    {
        Random r = new Random();
        this.tbRows.Rows.Clear();
        this.tbColumns.Rows.Clear();

        this.tbVillages.Rows.Clear();
        
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
                cell.Style.Clear();
                row.Cells.Add(cell);
            }
            this.tbVillages.Rows.Add(row);
        }
        this.tbColumns.Rows.Add(cRow);


        foreach (Village v in villages)
        {
            TableCell cell = this.tbVillages.Rows[7 + v.X - this.x].Cells[7 + v.Y - this.y];
            cell.CssClass = "space-left-new space-bottom-new background20";
            if (v.Player.ID == (int)Session["user"])
                cell.Style.Add("background", "yellow");
            else
                cell.Style.Add("background", "red");

            HyperLink link = new HyperLink();
            link.Style.Add("margin", "0px");
            link.Style.Add("padding", "0px");
            link.ImageUrl = @"images/v6.png";
            //link.BackColor = Color.Red;
            link.NavigateUrl = "village_info.aspx?id=" + this.village.ID.ToString() + "&village=" + v.ID.ToString();

            link.ToolTip = "Thành phố: " + v.Name + " (" + v.X.ToString("000") + "|" + v.Y.ToString("000") + ")<br />" + Environment.NewLine;
            link.ToolTip += "Chủ thành: " + v.Player.Username;
            cell.Controls.Add(link);
        }
    }

    protected void moveNorthButton_Click(object sender, ImageClickEventArgs e)
    {
        
        this.x -= 15;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        IList<Village> villages = beans.Map.GetMap(this.x, this.y, session);
        this.FillMap(villages);
        ViewState["x"] = this.x;
        ViewState["y"] = this.y;
    }
    protected void moveEastButton_Click(object sender, ImageClickEventArgs e)
    {
        this.y += 15;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        IList<Village> villages = beans.Map.GetMap(this.x, this.y, session);
        this.FillMap(villages);
        ViewState["x"] = this.x;
        ViewState["y"] = this.y;
    }
    protected void moveSouthButton_Click(object sender, ImageClickEventArgs e)
    {
        this.x += 15;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        IList<Village> villages = beans.Map.GetMap(this.x, this.y, session);
        this.FillMap(villages);
        ViewState["x"] = this.x;
        ViewState["y"] = this.y;
    }
    protected void moveWestButton_Click(object sender, ImageClickEventArgs e)
    {
        this.y -= 15;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        IList<Village> villages = beans.Map.GetMap(this.x, this.y, session);
        this.FillMap(villages);
        ViewState["x"] = this.x;
        ViewState["y"] = this.y;
    }

    protected void centerButton_Click(object sender, EventArgs e)
    {
        
        int.TryParse(this.txtX.Text, out this.x);
        int.TryParse(this.txtY.Text, out this.y);

        if (this.x == 0 || this.y == 0)
            return;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        IList<Village> villages = beans.Map.GetMap(this.x, this.y, session);
        this.FillMap(villages);
        ViewState["x"] = this.x;
        ViewState["y"] = this.y;

    }
}
