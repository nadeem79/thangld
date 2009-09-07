using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using beans;
using Telerik.Web.UI;
using System.Xml.Linq;
using System.Xml;

public partial class administrator_text_settings : System.Web.UI.Page
{

    protected Player CurrentPlayer
    {
        get;
        set;
    }

    public Pager Pager
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RadTreeNode parentNode = ((administrator_administrator)this.Master).Menu.FindNodeByValue(beans.JobEnum.TextSettings.ToString());
        parentNode.Expanded = true;
        RadTreeNode childNode = parentNode.Nodes.FindNodeByValue("list");

        if (childNode != null)
            childNode.ImageUrl = "images/map_e.png";
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        this.CurrentPlayer = session.Load<Player>(Session[Constant.StaffUserSessionSign]);
        int page = 0;


        if (IsPostBack)
            return;

        if (Request["p"] != null)
            int.TryParse(Request["p"], out page);

        int count = 0;
        int pageSize = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Admin.config_paging").Value;
        IList<StringConfiguration> stringConfigurations = ServicesList.ConfigurationService.GetTextSettings(this.CurrentPlayer, page, pageSize, out count, session);

        this.Pager = new Pager(count, page);
        this.lblPaging.Text = this.Pager.GetInfo(Request.Url.AbsolutePath).ToString();

        this.stringConfigurationRepeater.DataSource = stringConfigurations;
        this.stringConfigurationRepeater.DataBind();
        

    }
    protected void deleteSettingButton_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        for (int cnt = 0; cnt < stringConfigurationRepeater.Items.Count; cnt++)
        {
            // your checkbox ; type casting
            CheckBox cbId = ((CheckBox)stringConfigurationRepeater.Items[cnt].FindControl("checkDeleteCheckBox"));

            // user id
            string id = cbId.Attributes["Value"];
            // or the other option; value from hidden field

            if (cbId.Checked)
            {
                ServicesList.ConfigurationService.DeleteTextSetting(this.CurrentPlayer, id, session);
                //this.CurrentPlayer.AdminConfigurationMethods.DeleteTextSetting(id, session);
                Response.Redirect(Request.Url.ToString(), false);
            }
        }
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


    protected void bttnSearchText_Click(object sender, EventArgs e)
    {
        this.lblPaging.Text = "";
        int count = 0;
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        //IList<StringConfiguration> stringConfigurations = ServicesList.ConfigurationService.GetTextSettings(this.CurrentPlayer, 0, 0, this.txtKey.Text, this.rdoSearchByKey.Checked, out count, session);
        IList<StringConfiguration> stringConfigurations = ServicesList.ConfigurationService.GetTextSettings(this.CurrentPlayer, 0, 0, this.txtKey.Text, !this.chkSearchByValue.Checked, out count, session);
        this.stringConfigurationRepeater.DataSource = stringConfigurations;
        this.stringConfigurationRepeater.DataBind();
    }

    protected void bttnExport_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];

        Response.AddHeader("Content-disposition", "attachment; filename=text_settings.xml");
        Response.ContentType = "text/xml";
        int count = 0;


        IList<StringConfiguration> textConfigurations = ServicesList.ConfigurationService.GetTextSettings(this.CurrentPlayer, out count, session);
        XDocument doc = new XDocument();
        doc.Add(new XDeclaration("1.0", "utf-16", "true"));
        doc.Add(new XElement("texts",
                        from c in textConfigurations
                        orderby c.Key //descending 
                        select new XElement("text",
                            new XElement("key", c.Key),
                            new XElement("value", new XCData(c.Value))
                                            )
                                    ));
        //XmlWriter

        System.Text.UnicodeEncoding encoding = new System.Text.UnicodeEncoding();
        Byte[] bytes = encoding.GetBytes(doc.ToString());
        Response.BinaryWrite(bytes);
        Response.End();
    }
    protected void bttnImport_Click(object sender, EventArgs e)
    {
        XmlReader reader = XmlReader.Create(this.FileUpload1.PostedFile.InputStream);
        XDocument xmlDoc = XDocument.Load(reader);
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];

        var texts = from t in xmlDoc.Elements("texts")
                       select t;

        foreach (var text in texts)
        {
            ServicesList.ConfigurationService.ChangeTextSetting(this.CurrentPlayer, text.Element("key").Value, text.Element("value").Value, session);
        }
    }
}
