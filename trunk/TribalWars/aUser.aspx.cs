using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class aUser : System.Web.UI.Page
{
    protected Admin Admin; 
    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();
        Admin user = session.Load<Admin>(Session["user"]);
        int page;
        int.TryParse(Request["page"], out page);
        IList<Player> lstMail = user.GetUserlist(page, session);
        this.gvuser.DataSource = lstMail;
        System.Web.UI.WebControls.HyperLinkField field = (HyperLinkField)this.gvuser.Columns[0];
        field.DataNavigateUrlFormatString = "auser_detail.aspx?id={0}";
        
        this.gvuser.DataBind();        
        session.Close();

    }
  

}
