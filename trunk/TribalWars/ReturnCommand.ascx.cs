using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class ReturnCommand : System.Web.UI.UserControl
{
    protected Return current;
    protected Village village;

    public MovingCommand Command
    {
        get { return this.current; }
        set
        {
            if (value.Type != MoveType.Return)
                throw new Exception("Hack hả ku :))");
            this.current = (Return)value;
        }
    }
    public Village CurrentVillage
    {
        get { return this.village; }
        set { this.village = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.pOwn.Visible = this.Command.To.Owner.ID == (int)Session["user"];
        if (this.pOwn.Visible)
            this.pResource.Visible = (this.current.Wood + this.current.Clay + this.current.Iron > 0);
            
    }
}
