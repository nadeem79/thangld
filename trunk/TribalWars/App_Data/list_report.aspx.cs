using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;
using beans;
using System.Collections.Generic;
using NHibernate;

public partial class list_report : System.Web.UI.Page
{
    protected Village village;
    protected void Page_Load(object sender, EventArgs e)
    {

        this.village = ((inPage)this.Master).CurrentVillage;
        ISession session = NHibernateHelper.CreateSession();
        Player user = session.Load<Player>(Session["user"]);
        int type, page;
        int.TryParse(Request["type"], out type);
        int.TryParse(Request["page"], out page);
        IList<Report> lstReports = user.GetReport(ReportTypeFactory.GetReportType(type), page, session);

        this.gvReports.DataSource = lstReports;
        System.Web.UI.WebControls.HyperLinkField field = (HyperLinkField)this.gvReports.Columns[0];
        field.DataNavigateUrlFormatString = "report_details.aspx?id=" + this.village.ID.ToString() + "&report={0}";
        this.gvReports.DataBind();

        session.Close();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
}
