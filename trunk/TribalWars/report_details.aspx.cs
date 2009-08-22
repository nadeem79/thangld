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

    protected void Page_Load(object sender, EventArgs e)
    {
        village = ((inPage)this.Master).CurrentVillage;
        int report_id;

        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];

        int.TryParse(Request["report"], out report_id);
        Player user = session.Load<Player>(Session["user"]);
        report = user.GetReport(report_id, session);

        if (report != null)
        {
            pHasReport.Visible = true;
            switch (report.Type)
            {
                case ReportType.Attack:
                case ReportType.Defense:
                    CustomControls_AttackReport pAttackReport = (CustomControls_AttackReport)Page.LoadControl(@"CustomControls/AttackReport.ascx");
                    pAttackReport.Village = this.village;
                    pAttackReport.Report = report;
                    this.panelReport.Controls.Add(pAttackReport);
                    break;
                case ReportType.InviteToTribe:
                    CustomControls_InviteReport pInviteReport = (CustomControls_InviteReport)Page.LoadControl(@"CustomControls/InviteReport.ascx");
                    pInviteReport.Village = this.village;
                    pInviteReport.Report = report;
                    this.panelReport.Controls.Add(pInviteReport);
                    break;
                case ReportType.DefenseOther:
                    
                default:
                    pNoReport.Visible = true;
                    pHasReport.Visible = false;
                    break;
            }
        }
        else
            pNoReport.Visible = true;

        
    }
}
