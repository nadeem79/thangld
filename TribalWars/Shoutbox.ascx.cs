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
    protected Group _group = null;
    private int size = 15;

    public int Size
    {
        get { return this.size; }
        set 
        {
            if (value < 15)
                this.size = 15;
            else
                this.size = value; 
        }
    }

    public Group Group
    {
        get { return this._group; }
        set { this._group = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ViewState["last_send"] = DateTime.Now.AddSeconds(-10);
            ISession session = NHibernateHelper.CreateSession();
            string strData = "";
            List<ShoutboxData> lst = (List<ShoutboxData>)ShoutboxData.GetShoutbox(this.Group, 15, false, session);
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
        }
        catch (Exception ex)
        {
            this.error.Text = ex.Message;
        }
    }
    protected void bttnShout_Click(object sender, EventArgs e)
    {
        if ((DateTime.Now - (DateTime)ViewState["last_send"]).TotalSeconds < 5)
            return;
        if (Session["user"] == null)
            return;

        if (this.txtShoutboxInput.Text.Trim().Equals(string.Empty))
        {
            return;
        }

        try
        {
            ViewState["last_send"] = DateTime.Now;
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
            List<ShoutboxData> lst = (List<ShoutboxData>)ShoutboxData.GetShoutbox(this.Group, 15, false, session);
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
        }
        catch (Exception ex)
        {
            this.error.Text = ex.Message;
        }
    }

}
