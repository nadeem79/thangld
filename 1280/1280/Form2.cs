using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace _1280
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ServicePointManager.ServerCertificateValidationCallback += delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
                //return false;
            };
        }

        public string Post(string url, string postData, string sessionIdLine)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(postData);
            int bufferLength = buffer.Length;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-GB; rv:1.9.1.2) Gecko/20090729 Firefox/3.5.2";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Referer = url;
            request.CookieContainer = new CookieContainer();
            request.ProtocolVersion = HttpVersion.Version10;
            request.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
            request.Headers.Add("Cookie", "__utma=95685443.460615571331293500.1250040126.1250040126.1250040126.1; __utmz=95685443.1250040126.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); " + sessionIdLine);
            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
            request.ContentLength = bufferLength;

            string result;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(buffer, 0, bufferLength);

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.Headers["Set-Cookie"] != null)
                            MessageBox.Show(response.Headers["Set-Cookie"]);
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                            {
                                result = readStream.ReadToEnd();
                            }
                        }
                    }
                }
                catch (WebException wEx)
                {
                    using (Stream errorResponseStream = wEx.Response.GetResponseStream())
                    {
                        using (StreamReader errorReadStream = new StreamReader(errorResponseStream, Encoding.UTF8))
                        {
                            result = errorReadStream.ReadToEnd();
                        }

                    }
                }
            }

            return result;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            #region get viewstate
            // first, request the login form to get the viewstate value
            HttpWebRequest webRequest = WebRequest.Create(LOGIN_URL) as HttpWebRequest;


            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            string[] cookies1 = response.Headers["Set-Cookie"].Split(';');
            string sessionIdLine = "";
            foreach (string str in cookies1)
                if (str.Contains("ASP.NET_SessionId"))
                    sessionIdLine = str;
            //string sessionIdLine = (from str in cookies1
            //                        where str.Contains("ASP.NET_SessionId")
            //                        select str).SingleOrDefault<string>();

            StreamReader responseReader = new StreamReader(
                  response.GetResponseStream()
               );
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();

            // extract the viewstate value and build out POST data
            string viewState = ExtractViewState(responseData);
            string eventValidation = ExtractEventValidation(responseData);
            #endregion
            string username = HttpUtility.UrlEncode("DF.thangld@gmail.com");
            string textData =
                  String.Format(
                     "__EVENTARGUMENT=&__EVENTTARGET=&__EVENTVALIDATION={0}&__LASTFOCUS=&__VIEWSTATE={1}&ctl00$ContentRight$btnLogin.x=0&ctl00$ContentRight$btnLogin.y=0&ctl00$ContentRight$txtEmail={2}&ctl00$ContentRight$txtPassword={3}",
                     HttpUtility.UrlEncode(eventValidation), HttpUtility.UrlEncode(viewState), username, "meocondethuong"

                  );
            string message = this.Post(LOGIN_URL, textData, sessionIdLine);
            MessageBox.Show(message);

            using (StreamWriter sw = new StreamWriter(@"d:\register.html", false, Encoding.Unicode))
            {
                sw.Write(message);
                sw.Close();
            }
        }

        string LOGIN_URL = "http://login.1280.com/Login.aspx";

        private string ExtractViewState(string s)
        {
            #region Lấy ViewState
            string viewStateNameDelimiter = "__VIEWSTATE";
            string valueDelimiter = "value=\"";

            int viewStateNamePosition = s.IndexOf(viewStateNameDelimiter);
            int viewStateValuePosition = s.IndexOf(
                  valueDelimiter, viewStateNamePosition
               );

            int viewStateStartPosition = viewStateValuePosition +
                                         valueDelimiter.Length;
            int viewStateEndPosition = s.IndexOf("\"", viewStateStartPosition);

            string viewState =
                     s.Substring(
                        viewStateStartPosition,
                        viewStateEndPosition - viewStateStartPosition
                     )
                  ;

            return viewState;
            #endregion
        }
        private string ExtractEventValidation(string s)
        {
            #region Lấy ViewState
            string viewStateNameDelimiter = "__EVENTVALIDATION";
            string valueDelimiter = "value=\"";

            int viewStateNamePosition = s.IndexOf(viewStateNameDelimiter);
            int viewStateValuePosition = s.IndexOf(
                  valueDelimiter, viewStateNamePosition
               );

            int viewStateStartPosition = viewStateValuePosition +
                                         valueDelimiter.Length;
            int viewStateEndPosition = s.IndexOf("\"", viewStateStartPosition);

            string viewState =
                     s.Substring(
                        viewStateStartPosition,
                        viewStateEndPosition - viewStateStartPosition
                     )
                  ;
            return viewState;
            #endregion
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            string eventValidation = "/wEWBgLP0q+lDwKH8an8CALuzNbdAwLztMlKArm1nvwCAvvZvMoCZ7NpnymyD8jguMOMQUhGgeEAy9c=";
            string oldValue = "ctl00$ContentRight$btnLogin";

            //byte[] data = Encoding.ASCII.GetBytes(eventValidation);
            byte[] data = Encoding.ASCII.GetBytes(oldValue);
                //Convert.ToBase64String(oldValue);
            string newValue = Convert.ToBase64String(data);
            //if (newValue == eventValidation)
                //MessageBox.Show(newValue);
            //MessageBox.Show( Encoding.Default.GetString(data));
            //System.Convert.FromBase64String(data);

            //System.Convert.FromBase64String(String s)
        }
    }
}
