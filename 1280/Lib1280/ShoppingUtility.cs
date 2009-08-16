using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace Lib1280
{
    public class ShoppingUtility
    {
        public static void test()
        {
            string tokenKey = LoginUtility.GetTokenKey("aheathaehgri@bthej.heta", "hethtaehaeoght");

            CookieContainer cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie();
            cookie.Domain = "muaban.1280.com";
            cookie.Path = "/";
            cookie.Name = "TokenKey";
            cookie.Value = tokenKey;
            cookieContainer.Add(cookie);

            string abc = Utility.Post(Constant.ShoppingUrl, "", cookieContainer);

            return;
        }

        protected static string GetHiddenUserId(string page)
        {
            string viewStateNameDelimiter = "hidUserID";
            string valueDelimiter = "value=\"";

            int viewStateNamePosition = page.IndexOf(viewStateNameDelimiter);
            int viewStateValuePosition = page.IndexOf(
                  valueDelimiter, viewStateNamePosition
               );

            int viewStateStartPosition = viewStateValuePosition +
                                         valueDelimiter.Length;
            int viewStateEndPosition = page.IndexOf("\"", viewStateStartPosition);

            string viewState =
                     page.Substring(
                        viewStateStartPosition,
                        viewStateEndPosition - viewStateStartPosition
                     )
                  ;
            return viewState;
        }

        
    }
}
