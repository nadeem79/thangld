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
                return "Gửi từ";
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

        if (command.FromVillage.Player.ID != (int)Session["user"])
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

    public beans.Village Village
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];
        this.Village.VillageTransportMethods.GetTransportData(session);

        this.lblAvailableMerchant.Text = this.Village.VillageBuildingData.Merchant.ToString();



        if (this.Village.VillageTransportMethods.TransportFromMe.Count > 0)
        {
            this.rOutgoings.DataSource = this.Village.VillageTransportMethods.TransportFromMe;
            this.rOutgoings.DataBind();
        }
        if (this.Village.VillageTransportMethods.TransportToMe.Count > 0)
        {

            this.rMyTransport.DataSource = this.Village.VillageTransportMethods.TransportToMe;
            this.rMyTransport.DataBind();
        }
        

        if (Request["target"] == null)
            return;

        int village_id = 0;
        int.TryParse(Request["target"], out village_id);
        if (village_id == 0)
            return;

        beans.Village target = session.Get<Village>(village_id);
        if (target != null)
        {
            this.txtX.Text = target.X.ToString("000");
            this.txtY.Text = target.Y.ToString("000");
        }

    }

    protected void bttnSend_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];
        int clay = 0, wood = 0, iron = 0, x = 0, y = 0;

        int.TryParse(this.txtClay.Text, out clay);
        int.TryParse(this.txtWood.Text, out wood);
        int.TryParse(this.txtIron.Text, out iron);
        this.woodSpan.Text = "";
        this.claySpan.Text = "";
        this.ironSpan.Text = "";
        if (!(int.TryParse(this.txtX.Text, out x) && int.TryParse(this.txtY.Text, out y)))
        {
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox('Nhập toạ độ thành phố');", true);
            return;
        }

        try
        {
            this.PendingCommand = this.Village.VillageResourceMethods.CreateSendResource(session, x, y, clay, wood, iron);
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

            this.merchantRequiredSpan.Text = this.PendingCommand.Merchant.ToString();
            this.durationSpan.Text = Functions.FormatTime(this.PendingCommand.LandingTime - this.PendingCommand.StartingTime);
            this.arrivalSpan.Text = this.PendingCommand.LandingTime.ToString("HH:mm:ss:'<span class=\"small hidden\">'fff'</span> ngày 'dd/MM");
            this.returnSpan.Text = (this.PendingCommand.LandingTime + (this.PendingCommand.LandingTime - this.PendingCommand.StartingTime)).ToString("HH:mm:ss:'<span class=\"small hidden\">'fff'</span> ngày 'dd/MM");
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "Confirm", "$.facebox($('#confirmDialog').html());", true);
        }
        catch (Exception exception)
        {
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox('" + exception.Message + "');", true);
        }
    }
    
    protected void bttnConfirmSend_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];
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
            this.PendingCommand = this.Village.VillageResourceMethods.CreateSendResource(session, x, y, clay, wood, iron);
            this.PendingCommand.Save(session);
            this.lblAvailableMerchant.Text = this.Village.VillageBuildingData.Merchant.ToString();

            int pos = 0;
            int max = this.Village.VillageTransportMethods.TransportFromMe.Count;
            for (int i = 0; i < max; i++)
                if (this.Village.VillageTransportMethods.TransportFromMe[i].LandingTime > this.PendingCommand.LandingTime)
                {
                    pos = i;
                    break;
                }
            this.Village.VillageTransportMethods.TransportFromMe.Insert(pos, this.PendingCommand);

            this.rMyTransport.DataSource = this.Village.VillageTransportMethods.TransportFromMe;
            this.rMyTransport.DataBind();
            this.txtClay.Text = "";
            this.txtWood.Text = "";
            this.txtIron.Text = "";

            
            
        }
        catch (Exception exception)
        {
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox.close", true);
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "$.facebox('" + exception.Message + "');", true);
        }
    }

}
