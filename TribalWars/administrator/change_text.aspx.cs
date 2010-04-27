using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using NHibernate;
using beans;

public partial class administrator_change_text : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (IsPostBack)
            return;

        if (Request["key"] == null)
        {
            Response.Redirect("text_settings.aspx", false);
            return;
        }

        StringConfiguration config = beans.Configuration.TribalWarsConfiguration.GetStringConfigurationItem(Request["key"]);
        if (config.Value==string.Empty)
        {
            Response.Redirect("text_settings.aspx", false);
            return;
        }

        this.txtKey.Text = config.Key;
        this.txtValue.Content = config.Value;

        RadTreeNode parentNode = ((administrator_administrator)this.Master).Menu.FindNodeByValue(beans.JobEnum.TextSettings.ToString());
        parentNode.Expanded = true;
        RadTreeNode childNode = parentNode.Nodes.FindNodeByValue("list");

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
