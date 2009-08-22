using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class CustomControls_ResourceReceive : System.Web.UI.UserControl
{

    protected ResourceReceiveReport ResourceReceiveReport
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
        get { return this.ResourceReceiveReport; }
        set
        {
            if (value.Type != ReportType.ResourceReceive)
                Response.Redirect(string.Format("list_report.aspx?id={0}", this.Village.ID), false);
            else
                this.ResourceReceiveReport = (ResourceReceiveReport)value;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
