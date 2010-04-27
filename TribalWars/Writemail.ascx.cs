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
using NHibernate;

public partial class writemail : System.Web.UI.UserControl
{

    protected Player player; 
    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        this.player = session.Load<Player>(Session["user"]);
        this.Receiver.Text =(Request["receiver"]);
        this.Title.Text = (Request["title"]);
        String temp = (Request["detail"]);
            if ( temp != null ) this.Detail.Content = temp;
    }

    protected void sendmail_Click(object sender, EventArgs e)
    {
        try
        {
            this.player.SendMail(this.Receiver.Text, this.Title.Text, this.Detail.Text, (ISession)Context.Items[Constant.NHibernateSessionSign]);
        }
        catch (Exception ex)
        {
            this.error.Text = ex.Message;
        } 
            
    }       
}
