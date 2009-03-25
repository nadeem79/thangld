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
using System.IO;
using System.Drawing;

public partial class user_profile : System.Web.UI.Page
{

    protected Village village = null;
    protected Player player;

    protected void Page_Load(object sender, EventArgs e)
    {
        inPage p = (inPage)this.Master;
        village = p.CurrentVillage;
        
        int iType = 0;
        int.TryParse(Request["type"], out iType);

        PlayerSettingType type = PlayerSettingFactory.GetPlayerSettingType(iType);

        this.tbProfileType.Rows[(int)type].Cells[0].Attributes.Add("class", "selected");
        
        switch (type)
        {
            case PlayerSettingType.Email:
                ChangeEmailAddress ucChangeEmailAddress = (ChangeEmailAddress)Page.LoadControl("ChangeEmailAddress.ascx");
                this.pProfile.Controls.Add(ucChangeEmailAddress);
                return;
                break;
            case PlayerSettingType.ChangePassword:
                ChangePassword ucChangePassword = (ChangePassword)Page.LoadControl("ChangePassword.ascx");
                this.pProfile.Controls.Add(ucChangePassword);
                return;
                break;
            default:
                UserProfile ucUserProfile = (UserProfile)Page.LoadControl("UserProfile.ascx");
                this.pProfile.Controls.Add(ucUserProfile);
                return;
                break;
        }

    }
}
