using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;

public partial class HeroDetails : System.Web.UI.UserControl
{
    public beans.Village Village
    {
        get;
        set;
    }
    protected beans.Hero Hero
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession sessiob
    }
}
