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
using NHibernate;

public partial class report_details : System.Web.UI.Page
{
    protected Village village;
    protected Report report;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        village = ((inPage)this.Master).CurrentVillage;
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int report_id;

        ISession session = NHibernateHelper.CreateSession();

        int.TryParse(Request["report"], out report_id);
        Player user = session.Load<Player>(Session["user"]);
        report = user.GetReport(report_id, session);

        session.Close();
        if (report != null)
        {
            pNoReport.Visible = false;
            switch (report.Type)
            {
                case ReportType.Attack:
                    AttackReportPanel c = (AttackReportPanel)Page.LoadControl("AttackReportPanel.ascx");
                    c.CurrentReport = report;
                    c.CurrentVillage = village;
                    this.pReport.Controls.Add(c);
                    return;
            }
        }

        
    }
}
