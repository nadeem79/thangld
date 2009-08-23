using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class CustomControls_DefenseReport : System.Web.UI.UserControl
{
    protected DefenseReport DefenseReport
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
        get { return this.DefenseReport; }
        set
        {
            if (value.Type != ReportType.Defense)
                Response.Redirect(string.Format("list_report.aspx?id={0}", this.Village.ID), false);
            else
                this.DefenseReport = (DefenseReport)value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Functions.IsGreaterThenZero(this.DefenseReport.Clay, this.DefenseReport.Wood, this.DefenseReport.Iron))
        {
            this.pPillaged.Visible = true;
            this.pClay.Visible = (this.DefenseReport.Clay > 0);
            this.pWood.Visible = (this.DefenseReport.Wood > 0);
            this.pIron.Visible = (this.DefenseReport.Iron > 0);
        }
    }
}
