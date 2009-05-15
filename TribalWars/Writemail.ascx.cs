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
        ISession session = NHibernateHelper.CreateSession();
        this.player = session.Load<Player>(Session["user"]);
        session.Close();
    }
    protected void sendmail_Click(object sender, EventArgs e)
    {       
     ISession session = null;
        try
        {
            session = NHibernateHelper.CreateSession();
            this.player = session.Load<Player>(Session["user"]);
            int temp = beans.WriteMail.GetPlayerID(this.Receiver.Text, session);
            if (temp <0 )
            {
                this.error.Text = "Sai tên";
            }
            else
            {
                if (this.player.SendMail(temp, this.Title.Text, this.Detail.Text, session) == true)
                { }  
            
            }      
        }
        finally
        {
            session.Close();
        }
            
    }       
}
