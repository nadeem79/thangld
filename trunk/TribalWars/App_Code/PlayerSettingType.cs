using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for PlayerSettingType
/// </summary>
public enum PlayerSettingType
{
    Profile = 0,
    Email = 1,
    ChangePassword = 2,
    LoginLog = 3
}

public class PlayerSettingFactory
{
    public static PlayerSettingType GetPlayerSettingType(int type)
    {
        switch (type)
        {
            case 1:
                return PlayerSettingType.Email;
            case 2:
                return PlayerSettingType.ChangePassword;
            case 3:
                return PlayerSettingType.LoginLog;
            default:
                return PlayerSettingType.Profile;
        }
    }
}
