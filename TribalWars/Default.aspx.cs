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

using System.Data.SqlClient;
using NHibernate;
using beans;
using NHibernate.Criterion;
using System.Collections.Generic;

public partial class index : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        //Village v = session.Get<Village>(24);
        if (Request.Cookies["username"] != null)
        {
            
            
            try
            {
                int id = beans.Player.Authentication(Request.Cookies["username"].Value, (string)Request.Cookies["password"].Value, session);
                if (id < 0)
                {
                    Request.Cookies.Clear();
                    Session.Remove("user");
                }
                else
                {
                    Session[Constant.NHibernateSessionSign] = id;
                    //Session.Add(Constant.NHibernateSessionSign, id);
                }
            }
            catch (Exception exc)
            {
            }
        }
        Response.Write("gggggggg" + Session[Constant.NHibernateSessionSign]);
        switch (Session[Constant.NHibernateSessionSign]==null)
        {
            case true:
                LoginBox login = (LoginBox)Page.LoadControl("LoginBox.ascx");
                this.pBox.Controls.Add(login);
                break;
            default:
                /*PlayerBox player = (PlayerBox)Page.LoadControl("PlayerBox.ascx");
                player.Player = session.Get<Player>(Session[Constant.NHibernateSessionSign]);
                this.pBox.Controls.Add(player);*/
                break;
        }
        //Response.Write(Session[Constant.NHibernateSessionSign]);
        
    }
}
