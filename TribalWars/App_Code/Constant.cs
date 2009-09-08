using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Constant
/// </summary>
public class Constant
{

    public static string NHibernateSessionSign
    {
        get { return "NHibernateSession"; }
    }
    public static string NormalUserSessionSign
    {
        get { return "user"; }
    }
    public static string StaffUserSessionSign
    {
        get { return "staffID"; }
    }
    public static string UserLoginCount
    {
        get { return "UserCount"; }
    }

    public static string DebugMode
    {
        get { return "DebugMode"; }
    }
    public static string Username
    {
        get { return "Username"; }
    }

    protected Constant()
    {
        
    }
}
