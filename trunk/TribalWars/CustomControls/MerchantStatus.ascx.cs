using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomControls_MerchantStatus : System.Web.UI.UserControl
{
    protected NHibernate.ISession Session
    {
        get;
        set;
    }
    protected beans.Village Village
    {
        get;
        set;
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
