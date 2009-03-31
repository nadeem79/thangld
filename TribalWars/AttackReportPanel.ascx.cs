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

using beans;

public partial class AttackReportPanel : System.Web.UI.UserControl
{

    protected beans.AttackReport report;
    protected Village village;

    public Village CurrentVillage
    {
        get
        {
            return this.village;
        }
        set
        {
            this.village = value;
        }
    }

    public Report CurrentReport
    {
        get
        {
            return this.report;
        }
        set
        {
            if (value.Type != ReportType.Attack)
                throw new Exception("Hack hả ku :))");
            this.report = (AttackReport)value;
        }
    }

    public AttackReportPanel() 
    {
        //this.
        this.Init += new EventHandler(AttackReportPanel_Init);
    }

    void AttackReportPanel_Init(object sender, EventArgs e)
    {
        //this.pResources.Visible = this.report.SuccessAttack;
    }

    public AttackReportPanel(Report report, Village village):this()
    {
        this.CurrentReport = report;
        this.CurrentVillage = village;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}
