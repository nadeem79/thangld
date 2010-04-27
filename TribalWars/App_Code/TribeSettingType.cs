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
public enum TribePageType
{
    ProfilePage = 0,
    MembersPage = 1,
    DiplomacyPage = 2,
    ForumPage = 3
}

public class TribePageTypeFactory
{
    public static TribePageType GetTribePage(int type)
    {
        switch (type)
        {
            case 1:
                return TribePageType.MembersPage;
            case 2:
                return TribePageType.DiplomacyPage;
            case 3:
                return TribePageType.ForumPage;
            default:
                return TribePageType.ProfilePage;
        }
    }
}
