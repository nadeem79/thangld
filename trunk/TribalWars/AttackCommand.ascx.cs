using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using beans;

public partial class AttackCommand : System.Web.UI.UserControl
{
    protected Attack current;
    protected Village village;

    public MovingCommand Command
    {
        get { return this.current; }
        set 
        {
            if (value.Type != MoveType.Attack)
                throw new Exception("Hack hả ku :))");
            this.current = (Attack)value; 
        }
    }
    public Village CurrentVillage
    {
        get { return this.village; }
        set { this.village = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.pOwn.Visible = this.Command.From.Owner.ID == (int)Session["user"];
    }
}