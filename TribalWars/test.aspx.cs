using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using NHibernate;
using beans;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Group g1 = new Group();
        g1.Tag = "abc";
        g1.Name = "Nhóm 1";
        Group g2 = new Group();
        g2.Tag = "g2";
        g2.Name = "Nhóm 1";
        Group g3 = new Group();
        g3.Tag = "g3";
        g3.Name = "Nhóm 3";
        Group g4 = new Group();
        g4.Tag = "g4";
        g4.Name = "Nhóm 4";
        Group g5 = new Group();
        g5.Tag = "g5";
        g5.Name = "Nhóm5";
        Group g6 = new Group();
        g6.Tag = "g6";
        g6.Name = "Nhóm 6";

        g1.Allies.Add(g2);
        g1.Allies.Add(g3);
        g1.Allies.Add(g4);
        g1.Naps.Add(g5);
        g1.Enemies.Add(g6);


        ISession session = NHibernateHelper.CreateSession();
        session.Save(g1);
        session.Save(g2);
        session.Save(g3);
        session.Save(g4);
        session.Save(g5);
        session.Save(g6);
        session.Close();


    }
}
