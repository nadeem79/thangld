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
using System.Xml.Linq;
using beans;

public partial class shoutbox : System.Web.UI.Page
{
    protected Player currentPlayer;
    protected void Page_Load(object sender, EventArgs e)
    {
        int group_chat = 0;
        int.TryParse(Request["group_chat"], out group_chat);

        NHibernate.ISession session = null;
        try
        {
            
            if (group_chat == 0)
            {
                this.Shoutbox.Group = null;
            }
            else
            {
                session = NHibernateHelper.CreateSession();
                currentPlayer = session.Get<Player>(Session["user"]);
                this.Shoutbox.Group = currentPlayer.Group;
            }
        }
        catch (Exception ex) { }
        finally
        {
            if (session != null)
                session.Close();
        }
 

    }
}
