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

    protected string TypePrefix(MoveType type)
    {
        switch (type)
        {
            case MoveType.SendResources:
                return "Gửi đến";
                break;
            case MoveType.Return:
                return "Quay về từ";
                break;
            default:
                return "";
                break;
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
        this.lblAvailableMerchant.Text = this.Village.MerchantAvailable(this.Session).ToString();
        IList<MovingCommand> lstIncoming = this.Village.IncomingMerchants(this.Session);
        this.rMyTransport.DataSource = lstIncoming;
        this.rMyTransport.DataBind();
        this.rOutgoings.DataSource = this.Village.GetOutgoingMerchants(this.Session);
        this.rOutgoings.DataBind();

        

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
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "jQuery.facebox('Nhập toạ độ thành phố');", true);
            return;
        }

        ITransaction transaction = null;
        try
        {
            transaction = this.Session.BeginTransaction(IsolationLevel.ReadCommitted);
            SendResource sendResource = SendResource.PrepareSendingResources(this.Session, this.Village, x, y, wood, clay, iron);
            transaction.Commit();
            Response.Redirect(String.Format("market.aspx?id={0}", this.Village.ID), false);
        }
        catch (Exception exception)
        {
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "jQuery.facebox('" + exception.Message + "');", true);
            transaction.Rollback();
        }
         

        
    }
}
