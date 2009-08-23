﻿using System;
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
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player user = session.Load<Player>(Session["user"]);
        int type, page;
        int.TryParse(Request["type"], out type);
        int.TryParse(Request["page"], out page);
        IList<Report> lstReports = null;// = user.GetReport(page, session);
        switch (type)
        {
            case 1:
                lstReports = user.GetReports(page, session, ReportType.Attack);
                navigator.Rows[1].Cells[0].Attributes["class"] = "selected";
                break;
            case 2:
                lstReports = user.GetReports(page, session, ReportType.Defense, ReportType.DefenseOther);
                navigator.Rows[2].Cells[0].Attributes["class"] = "selected";
                break;
            case 3:
                lstReports = user.GetReports(page, session, ReportType.Support, ReportType.SupportSendBack, ReportType.SupportWithdawal);
                navigator.Rows[3].Cells[0].Attributes["class"] = "selected";
                break;
            case 4:
                lstReports = user.GetReports(page, session, ReportType.ResourceReceive, ReportType.OfferAccepted);
                navigator.Rows[4].Cells[0].Attributes["class"] = "selected";
                break;
            case 5:
                lstReports = user.GetReports(page, session, ReportType.InviteToTribe);
                navigator.Rows[5].Cells[0].Attributes["class"] = "selected";
                break;
            default:
                lstReports = user.GetReports(page, session);
                navigator.Rows[0].Cells[0].Attributes["class"] = "selected";
                break;
        }
        this.gvReports.DataSource = lstReports;
        //System.Web.UI.WebControls.HyperLinkField field = (HyperLinkField)this.gvReports.Columns[0];
        //field.DataNavigateUrlFormatString = "report_details.aspx?id=" + this.village.ID.ToString() + "&report={0}";
        this.gvReports.DataBind();

        //session.Close();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }

    public string UnreadNotify(bool unread)
    {
        if (unread)
            return "(chưa đọc)";
        return "";
    }
}
