using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class CustomControls_SupportOtherReport : System.Web.UI.UserControl
{

    protected SupportReport SupportReport
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
        get { return this.SupportReport; }
        set
        {
            if (value.Type != ReportType.Support)
                Response.Redirect(string.Format("list_report.aspx?id={0}", this.Village.ID), false);
            else
                this.SupportReport = (SupportReport)value;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
