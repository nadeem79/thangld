using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class CustomControls_DefenseOtherReport : System.Web.UI.UserControl
{
    protected DefenseOtherReport DefenseOtherReport
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
        get { return this.DefenseOtherReport; }
        set
        {
            if (value.Type != ReportType.DefenseOther)
                Response.Redirect(string.Format("list_report.aspx?id={0}", this.Village.ID), false);
            else
                this.DefenseOtherReport = (DefenseOtherReport)value;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //this.DefenseOtherReport.
    }
}
