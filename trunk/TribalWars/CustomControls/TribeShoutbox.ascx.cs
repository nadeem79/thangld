﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using beans;

public partial class CustomControls_TribeShoutbox : System.Web.UI.UserControl
{

    public Group Group
    {
        get;
        set;
    }

    public int Size
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Shoutbox1.Group = this.Group;
        this.Shoutbox1.Size = this.Size;
    }
}
