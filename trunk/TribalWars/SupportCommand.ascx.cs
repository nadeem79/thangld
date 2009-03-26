using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class SupportCommand : System.Web.UI.UserControl
{
    protected Attack current;
    protected Village village;

    public MovingCommand Command
    {
        get { return this.current; }
        set
        {
            if (value.Type != MoveType.Support)
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
