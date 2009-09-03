using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using Telerik.Web.UI;
using beans;

public partial class administrator_create_text : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        RadTreeNode parentNode = ((administrator_administrator)this.Master).Menu.FindNodeByValue(beans.JobEnum.TextSettings.ToString());
        parentNode.Expanded = true;
        RadTreeNode childNode = parentNode.Nodes.FindNodeByValue("create");

        if (childNode != null)
            childNode.ImageUrl = "images/map_e.png";

    }
    
    protected void bttnChangeText_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player p = session.Load<Player>(Session[Constant.StaffUserSessionSign]);

        try
        {
            ServicesList.ConfigurationService.ChangeTextSetting(p, this.txtKey.Text, this.txtValue.Content, session);
        }
        catch (TribalWarsException ex)
        {
            RadScriptManager.RegisterStartupScript(bttnChangeText, bttnChangeText.GetType(), "ShowException", "jQuery.facebox('" + ex.Message + "');", true);
        }
        catch (Exception ex)
        {
            RadScriptManager.RegisterStartupScript(bttnChangeText, bttnChangeText.GetType(), "ShowException", "jQuery.facebox('" + ex.Message + "');", true);
        }
    }
}
