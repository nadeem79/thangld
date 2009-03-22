using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
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
        int report_id;
        
        ISession session = NHibernateHelper.CreateSession();

        int.TryParse(Request["report"], out report_id);
        Player user = session.Load<Player>(Session["user"]);
        report = user.GetReport(report_id, session);

        session.Close();
        this.AttackReportPanel1.CurrentReport = report;
        this.AttackReportPanel1.CurrentVillage = village;
        Response.RedirectLocation = "index.aspx";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        
        
        //string id = Request["id"];
        //this.urlAllReports.NavigateUrl += "&id=" + id;
        //this.urlAttackReports.NavigateUrl += "&id=" + id;
        //this.urlDefenseReports.NavigateUrl += "&id=" + id;
        //this.urlMarketReports.NavigateUrl += "&id=" + id;
        //this.urlSupportReports.NavigateUrl += "&id=" + id;
        //this.navigator.Rows[(int)report_info["type"]].Cells[0].Attributes["class"] = "selected";

        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
