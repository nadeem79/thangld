using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class CustomControls_InviteReport : System.Web.UI.UserControl
{
    protected InviteReport InviteReport
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
        get { return this.InviteReport; }
        set
        {
            if (value.Type != ReportType.InviteToTribe)
                Response.Redirect(string.Format("list_report.aspx?id={0}", this.Village.ID), false);
            else
                this.InviteReport = (InviteReport)value;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
