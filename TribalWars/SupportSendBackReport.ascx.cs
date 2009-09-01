using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class SupportSendBackReport : System.Web.UI.UserControl
{

    protected SupportSendbackReport SupportSendbackReport
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
        get { return this.SupportSendbackReport; }
        set
        {
            if (value.Type != ReportType.SupportSendBack)
                Response.Redirect(string.Format("list_report.aspx?id={0}", this.Village.ID), false);
            else
                this.SupportSendbackReport = (SupportSendbackReport)value;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
