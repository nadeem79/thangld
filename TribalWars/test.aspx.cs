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

using NHibernate;
using NHibernate.Linq;
using beans;
using Telerik.Web.UI;
using System.Collections.Generic;
using Iesi.Collections;

public partial class test : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];

        this.Label1.Text = session.Get<Player>(1).Username;
    }

    protected void bttnSend_Click(object sender, EventArgs e)
    {
        
    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
}
