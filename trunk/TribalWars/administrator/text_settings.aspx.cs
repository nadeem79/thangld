﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using beans;
using Telerik.Web.UI;

public partial class administrator_text_settings : System.Web.UI.Page
{

    protected Player CurrentPlayer
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        this.CurrentPlayer = session.Load<Player>(Session[Constant.StaffUserSessionSign]);
        int page = 0;


        if (IsPostBack)
            return;

        if (Request["page"] != null)
            int.TryParse(Request["page"], out page);

        IList<StringConfiguration> stringConfigurations = this.CurrentPlayer.AdminConfigurationMethods.GetTextSettings(session);
        this.stringConfigurationRepeater.DataSource = stringConfigurations;
        this.stringConfigurationRepeater.DataBind();
        RadTreeNode parentNode = ((administrator_administrator)this.Master).Menu.FindNodeByValue(beans.JobEnum.TextSettings.ToString());
        parentNode.Expanded = true;
        RadTreeNode childNode = parentNode.Nodes.FindNodeByValue("list");

        if (childNode != null)
            childNode.ImageUrl = "images/map_e.png";

    }
    protected void deleteSettingButton_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        for (int cnt = 0; cnt < stringConfigurationRepeater.Items.Count; cnt++)
        {
            // your checkbox ; type casting
            CheckBox cbId = ((CheckBox)stringConfigurationRepeater.Items[cnt].FindControl("checkDeleteCheckBox"));

            // user id
            string id = cbId.ToolTip;
            // or the other option; value from hidden field

            if (cbId.Checked)
            {
                this.CurrentPlayer.AdminConfigurationMethods.DeleteTextSetting(id, session);
                Response.Redirect(Request.Url.ToString(), false);
            }
        }
    }

    protected void createNewSettingButton_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        this.CurrentPlayer.AdminConfigurationMethods.ChangeTextSetting(this.keyTextBox.Text, this.valueTextBox.Content, session);
        Response.Redirect(Request.Url.ToString(), false);
    }

    protected void stringConfigurationRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteConfig")
        {
            ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            string key = e.CommandArgument.ToString();

            Player p = session.Load<Player>(Session[Constant.StaffUserSessionSign]);

            ServicesList.ConfigurationService.DeleteTextSetting(p, key, session);

        }
    }
    protected void ValueChanged(object sender, EventArgs e)
    {
        TextBox txtValue = (TextBox)sender;

        if (txtValue.Attributes["TextID"] != null)
        {
            ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            string key = txtValue.Attributes["TextID"];
            Player p = session.Load<Player>(Session[Constant.StaffUserSessionSign]);

            ServicesList.ConfigurationService.ChangeTextSetting(p, key, txtValue.Text, session);
        }
    }


}