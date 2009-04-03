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
using NHibernate;
using System.Collections.Generic;
using Telerik.Web.UI;

public partial class Shoutbox : System.Web.UI.UserControl
{
    protected DateTime dtLastSend;
    protected Group _group = null;
    public Group Group
    {
        get { return this._group; }
        set { this._group = value; }
    }
    public DateTime LastUpdate
    {
        get { return this.dtLastSend; }
        set { this.dtLastSend = value; }
    }
    

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ISession session = NHibernateHelper.CreateSession();
            string strData = "";
            List<ShoutboxData> lst = (List<ShoutboxData>)ShoutboxData.GetShoutbox(null, 15, false, session);
            lst.Reverse();
            foreach (ShoutboxData data in lst)
            {
                strData += "<div><img src='images/chat_icon.gif'> [" + data.Time.ToString("hh:mm") + "] ";
                if (Session["user"] == null)
                    strData += "<span class='username'>" + data.Player.Username + "</span>: ";
                else
                    strData += "<span class='username'><a href='user_info.aspx?player=" + data.Player.ID.ToString() + "' title='" + data.Player.Username + "'>" + data.Player.Username + "</a></span>: ";
                
                strData += data.Text;
                strData += "</div>";
            }
            session.Close();
            this.lblShoutboxData.Text = strData;
            this.pForm.Visible = (Session["user"] != null);
        }
        catch (Exception ex)
        {
            this.error.Text = ex.Message;
        }
    }
    protected void bttnShout_Click(object sender, EventArgs e)
    {

        if (Session["user"] == null)
            return;
        ScriptManager.RegisterStartupScript(bttnShout, bttnShout.GetType(), "EmptyText", "alert('Text trắng');", true);
        double i = (DateTime.Now - this.LastUpdate).TotalSeconds;
        
        this.error.Text = i.ToString() + " - " + DateTime.Now.ToString() + " - " + this.LastUpdate.ToString();
        if ((DateTime.Now - this.LastUpdate).TotalSeconds < 5)
        {
            return;
        }
        if (this.txtShoutboxInput.Text.Trim().Equals(string.Empty))
        {
            System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>");
            System.Web.HttpContext.Current.Response.Write("alert('Text trắng');");
            System.Web.HttpContext.Current.Response.Write("</SCRIPT>");
            return;
        }
        try
        {
            this.LastUpdate = DateTime.Now;
            ISession session = NHibernateHelper.CreateSession();
            
            Player player = session.Get<Player>(Session["user"]);
            ShoutboxData data = new ShoutboxData();
            data.Text = this.txtShoutboxInput.Text;
            data.Time = DateTime.Now;
            data.Group = this.Group;
            data.Player = player;
            session.Save(data);
            session.Close();
            string strData = "<div><img src='images/chat_icon.gif'> [" + data.Time.ToString("hh:mm") + "] ";
            strData += "<span class='username'><a href='user_info.aspx?player=" + data.Player.ID.ToString() + "' title='" + data.Player.Username + "'>" + data.Player.Username + "</a></span>: ";
            strData += data.Text;
            strData += "</div>";
            this.lblShoutboxData.Text += strData;
            this.txtShoutboxInput.Text = "";
            
        }
        catch (Exception ex)
        {
            this.error.Text = ex.Message;
        }
        finally
        {
            
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            this.txtShoutboxInput.AutoCompleteType = AutoCompleteType.None;
            ISession session = NHibernateHelper.CreateSession();
            string strData = "";
            foreach (ShoutboxData data in ShoutboxData.GetShoutbox(null, 15, false, session))
            {
                strData += "<div><img src='images/chat_icon.gif'> [" + data.Time.ToString("hh:mm") + "] ";
                if (Session["user"] == null)
                    strData += "<span class='username'>" + data.Player.Username + "</span>: ";
                else
                    strData += "<span class='username'><a href='user_info.aspx?player=" + data.Player.ID.ToString() + "' title='" + data.Player.Username + "'>" + data.Player.Username + "</a></span>: ";
                strData += data.Text;
                strData += "</div>";
            }
            session.Close();
            this.lblShoutboxData.Text = strData;
        }
        catch (Exception ex)
        {
            this.error.Text = ex.Message;
        }
    }
    protected void Timer1_Tick1(object sender, EventArgs e)
    {

    }
}
