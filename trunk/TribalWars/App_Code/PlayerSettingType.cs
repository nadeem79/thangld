using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for PlayerSettingType
/// </summary>
public enum PlayerSettingType
{
    Profile = 1,
    Email = 2,
    LoginLog = 3,
    ChangePassword = 4
}

public class PlayerSettingFactory
{
    public static PlayerSettingType GetPlayerSettingType(int type)
    {
        switch (type)
        {
            case 2:
                return PlayerSettingType.Email;
            case 3:
                return PlayerSettingType.LoginLog;
            case 4:
                return PlayerSettingType.ChangePassword;
            default:
                return PlayerSettingType.Profile;
        }
    }
}
