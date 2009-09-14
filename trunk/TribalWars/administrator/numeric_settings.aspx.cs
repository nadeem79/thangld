using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using Telerik.Web.UI;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Data;

public partial class administrator_numeric_settings : System.Web.UI.Page
{

    protected Player CurrentPlayer
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RadTreeNode parentNode = ((administrator_administrator)this.Master).Menu.FindNodeByValue(beans.JobEnum.NumericSettings.ToString());
        parentNode.Expanded = true;
        RadTreeNode childNode = parentNode.Nodes.FindNodeByValue("list");
        if (childNode != null)
            childNode.ImageUrl = "images/map_e.png";

        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        this.CurrentPlayer = session.Load<Player>(Session[Constant.StaffUserSessionSign]);
        int page = 0;

        if (Request["key"] != null)
        {
            double value = 0;
            if (double.TryParse(Request["value"], out value))
                ServicesList.ConfigurationService.ChangeNumericSetting(this.CurrentPlayer, Request["key"], value, session);
        }

        if (IsPostBack)
            return;

        if (Request["p"] != null)
            int.TryParse(Request["p"], out page);
        int count = 0;

        IList<NumericConfiguration> numericConfigurations = ServicesList.ConfigurationService.GetNumericSettings(this.CurrentPlayer, page, out count, session);
        this.numericConfigurationRepeater.DataSource = numericConfigurations;
        this.numericConfigurationRepeater.DataBind();
        Pager pager = new Pager(count, page);
        this.lblPaging.Text = pager.GetInfo(Request.Url.AbsolutePath).ToString();
    }

    protected void deleteSettingButton_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        for (int cnt = 0; cnt < numericConfigurationRepeater.Items.Count; cnt++)
        {
            // your checkbox ; type casting
            CheckBox cbId = ((CheckBox)numericConfigurationRepeater.Items[cnt].FindControl("checkDeleteCheckBox"));

            // user id
            string id = cbId.ToolTip;
            // or the other option; value from hidden field

            if (cbId.Checked)
                ServicesList.ConfigurationService.DeleteNumericSetting(this.CurrentPlayer, id, session);
                //this.CurrentPlayer.AdminConfigurationMethods.DeleteNumericSetting(id, session);

            
        }
        Response.Redirect(Request.Url.ToString(), false);
    }

    protected void createNewSettingButton_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        double value = 0;
        double.TryParse(this.valueTextBox.Text, out value);
        ServicesList.ConfigurationService.ChangeNumericSetting(this.CurrentPlayer, this.keyTextBox.Text, value, session);
        //this.CurrentPlayer.AdminConfigurationMethods.ChangeNumericSetting(this.keyTextBox.Text, value, session);
        Response.Redirect(Request.Url.ToString(), false);
    }

    protected void bttnSearchNumeric_Click(object sender, EventArgs e)
    {
        this.lblPaging.Text = "";
        int count = 0;
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        //IList<StringConfiguration> stringConfigurations = ServicesList.ConfigurationService.GetTextSettings(this.CurrentPlayer, 0, 0, this.txtKey.Text, this.rdoSearchByKey.Checked, out count, session);
        IList<NumericConfiguration> numericConfigurations = ServicesList.ConfigurationService.GetNumericSettings(this.CurrentPlayer, 0, 0, this.txtKey.Text, out count, session);
        this.numericConfigurationRepeater.DataSource = numericConfigurations;
        this.numericConfigurationRepeater.DataBind();
    }

    protected void bttnExport_Click(object sender, EventArgs e)
    {

        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];

        Response.AddHeader("Content-disposition", "attachment; filename=numeric_settings.xml");
        Response.ContentType = "text/xml";
        int count = 0;
        //IList<NumericConfiguration> numericConfigurations = ServicesList.ConfigurationService.GetNumericSettings(this.CurrentPlayer, out count, session);

        XmlDocument document = new XmlDocument();
        
        document.AppendChild(document.CreateXmlDeclaration("1.0", "utf-8", "yes"));
        XmlNode numerics = document.AppendChild(document.CreateNode(XmlNodeType.Element, "numerics", null));

        foreach (NumericConfiguration config in Configuration.TribalWarsConfiguration.NumericConfiguration.Values)
        {
            XmlNode parentNode = numerics.AppendChild(document.CreateNode(XmlNodeType.Element, "numeric", null));
            XmlNode keyNode = parentNode.AppendChild(document.CreateNode(XmlNodeType.Element, "key", null));
            keyNode.AppendChild(document.CreateNode(XmlNodeType.Text, "key", null)).Value = config.Key;
            XmlNode valueNode = parentNode.AppendChild(document.CreateNode(XmlNodeType.Element, "value", null));
            valueNode.AppendChild(document.CreateNode(XmlNodeType.Text, "value", null)).Value = config.Value.ToString();
        }

        System.IO.TextWriter sw = new System.IO.StringWriter();
        XmlTextWriter xtw = new XmlTextWriter(sw);
        xtw.Formatting = Formatting.Indented;
        document.WriteTo(xtw);

        Response.Write(sw.ToString());
        Response.End();
        
    }

    static void ValidationCallback(object sender, ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Warning)
            Console.Write("WARNING: ");
        else if (args.Severity == XmlSeverityType.Error)
            Console.Write("ERROR: ");

        Console.WriteLine(args.Message);
    }

    protected void bttnImport_Click(object sender, EventArgs e)
    {
        XmlReader reader = XmlReader.Create(this.FileUpload1.PostedFile.InputStream, new XmlReaderSettings());
        //reader.Settings = new XmlReaderSettings();
        
        //XDocument xmlDoc = XDocument.Load(reader);
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];


        XmlDocument document = new XmlDocument();
        //document.Load(reader);

        

        DataSet vdDataSet = new DataSet();
        //string database = "vd.xml";
        //Application.StartupPath
        //string schema = Application.StartupPath + "\\vd.xsd";

        XmlTextReader schemaXML = new XmlTextReader(Server.MapPath("~/administrator/numeric.xsd"));

        System.Xml.Schema.XmlSchema schema = System.Xml.Schema.XmlSchema.Read(schemaXML,ValidationCallback);
        vdDataSet.ReadXmlSchema(schemaXML);
        vdDataSet.ReadXml(reader);
        Response.Write(vdDataSet.Tables["numeric"].Rows.Count);
        foreach (DataRow dr in vdDataSet.Tables["numeric"].Rows)
        {
            double value = 0;
            double.TryParse(dr["value"].ToString(), out value);
            //Console.WriteLine(dr["MS"].ToString() + "\t" + dr["HT"].ToString() + "\t" + dr["DIEM"].ToString());
            ServicesList.ConfigurationService.ChangeNumericSetting(this.CurrentPlayer, (string)dr["key"], value, session);
        }

        //var numerics = from n in xmlDoc.Elements("numerics")
        //            select n;

        //foreach (var numeric in numerics)
        //{
        //    double value = 0;
        //    double.TryParse(numeric.Element("value").Value, out value);
        //    ServicesList.ConfigurationService.ChangeNumericSetting(this.CurrentPlayer, numeric.Element("key").Value, value, session);
        //}
    }
}
