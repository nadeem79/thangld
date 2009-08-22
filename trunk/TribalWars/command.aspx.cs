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

public partial class command : System.Web.UI.Page
{
    protected beans.Village village;
    protected MovingCommand current = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        village = ((inPage)(this.Master)).CurrentVillage;

        int command_id = 0;
        int.TryParse(Request["command"], out command_id);
        if (command_id == 0)
        {
            this.pCommandNotFound.Visible = true;
            this.pCommandFound.Visible = false;
            return;
        }

        ISession session = (ISession)Context.Items["NHibernateSession"];
        Player player = session.Load<Player>(Session["user"]);
        current = player.GetCommand(command_id, session);

        if (current == null)
        {
            this.pCommandFound.Visible = false;
            this.pCommandNotFound.Visible = true;
            return;
        }

        this.pCommandFound.Visible = true;
        this.pCommandNotFound.Visible = false;
        switch (current.Type)
        {
            case MoveType.Attack:

                AttackCommand attackCommand = (AttackCommand)Page.LoadControl("AttackCommand.ascx");
                attackCommand.Command = current;
                attackCommand.CurrentVillage = village;
                this.pCommand.Controls.Add(attackCommand);
                break;
            case MoveType.Support:
                SupportCommand supportCommand = (SupportCommand)Page.LoadControl("SupportCommand.ascx");
                supportCommand.Command = current;
                supportCommand.CurrentVillage = village;
                this.pCommand.Controls.Add(supportCommand);
                break;
            case MoveType.Return:
                ReturnCommand returnCommand = (ReturnCommand)Page.LoadControl("ReturnCommand.ascx");
                returnCommand.Command = current;
                returnCommand.CurrentVillage = village;
                this.pCommand.Controls.Add(returnCommand);
                break;
            default:
                throw new Exception("Hack hả ku :))");
        }

        //SqlCommand cmdGetCommandInfo = conn.CreateCommand();
        //cmdGetCommandInfo.CommandText = "select m.*, v1.id as id1, v1.x as x1, v1.y as y1, v1.name as name1, v1.userid as userid1, v2.id as id2, v2.x as x2, v2.y as y2, v2.name as name2, v2.userid as userid2 from movement m inner join villages v1 on (v1.id=m.[from]) inner join villages v2 on (v2.id=m.[to]) where m.landing_time>getdate() and (m.[from]=@village_id1 or m.[to]=@village_id2) and m.id=@id";
        //cmdGetCommandInfo.Parameters.Add("@village_id1", SqlDbType.Int).Value = id;
        //cmdGetCommandInfo.Parameters.Add("@village_id2", SqlDbType.Int).Value = id;
        //cmdGetCommandInfo.Parameters.Add("@id", SqlDbType.Int).Value = current;

        //SqlDataAdapter daCommand = new SqlDataAdapter(cmdGetCommandInfo);
        //DataTable tb = new DataTable();
        //daCommand.Fill(tb);

        //if (tb.Rows.Count == 0)
        //{
        //    Response.Write("Lệnh không tồn tại");
        //    return;
        //}

        //string sTroop = "";
        //if (((string)row["userid1"] == (string)Session["username"]) || ((int)row["type"] == 4))
        //{
        //    sTroop =  "<table><tbody><tr><th width='50'><img src='images/unit_spear.png' title='Spear fighter' alt=''></th><th width='50'><img src='images/unit_sword.png' title='Swordsman' alt=''></th><th width='50'><img src='images/unit_axe.png' title='Axeman' alt=''></th><th width='50'><img src='images/unit_spy.png' title='Scout' alt=''></th><th width='50'><img src='images/unit_light.png' title='Light cavalry' alt=''></th><th width='50'><img src='images/unit_heavy.png' title='Heavy cavalry' alt=''></th><th width='50'><img src='images/unit_ram.png' title='Ram' alt=''></th><th width='50'><img src='images/unit_catapult.png' title='Catapult' alt=''></th><th width='50'><img src='images/unit_snob.png' title='Nobleman' alt=''></th></tr>";
        //    sTroop += "<tr><td>" + row["spear"] + "</td><td>" + row["sword"] + "</td><td>" + row["axe"] + "</td><td>" + row["scout"] + "</td><td>" + row["light"] + "</td><td>" + row["heavy"] + "</td><td>" + row["ram"] + "</td><td>" + row["catapult"] + "</td><td>" + row["noble"] + "</td></tr></tbody></table>";
        //}

        //string sResources = "";

        //if ((int)row["type"] == 4)
        //{
        //    sResources = "<table><tbody><tr><th width='50'><img src='images/lehm.png' title='Đá' alt=''></th><th width='50'><img src='images/holz.png' title='Gỗ' alt=''></th><th width='50'><img src='images/eisen.png' title='Kim loại' alt=''></th>";
        //    sResources += "<tr><td>" + row["clay"] + "</td><td>" + row["wood"] + "</td><td>" + row["iron"] + "</td></tr></table>";
        //}

        //this.lblResources.Text = sResources;
        //this.lblTroop.Text = sTroop;
    }
}
