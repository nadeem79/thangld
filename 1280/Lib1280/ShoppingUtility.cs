using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Lib1280
{
    public class ShoppingUtility
    {
        public static void test()
        {
            string tokenKey = LoginUtility.GetTokenKey("DF.thangld@gmail.com", "meocondethuong");

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constant.ShoppingUrl);

            CookieContainer cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie();
            cookie.Domain = "muaban.1280.com";
            cookie.Path = "/";
            cookie.Name = "TokenKey";
            cookie.Value = tokenKey;
            cookieContainer.Add(cookie);

            string abc = Utility.Post(Constant.ShoppingUrl, "", cookieContainer);
            using (StreamWriter sw = new StreamWriter(@"d:\shopping.html", false, Encoding.UTF8))
            {
                sw.Write(abc);
                sw.Close();
            }
            return;
        }
    }
}
