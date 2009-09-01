using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class DefenseReport : System.Web.UI.UserControl
{
    protected beans.DefenseReport DefenseReportEntity
    {
        get;
        set;
    }
    public Village Village
    {
        get;
        set;
    }

    public Report Report
    {
        get { return this.DefenseReportEntity; }
        set
        {
            if (value.Type != ReportType.Defense)
                Response.Redirect(string.Format("list_report.aspx?id={0}", this.Village.ID), false);
            else
                this.DefenseReportEntity = (beans.DefenseReport)value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Functions.IsGreaterThenZero(this.DefenseReportEntity.Clay, this.DefenseReportEntity.Wood, this.DefenseReportEntity.Iron))
        {
            this.pPillaged.Visible = true;
            this.pClay.Visible = (this.DefenseReportEntity.Clay > 0);
            this.pWood.Visible = (this.DefenseReportEntity.Wood > 0);
            this.pIron.Visible = (this.DefenseReportEntity.Iron > 0);
        }
    }
}
