﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class agreement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblAgreement.Text = beans.Configuration.TribalWarsConfiguration.GetStringConfigurationItem("AgreementTerm").Value;
    }
}
