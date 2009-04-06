using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using beans;
using System.Data;
using Telerik.Web.UI;

public partial class dialogs_attack_confirm : System.Web.UI.Page
{

    protected Attack command;

    protected void Page_Load(object sender, EventArgs e)
    {
        int command_id = 0;
        int village_id = 0;

        int.TryParse(Request["id"], out village_id);
        if (!int.TryParse(Request["command"], out command_id))
        {
            this.pNotFound.Visible = true;
            this.pFound.Visible = false;
            return;
        }
        ISession session = null;
        try
        {
            session = NHibernateHelper.CreateSession(); ;
            Player player = session.Get<Player>(Session["user"]);
            this.command = (Attack)session.Get<MovingCommand>(command_id);

            
            this.pFound.Visible = true;
            this.pNotFound.Visible = false;
            DateTime landing = DateTime.Now + (command.LandingTime - command.StartTime);
            this.lblLandingTime.Text = landing.ToString("dd/MM/yyyy hh:mm:ss") + ":<span class='small hidden'>" + landing.Millisecond.ToString("000") + "</span>";
        }
        catch (Exception ex)
        {
            this.pNotFound.Visible = true;
            this.pFound.Visible = false;
            this.lblError.Text = ex.Message + "<br />" + ex.StackTrace; ;
            return;
        }
        finally
        {
            if (session != null)
                session.Close();
        }
            


    }
    protected void bttnSendAttack_Click(object sender, EventArgs e)
    {
        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = NHibernateHelper.CreateSession();
            trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
            command.execute(session);
            trans.Commit();
            RadScriptManager.RegisterStartupScript(bttnSendAttack, bttnSendAttack.GetType(), "SendAttack", "CloseAndRefresh();", true);
        }
        catch
        {
            if (trans != null && !trans.WasCommitted)
                trans.Rollback();
        }
        finally
        {
            if (session != null)
                session.Close();
        }
        
    }

    protected void bttnCancelAttack_Click(object sender, EventArgs e)
    {
        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = NHibernateHelper.CreateSession();
            
            trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
            session.Delete(command);
            trans.Commit();
            RadScriptManager.RegisterStartupScript(bttnCancelAttack, bttnCancelAttack.GetType(), "CancelAttack", "Close();", true);
        }
        catch
        {
            if (trans != null && !trans.WasCommitted)
                trans.Rollback();
        }
        finally
        {
            if (session != null)
                session.Close();
        }
    }
}
