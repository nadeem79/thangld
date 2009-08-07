using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class administrator_numeric_settings : System.Web.UI.Page
{

    protected ISession NHibernateSession
    {
        get;
        set;
    }
    protected Player CurrentPlayer
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.NHibernateSession = ((administrator_administrator)(this.Master)).NHibernateSession;
        this.CurrentPlayer = ((administrator_administrator)(this.Master)).CurrentPlayer;
        int page = 0;

        if (Request["key"] != null)
        {
            double value = 0;
            if (double.TryParse(Request["value"], out value))
                this.CurrentPlayer.ChangeNumericSetting(Request["key"], value, this.NHibernateSession);
        }

        if (IsPostBack)
            return;

        if (Request["page"] != null)
            int.TryParse(Request["page"], out page);

        IList<NumericConfiguration> numericConfigurations = this.CurrentPlayer.GetNumericSettings(this.NHibernateSession);
        this.numericConfigurationRepeater.DataSource = numericConfigurations;
        this.numericConfigurationRepeater.DataBind();
        
    }
    protected void deleteSettingButton_Click(object sender, EventArgs e)
    {
        for (int cnt = 0; cnt < numericConfigurationRepeater.Items.Count; cnt++)
        {
            // your checkbox ; type casting
            CheckBox cbId = ((CheckBox)numericConfigurationRepeater.Items[cnt].FindControl("checkDeleteCheckBox"));

            // user id
            string id = cbId.ToolTip;
            // or the other option; value from hidden field

            if (cbId.Checked)
            {
                this.CurrentPlayer.DeleteNumericSetting(id, this.NHibernateSession);
                Response.Redirect(Request.Url.ToString(), false);
            }
        }
    }

    protected void createNewSettingButton_Click(object sender, EventArgs e)
    {
        double value = 0;
        double.TryParse(this.valueTextBox.Text, out value);
        this.CurrentPlayer.ChangeNumericSetting(this.keyTextBox.Text, value, this.NHibernateSession);
        Response.Redirect(Request.Url.ToString(), false);
    }
}
