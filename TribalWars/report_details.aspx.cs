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
                    CustomControls_AttackReport pAttackReport = (CustomControls_AttackReport)Page.LoadControl(@"CustomControls/AttackReport.ascx");
                    pAttackReport.Village = this.village;
                    pAttackReport.Report = report;
                    this.panelReport.Controls.Add(pAttackReport);
                    navigator.Rows[1].Cells[0].Attributes["class"] = "selected";
                    break;
                case ReportType.Defense:
                    CustomControls_DefenseReport pDefenseReport = (CustomControls_DefenseReport)Page.LoadControl(@"CustomControls/DefenseReport.ascx");
                    pDefenseReport.Village = this.village;
                    pDefenseReport.Report = report;
                    this.panelReport.Controls.Add(pDefenseReport);
                    navigator.Rows[2].Cells[0].Attributes["class"] = "selected";
                    break;
                case ReportType.InviteToTribe:
                    CustomControls_InviteReport pInviteReport = (CustomControls_InviteReport)Page.LoadControl(@"CustomControls/InviteReport.ascx");
                    pInviteReport.Village = this.village;
                    pInviteReport.Report = report;
                    this.panelReport.Controls.Add(pInviteReport);
                    navigator.Rows[5].Cells[0].Attributes["class"] = "selected";
                    break;
                case ReportType.DefenseOther:
                    CustomControls_DefenseOtherReport pDefenseOther = (CustomControls_DefenseOtherReport)Page.LoadControl(@"CustomControls/DefenseOtherReport.ascx");
                    pDefenseOther.Village = this.village;
                    pDefenseOther.Report = report;
                    this.panelReport.Controls.Add(pDefenseOther);
                    navigator.Rows[2].Cells[0].Attributes["class"] = "selected";
                    break;
                case ReportType.OfferAccepted:
                    CustomControls_OfferAcceptedReport pOfferAcceptedReport = (CustomControls_OfferAcceptedReport)Page.LoadControl(@"CustomControls/OfferAcceptedReport.ascx");
                    pOfferAcceptedReport.Village = this.village;
                    pOfferAcceptedReport.Report = report;
                    this.panelReport.Controls.Add(pOfferAcceptedReport);
                    navigator.Rows[3].Cells[0].Attributes["class"] = "selected";
                    break;
                case ReportType.ResourceReceive:
                    CustomControls_ResourceReceive pResourceReceive = (CustomControls_ResourceReceive)Page.LoadControl(@"CustomControls/ResourceReceive.ascx");
                    pResourceReceive.Village = this.village;
                    pResourceReceive.Report = report;
                    this.panelReport.Controls.Add(pResourceReceive);
                    navigator.Rows[3].Cells[0].Attributes["class"] = "selected";
                    break;
                case ReportType.Support:
                    CustomControls_SupportOtherReport pSupport = (CustomControls_SupportOtherReport)Page.LoadControl(@"CustomControls/SupportOtherReport.ascx");
                    pSupport.Village = this.village;
                    pSupport.Report = report;
                    this.panelReport.Controls.Add(pSupport);
                    navigator.Rows[2].Cells[0].Attributes["class"] = "selected";
                    break;
                case ReportType.SupportSendBack:
                    CustomControls_SupportSendBackReport pSupportSendBack = (CustomControls_SupportSendBackReport)Page.LoadControl(@"CustomControls/SupportSendBackReport.ascx");
                    pSupportSendBack.Village = this.village;
                    pSupportSendBack.Report = report;
                    this.panelReport.Controls.Add(pSupportSendBack);
                    navigator.Rows[2].Cells[0].Attributes["class"] = "selected";
                    break;
                case ReportType.SupportWithdawal:
                    CustomControls_TroopWithdrawal pTroopWithdrawal = (CustomControls_TroopWithdrawal)Page.LoadControl(@"CustomControls/TroopWithdrawal.ascx");
                    pTroopWithdrawal.Village = this.village;
                    pTroopWithdrawal.Report = report;
                    this.panelReport.Controls.Add(pTroopWithdrawal);
                    navigator.Rows[3].Cells[0].Attributes["class"] = "selected";
                    break;
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
