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

        //var villageInfo = (from village in session.Linq<Village>()
        //             select new MyType { Name=village.Name, X= village.X,Y=village.Y, Username= village.Player.Username });
        //this.RadGrid1.DataSource = villageInfo;
        //this.RadGrid1.DataBind();
        //foreach (MyType t in villageInfo)
        //    this.Label1.Text += t.Name;
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
