using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace Lib1280
{
    public class LoginUtility
    {
        public static string GetTokenKey(string username, string password)
        {
            #region get viewstate
            // first, request the login form to get the viewstate value
            HttpWebRequest webRequest = WebRequest.Create(Constant.LoginUrl) as HttpWebRequest;

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            string[] cookies1 = response.Headers["Set-Cookie"].Split(';');
            string sessionIdLine = (from str in cookies1
                                    where str.Contains("ASP.NET_SessionId")
                                    select str).SingleOrDefault<string>();

            StreamReader responseReader = new StreamReader(
                  response.GetResponseStream()
               );
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();

            // extract the viewstate value and build out POST data
            string viewState = Utility.ExtractViewState(responseData);
            string eventValidation = Utility.ExtractEventValidation(responseData);
            #endregion
            string textData =
                  String.Format(
                     "__EVENTARGUMENT=&__EVENTTARGET=&__EVENTVALIDATION={0}&__LASTFOCUS=&__VIEWSTATE={1}&ctl00$ContentRight$btnLogin.x=0&ctl00$ContentRight$btnLogin.y=0&ctl00$ContentRight$txtEmail={2}&ctl00$ContentRight$txtPassword={3}",
                     HttpUtility.UrlEncode(eventValidation), HttpUtility.UrlEncode(viewState), HttpUtility.UrlEncode(username), HttpUtility.UrlEncode(password)

                  );
            string message = Utility.Post(Constant.LoginUrl, textData, sessionIdLine);

            using (StreamWriter sw = new StreamWriter(@"d:\log.html", false, Encoding.Unicode))
            {
                sw.Write(message);
                sw.Close();
            }
            int tokenKeyIndex = message.LastIndexOf("tokenkey=");

            if (tokenKeyIndex < 0)
                return "";

            return message.Substring(tokenKeyIndex + 9, 36);

        }

        public RegisterState Register(string username, string password)
        {
            return RegisterState.ConnectionFail;
        }
    }
}
