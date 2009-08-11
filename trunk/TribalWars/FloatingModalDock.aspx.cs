using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class FloatingModalDock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //this.Label1.Text = this.txt.Text;
        //RadScriptManager.RegisterStartupScript(Button1, Button1.GetType(), "DisplayAttack", "window.radopen('http://www.google.com', 'RadWindow1');", true);
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.Label1.Text = this.TextBox1.Text;
        RadScriptManager.RegisterStartupScript(Button1, Button1.GetType(), "DisplayAttack", string.Format("$.facebox($('#abc').html());"), true);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Label2.Text += this.TextBox1.Text;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        this.Label2.Text += this.TextBox1.Text;
    }
}