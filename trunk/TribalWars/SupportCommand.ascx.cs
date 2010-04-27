using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class SupportCommand : System.Web.UI.UserControl
{
    protected Support current;
    protected Village village;

    public MovingCommand Command
    {
        get { return this.current; }
        set
        {
            if (value.Type != MoveType.Support)
                throw new Exception("Hack hả ku :))");
            this.current = (Support)value;
        }
    }
    public Village CurrentVillage
    {
        get { return this.village; }
        set { this.village = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.pOwn.Visible = this.Command.FromVillage.Player.ID == (int)Session["user"];
    }
}
