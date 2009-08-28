using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;

public partial class dialogs_agreement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblAgreement.Text = beans.Configuration.TribalWarsConfiguration.GetStringConfigurationItem("AgreementTerm").Value;
    }
}
