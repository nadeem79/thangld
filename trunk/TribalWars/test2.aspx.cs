using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class test2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int merchant = 100;
        for (int i = 1; i <= 20; i++)
            merchant += (int)(merchant * 0.2);

        //int result = (int)Math.Round(merchant, MidpointRounding.ToEven);

        this.Label1.Text = merchant.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        
    }
}
