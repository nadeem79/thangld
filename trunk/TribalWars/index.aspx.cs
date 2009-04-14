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

        ISession session2 = NHibernateHelper.CreateSession();
        //Attack a = session2.Load<Attack>(368);
        //this.Label1.Text = a.StartTimestamp.ToString() + " - " + DatetimeHelper.DatetimeToInt64(DateTime.Now).ToString();
        session2.Close();


        if (Request.Cookies["username"] != null)
        {
            ISession session = NHibernateHelper.CreateSession();
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
                    Session.Add("user", id);
                }
            }
            catch (Exception exc)
            {
            }
            finally
            {
                session.Close();
            }
        }

        switch (Session["user"]==null)
        {
            case true:
                LoginBox login = (LoginBox)Page.LoadControl("LoginBox.ascx");
                this.pBox.Controls.Add(login);
                break;
            default:
                PlayerBox player = (PlayerBox)Page.LoadControl("PlayerBox.ascx");
                this.pBox.Controls.Add(player);
                break;
        }
        
    }
}
