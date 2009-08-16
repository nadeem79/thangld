using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib1280
{
    public class Constant
    {
        public static string LoginUrl
        {
            get { return "http://login.1280.com/Login.aspx"; }
        }
        public static string RegisterUrl
        {
            get { return "http://login.1280.com/Register.aspx"; }
        }
        public static string MainUrl
        {
            get { return "http://1280.com"; }
        }
        public static string ShoppingUrl
        {
            get { return "http://muaban.1280.com"; }
        }
        public static string CaptchaUrl
        {
            get { return "http://login.1280.com/CaptCha.aspx"; }
        }
        public static string ASPSessionIdName
        {
            get { return "ASP.NET_SessionId"; }
        }
        public static string ShoppingFormUrl
        {
            get { return "http://muaban.1280.com/Shopping/Sell/"; }
        }
        public static string ShoppingPostbackUrl
        {
            get { return "http://muaban.1280.com/Shopping/Sell/Default.aspx"; }
        }
        public static string ShoppingUploadUrl
        {
            get { return "http://muaban.1280.com/Shopping/Sell/ProcessUpload.aspx?type=1"; }
        }

    }
}
