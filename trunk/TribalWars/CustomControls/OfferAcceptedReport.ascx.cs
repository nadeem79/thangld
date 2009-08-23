using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class CustomControls_OfferAcceptedReport : System.Web.UI.UserControl
{

    protected OfferAcceptedReport OfferAcceptedReport
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
        get { return this.OfferAcceptedReport; }
        set
        {
            if (value.Type != ReportType.OfferAccepted)
                Response.Redirect(string.Format("list_report.aspx?id={0}", this.Village.ID), false);
            else
                this.OfferAcceptedReport = (OfferAcceptedReport)value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
