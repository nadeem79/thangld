using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Lib1280
{
    internal class Utility
    {
        internal static string ExtractViewState(string s)
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

        internal static string ExtractEventValidation(string s)
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

        internal static string Post(string url, string postData, string sessionIdLine)
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
    }
}
