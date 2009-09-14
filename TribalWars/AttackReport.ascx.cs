﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class AttackReport : System.Web.UI.UserControl
{
    protected beans.AttackReport AttackReportEntity
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
        get { return this.AttackReportEntity; }
        set
        {
            if (value.Type != ReportType.Attack)
                Response.Redirect(string.Format("list_report.aspx?id={0}", this.Village.ID), false);
            else
                this.AttackReportEntity = (beans.AttackReport)value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Functions.IsGreaterThenZero(this.AttackReportEntity.Clay, this.AttackReportEntity.Wood, this.AttackReportEntity.Iron))
        {
            this.pPillaged.Visible = true;
            this.pClay.Visible = (this.AttackReportEntity.Clay > 0);
            this.pWood.Visible = (this.AttackReportEntity.Wood > 0);
            this.pIron.Visible = (this.AttackReportEntity.Iron > 0);
        }
    }
}