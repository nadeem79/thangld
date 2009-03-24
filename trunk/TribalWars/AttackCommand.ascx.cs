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
using beans;

public partial class AttackCommand : System.Web.UI.UserControl
{
    protected MovingCommand command;
    protected Village village;

    public MovingCommand Command
    {
        get { return this.command; }
        set { this.command = value; }
    }
    public Village CurrentVillage
    {
        get { return this.village; }
        set { this.village = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
