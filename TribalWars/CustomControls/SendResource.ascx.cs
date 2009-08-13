using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using System.Data;
using System.Data.Common;

public partial class CustomControls_SendResource : System.Web.UI.UserControl
{

    private SendResource PendingCommand
    {
        get;
        set;
    }

    protected string TypePrefix(MoveType type)
    {
        switch (type)
        {
            case MoveType.SendResources:
                return "Gửi đến";
            case MoveType.Return:
                return "Quay về từ";
            default:
                return "";
        }
    }

    protected int MerchantCalculation(MovingCommand command)
    {
        if (command.GetType() == typeof(Return))
            return ((Return)command).Merchant;

        SendResource sendResource = (SendResource)command;

        return (sendResource.Wood + sendResource.Clay + sendResource.Iron) / 1000 + ((sendResource.Wood + sendResource.Clay + sendResource.Iron) % 1000 > 0 ? 1 : 0);
    }

    protected string DisplayResources(MovingCommand command)
    {
        if (command.GetType() != typeof(SendResource))
            return "";

        SendResource sendResource = (SendResource)command;

        string result = "";
        if (sendResource.Wood>0)
            result += String.Format("<img src=\"images\\holz.png\" /> {0}", sendResource.Wood);
        if (sendResource.Clay > 0)
            result += String.Format("<img src=\"images\\lehm.png\" /> {0}", sendResource.Clay);
        if (sendResource.Iron > 0)
            result += String.Format("<img src=\"images\\eisen.png\" /> {0}", sendResource.Iron);

        return result;
    }

    public NHibernate.ISession Session
    {
        get;
        set;
    }
    public beans.Village Village
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        this.Village.GetTransportData(this.Session);

        this.lblAvailableMerchant.Text = this.Village.VillageBuildingData.Merchant.ToString();

        if (this.Village.TransportFromMe.Count > 0)
        {
            this.rMyTransport.DataSource = this.Village.TransportFromMe;
            this.rMyTransport.DataBind();
        }
        if (this.Village.TransportToMe.Count > 0)
        {
            this.rOutgoings.DataSource = this.Village.TransportToMe;
            this.rOutgoings.DataBind();
        }
        

        if (Request["target"] == null)
            return;

        int village_id = 0;
        int.TryParse(Request["target"], out village_id);
        if (village_id == 0)
            return;

        beans.Village target = this.Session.Get<Village>(village_id);
        if (target != null)
        {
            this.txtX.Text = target.X.ToString("000");
            this.txtY.Text = target.Y.ToString("000");
        }

    }

    protected void bttnSend_Click(object sender, EventArgs e)
    {
        int clay = 0, wood = 0, iron = 0, x = 0, y = 0;

        int.TryParse(this.txtClay.Text, out clay);
        int.TryParse(this.txtWood.Text, out wood);
        int.TryParse(this.txtIron.Text, out iron);

        if (!(int.TryParse(this.txtX.Text, out x) && int.TryParse(this.txtY.Text, out y)))
        {
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox('Nhập toạ độ thành phố');", true);
            return;
        }

        try
        {
            this.PendingCommand = this.Village.CreateSendResource(this.Session, x, y, wood, clay, iron);
            this.targetPlayerID.Text = PendingCommand.ToVillage.Player.ID.ToString();
            this.targetPlayerName.Text = PendingCommand.ToVillage.Player.Username;
            this.targetVillageID.Text = PendingCommand.ToVillage.ID.ToString();
            this.targetVillageName.Text = String.Format("{0} ({1}|{2})", PendingCommand.ToVillage.Name, PendingCommand.ToVillage.X.ToString("000"), PendingCommand.ToVillage.Y.ToString("000"));
            if (wood > 0)
                this.woodSpan.Text = string.Format("<img src=\"images/resources/wood.png\"> {0}", wood);
            if (clay > 0)
                this.claySpan.Text = string.Format("<img src=\"images/resources/clay.png\"> {0}", clay);
            if (iron > 0)
                this.ironSpan.Text = string.Format("<img src=\"images/resources/iron.png\"> {0}", iron);
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "Confirm", "$.facebox($('#confirmDialog').html());", true);
        }
        catch (Exception exception)
        {
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox('" + exception.Message + "');", true);
        }
    }
    
    protected void bttnConfirmSend_Click(object sender, EventArgs e)
    {
        int clay = 0, wood = 0, iron = 0, x = 0, y = 0;

        int.TryParse(this.txtClay.Text, out clay);
        int.TryParse(this.txtWood.Text, out wood);
        int.TryParse(this.txtIron.Text, out iron);

        if (!(int.TryParse(this.txtX.Text, out x) && int.TryParse(this.txtY.Text, out y)))
        {
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox.close", true);
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox('Nhập tài nguyên');", true);
            return;
        }

        try
        {
            this.PendingCommand = this.Village.CreateSendResource(this.Session, x, y, wood, clay, iron);
            this.PendingCommand.Save(this.Session);
            this.lblAvailableMerchant.Text = this.Village.VillageBuildingData.Merchant.ToString();

            int pos = 0;
            int max = this.Village.TransportFromMe.Count;
            for (int i = 0; i < max; i++)
                if (this.Village.TransportFromMe[i].LandingTime > this.PendingCommand.LandingTime)
                {
                    pos = i;
                    break;
                }
            this.Village.TransportFromMe.Insert(pos, this.PendingCommand);
            
            this.rMyTransport.DataSource = this.Village.TransportFromMe;
            this.rMyTransport.DataBind();
        }
        catch (Exception exception)
        {
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox.close", true);
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox('" + exception.Message + "');", true);
        }
    }

}
