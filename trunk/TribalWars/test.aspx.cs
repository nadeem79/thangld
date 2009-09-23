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

using NHibernate;
using NHibernate.Linq;
using beans;
using Telerik.Web.UI;
using System.Collections.Generic;
using Iesi.Collections;
using System.Collections.Specialized;

public partial class test : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        ListDictionary l = new ListDictionary();
        l["aha"] = "haehaeshets";
        this.Label1.Text = l["aha"].ToString();
        return;
        double time = 1000;
        this.Label1.Text = "";
        Random r = new Random();
        for (int i = 1; i < 100; i++)
        {
            //Price p = Build.GetPrice(BuildingType.Wall, i, 1);
            //time += p.BuildTime;
            //this.Label1.Text += string.Format("{0}: {1}<br />", i, time);
            //time += time * 0.2;
            this.Label1.Text += r.Next(2).ToString() + "<br />";
        }
        //this.Label1.Text = time.ToString();
    }

    protected void bttnSend_Click(object sender, EventArgs e)
    {
        
    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
}
