using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class CustomControls_AttackReport : System.Web.UI.UserControl
{
    protected AttackReport AttackReport
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
        get { return this.AttackReport; }
        set
        {
            if (value.Type != ReportType.Attack)
                Response.Redirect(string.Format("list_report.aspx?id={0}", this.Village.ID), false);
            else
                this.AttackReport = (AttackReport)value;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Functions.IsGreaterThenZero(this.AttackReport.Clay, this.AttackReport.Wood, this.AttackReport.Iron))
        {
            this.pPillaged.Visible = true;
            this.pClay.Visible = (this.AttackReport.Clay > 0);
            this.pWood.Visible = (this.AttackReport.Wood > 0);
            this.pIron.Visible = (this.AttackReport.Iron > 0);
        }
    }
}
