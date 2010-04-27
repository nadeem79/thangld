using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class write_mail : System.Web.UI.Page
{
    protected Village village;
      protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Form.Attributes.Add("onsubmit", "tinyMCE.triggerSave();");
        this.Page.Form.Enctype = "multipart/form-data";
        this.village = ((inPage)this.Master).CurrentVillage;
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player user = session.Load<Player>(Session["user"]);
        this.Pmail.Controls.Add(Page.LoadControl("Writemail.ascx"));

    
    }


}
