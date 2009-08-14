using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using Lib1280.com.ocrwebservice.www;

namespace Lib1280
{
    public class LoginUtility
    {
        


        public static string GetTokenKey(string username, string password)
        {

            string sessionId = Utility.GetAspSessionId(Constant.LoginUrl);

            #region get viewstate
            // first, request the login form to get the viewstate value
            HttpWebRequest webRequest = WebRequest.Create(Constant.LoginUrl) as HttpWebRequest;

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

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
            string message = Utility.Post(Constant.LoginUrl, textData, sessionId);

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

        public static RegisterState Register(string username, string email, string name, string password)
        {

            string captchaText = "";
            string session = Utility.GetAspSessionId(Constant.RegisterUrl);
            string cookie = Utility.GetFreshCookie(session);

            #region get viewstate
            // first, request the login form to get the viewstate value
            HttpWebRequest webRequest = WebRequest.Create(Constant.RegisterUrl) as HttpWebRequest;
            webRequest.CookieContainer = new CookieContainer();
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            StreamReader responseReader = new StreamReader(
                  response.GetResponseStream()
               );
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();

            // extract the viewstate value and build out POST data
            string viewState = Utility.ExtractViewState(responseData);
            string eventValidation = Utility.ExtractEventValidation(responseData);
            #endregion

            captchaText = Utility.GetCaptcha(session);

            #region Bắt đầu đăng ký, yeah

            Dictionary<string, string> postValues = new Dictionary<string, string>();
            postValues.Add("__EVENTARGUMENT", "");
            postValues.Add("__EVENTTARGET", "");
            postValues.Add("__EVENTVALIDATION", HttpUtility.UrlEncode(eventValidation));
            postValues.Add("__LASTFOCUS", "");
            postValues.Add("__VIEWSTATE", HttpUtility.UrlEncode(viewState));
            postValues.Add("ctl00$ContentLeft$btnRegister.x", "0");
            postValues.Add("ctl00$ContentLeft$btnRegister.y", "0");
            postValues.Add("ctl00$ContentLeft$ckbAgree", "on");
            postValues.Add("ctl00$ContentLeft$txtEmail", HttpUtility.UrlEncode(email));
            postValues.Add("ctl00$ContentLeft$txtName", HttpUtility.UrlEncode(name));
            postValues.Add("ctl00$ContentLeft$txtNickName", HttpUtility.UrlEncode(username));
            postValues.Add("ctl00$ContentLeft$txtPassword", HttpUtility.UrlEncode(password));
            postValues.Add("ctl00$ContentLeft$txtValidateCode", captchaText.Trim());
            postValues.Add("ctl00$ContentLeft$txtValidatePass", HttpUtility.UrlEncode(password));

            List<string> keys = postValues.Keys.ToList<string>();
            string postData = string.Format("{0}={1}", keys[0], postValues[keys[0]]);
            for (int i=1; i<keys.Count; i++)
                postData += string.Format("&{0}={1}", keys[i], postValues[keys[i]]);

            string message = Utility.Post(Constant.RegisterUrl, postData, session);

            using (StreamWriter sw = new StreamWriter(@"d:\register.html", false, Encoding.UTF8))
            {
                sw.WriteLine(captchaText);
                sw.WriteLine(postData);
                sw.Write(message);
                sw.Close();
            }

            #endregion

            return RegisterState.ConnectionFail;
        }
    }
}
