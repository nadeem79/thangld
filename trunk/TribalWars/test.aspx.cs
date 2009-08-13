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

public partial class test : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];
        Village v = session.Get<Village>(23);
        //IList<MovingCommand> lst = (from movingCommand in session.Linq<MovingCommand>()
        //                            where (movingCommand.GetType() == typeof(SendResource)
        //                            && (movingCommand.FromVillage == v
        //                               || movingCommand.ToVillage == v))
        //                            || (movingCommand.GetType() == typeof(Return)
        //                            && movingCommand.ToVillage == v
        //                            && ((Return)movingCommand).Merchant > 0)
        //                            && movingCommand.LandingTime > DateTime.Now
        //                            orderby movingCommand.LandingTime ascending
        //                            select movingCommand).ToList<MovingCommand>();

        ICriteria criteria = session.CreateCriteria<MovingCommand>();
        

        var query = from movingCommand in session.Linq<SendResource>()
                    select movingCommand;

        IList<SendResource> lst1 = query.ToList<SendResource>();
        
    }

    protected void bttnSend_Click(object sender, EventArgs e)
    {
        
    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Label1.Text += "gg";
    }
}
