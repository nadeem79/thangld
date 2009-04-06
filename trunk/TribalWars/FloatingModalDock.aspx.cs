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
    protected void btn1_Click(object sender, EventArgs e)
    {
        btn1.Text = abx.Text;
        ScriptManager.RegisterStartupScript(btn1, btn1.GetType(), "ShowAttack", "showDock();", true);
        ScriptManager.RegisterStartupScript(btn1, btn1.GetType(), "111", "alert('ggg');", true);
        
    }
    protected void bttnTest_Click(object sender, EventArgs e)
    {
        this.bttnTest.Text = this.txtTest.Text;
    }
    protected void gaga_Click(object sender, EventArgs e)
    {
        
    }
}
