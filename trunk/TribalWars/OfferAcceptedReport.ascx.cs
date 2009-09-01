using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class OfferAcceptedReport : System.Web.UI.UserControl
{

    protected beans.OfferAcceptedReport OfferAcceptedReportEntity
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
        get { return this.OfferAcceptedReportEntity; }
        set
        {
            if (value.Type != ReportType.OfferAccepted)
                Response.Redirect(string.Format("list_report.aspx?id={0}", this.Village.ID), false);
            else
                this.OfferAcceptedReportEntity = (beans.OfferAcceptedReport)value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
