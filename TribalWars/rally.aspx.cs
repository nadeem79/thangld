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
using beans;
using NHibernate.Criterion;
using System.Collections.Generic;
using Telerik.Web.UI;

public partial class rally : System.Web.UI.Page
{
    
    protected beans.Village village;
    protected Attack attack;
    protected Support support;

    protected void Page_Load(object sender, EventArgs e)
    {
        inPage p = (inPage)this.Master;
        village = p.CurrentVillage;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Button1.Text = this.spear.Text;
    }

    protected void bttnAttack_Click(object sender, EventArgs e) { }
    protected void bttnSupport_Click(object sender, EventArgs e) { }
}
