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
using NHibernate;

public partial class report_details : System.Web.UI.Page
{
    protected beans.Village village;
    protected beans.Report report;

    protected void Page_Load(object sender, EventArgs e)
    {
        village = ((inPage)this.Master).CurrentVillage;
        int report_id;

        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];

        int.TryParse(Request["report"], out report_id);
        beans.Player user = session.Load<beans.Player>(Session["user"]);
        report = user.GetReport(report_id, session);

        if (report != null)
        {
            pHasReport.Visible = true;
            switch (report.Type)
            {
                case beans.ReportType.Attack:
                    AttackReport pAttackReport = (AttackReport)Page.LoadControl(@"AttackReport.ascx");
                    pAttackReport.Village = this.village;
                    pAttackReport.Report = report;
                    this.panelReport.Controls.Add(pAttackReport);
                    navigator.Rows[1].Cells[0].Attributes["class"] = "selected";
                    break;
                case beans.ReportType.Defense:
                    DefenseReport pDefenseReport = (DefenseReport)Page.LoadControl(@"DefenseReport.ascx");
                    pDefenseReport.Village = this.village;
                    pDefenseReport.Report = report;
                    this.panelReport.Controls.Add(pDefenseReport);
                    navigator.Rows[2].Cells[0].Attributes["class"] = "selected";
                    break;
                case beans.ReportType.InviteToTribe:
                    InviteReport pInviteReport = (InviteReport)Page.LoadControl(@"InviteReport.ascx");
                    pInviteReport.Village = this.village;
                    pInviteReport.Report = report;
                    this.panelReport.Controls.Add(pInviteReport);
                    navigator.Rows[5].Cells[0].Attributes["class"] = "selected";
                    break;
                case beans.ReportType.DefenseOther:
                    DefenseOtherReport pDefenseOther = (DefenseOtherReport)Page.LoadControl(@"DefenseOtherReport.ascx");
                    pDefenseOther.Village = this.village;
                    pDefenseOther.Report = report;
                    this.panelReport.Controls.Add(pDefenseOther);
                    navigator.Rows[2].Cells[0].Attributes["class"] = "selected";
                    break;
                case beans.ReportType.OfferAccepted:
                    OfferAcceptedReport pOfferAcceptedReport = (OfferAcceptedReport)Page.LoadControl(@"OfferAcceptedReport.ascx");
                    pOfferAcceptedReport.Village = this.village;
                    pOfferAcceptedReport.Report = report;
                    this.panelReport.Controls.Add(pOfferAcceptedReport);
                    navigator.Rows[3].Cells[0].Attributes["class"] = "selected";
                    break;
                case beans.ReportType.ResourceReceive:
                    ResourceReceive pResourceReceive = (ResourceReceive)Page.LoadControl(@"ResourceReceive.ascx");
                    pResourceReceive.Village = this.village;
                    pResourceReceive.Report = report;
                    this.panelReport.Controls.Add(pResourceReceive);
                    navigator.Rows[3].Cells[0].Attributes["class"] = "selected";
                    break;
                case beans.ReportType.Support:
                    SupportOtherReport pSupport = (SupportOtherReport)Page.LoadControl(@"SupportOtherReport.ascx");
                    pSupport.Village = this.village;
                    pSupport.Report = report;
                    this.panelReport.Controls.Add(pSupport);
                    navigator.Rows[2].Cells[0].Attributes["class"] = "selected";
                    break;
                case beans.ReportType.SupportSendBack:
                    SupportSendBackReport pSupportSendBack = (SupportSendBackReport)Page.LoadControl(@"SupportSendBackReport.ascx");
                    pSupportSendBack.Village = this.village;
                    pSupportSendBack.Report = report;
                    this.panelReport.Controls.Add(pSupportSendBack);
                    navigator.Rows[2].Cells[0].Attributes["class"] = "selected";
                    break;
                case beans.ReportType.SupportWithdawal:
                    TroopWithdrawal pTroopWithdrawal = (TroopWithdrawal)Page.LoadControl(@"TroopWithdrawal.ascx");
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
