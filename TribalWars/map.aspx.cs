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
using NHibernate;
using beans;
using System.Collections.Generic;
using NHibernate.Criterion;
using Telerik.Web.UI;

public partial class map : System.Web.UI.Page
{

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

        IList<Village> villages = beans.Map.GetMap(targetVillage, session);
        //ICriteria criteria = session.CreateCriteria(typeof(Village));

        //criteria.Add(Expression.Le("X", targetVillage.X + 7));
        //criteria.Add(Expression.Ge("X", targetVillage.X - 7));
        //criteria.Add(Expression.Le("Y", targetVillage.Y + 7));
        //criteria.Add(Expression.Ge("Y", targetVillage.Y - 7));
        //criteria.AddOrder(Order.Desc("X"));
        //criteria.AddOrder(Order.Desc("Y"));

        //IList<Village> villages = criteria.List<Village>();

        session.Close();
        Random r = new Random();
        this.tbVillages.Style.Add("border", "1px solid black");

        for (int i = 0; i < 15; i++)
        {
            TableRow row = new TableRow();
            for (int j = 0; j < 15; j++)
            {
                TableCell cell = new TableCell();
                cell.CssClass = "space-left-new space-bottom-new background" + (r.Next(4) + 1 + 17).ToString();
                row.Cells.Add(cell);
            }
            this.tbVillages.Rows.Add(row);
        }

        foreach (Village v in villages)
        {
            TableCell cell = this.tbVillages.Rows[7 + v.X - targetVillage.X].Cells[7 + v.Y - targetVillage.Y];
            cell.CssClass = "space-left-new space-bottom-new";
            cell.BackColor = Color.Red;
            if (v.Owner.ID == (int)Session["user"])
                cell.BackColor = Color.Yellow;
            HyperLink link = new HyperLink();
            link.Style.Add("margin", "0px");
            link.Style.Add("padding", "0px");
            link.ImageUrl = @"images/v5.png";
            link.Width = 26;
            link.Height = 19;
            
            link.NavigateUrl = "village_info.aspx?id=" + this.village.ID.ToString() + "&village=" + v.ID.ToString();
            link.ToolTip = "Thành phố: " + v.Name + "(" + v.X.ToString("000") + "|" + v.Y.ToString("000") + ")" + Environment.NewLine;
            link.ToolTip += "Chủ thành: " + v.Owner.Username;
            cell.Controls.Add(link);
        }
        

    }
}
