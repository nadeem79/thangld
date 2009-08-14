using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Lib1280.com.ocrwebservice.www;
using System.Web;

namespace Lib1280
{
    public class Utility
    {
        public static string ExtractViewState(string s)
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

        public static string ExtractEventValidation(string s)
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

        public static string Post(string url, string postData, string session)
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
            Cookie cookie = new Cookie();
            cookie.Name = Constant.ASPSessionIdName;
            cookie.Value = session;
            cookie.Domain = "login.1280.com";
            cookie.Path = "/";
            request.CookieContainer.Add(cookie);
            request.ProtocolVersion = HttpVersion.Version10;
            request.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
            //request.Headers.Add("Cookie", cookie);// string.Format("__utma=95685443.759717589754176000.1250085879.1250085879.1250085879.1; __utmz=95685443.1250085879.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); {0}", sessionIdLine));
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
                            string cookie1 = "";
                            foreach (Cookie cookieValue in request.CookieContainer.GetCookies(new Uri(url)))
                            {
                                cookie1 += string.Format("{0}={1}; ", HttpUtility.UrlEncode(cookieValue.Name), HttpUtility.UrlEncode(cookieValue.Value));
                            }
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

        public static string GetCaptcha(string session)
        {
            string captchaText = "";
            #region Lấy captcha thành byte[] có id buffer
            // Lấy captcha
            // thành byte[] có id buffer
            HttpWebRequest requestCaptcha = (HttpWebRequest)HttpWebRequest.Create(Constant.CaptchaUrl);
            requestCaptcha.Method = "GET";
            requestCaptcha.Accept = "image/png,image/*;q=0.8,*/*;q=0.5";
            requestCaptcha.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-GB; rv:1.9.1.2) Gecko/20090729 Firefox/3.5.2";
            requestCaptcha.Referer = Constant.RegisterUrl;
            requestCaptcha.CookieContainer = new CookieContainer();
            Cookie cookie = new Cookie();
            cookie.Name = Constant.ASPSessionIdName;
            cookie.Value = session;
            cookie.Domain = "login.1280.com";
            cookie.Path = "/";
            requestCaptcha.CookieContainer.Add(cookie);
            //requestCaptcha.Headers.Add("Cookie", GetFreshCookie(session));//string.Format("__utma=95685443.759717589754176000.1250085879.1250085879.1250085879.1; __utmz=95685443.1250085879.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); {0}", sessionIdLine));
            HttpWebResponse responseCaptcha = (HttpWebResponse)requestCaptcha.GetResponse();
            Stream captcha = responseCaptcha.GetResponseStream();
            long length = responseCaptcha.ContentLength;
            byte[] buffer = new Byte[length];
            int bytesRead = captcha.Read(buffer, 0, (int)length);
            responseCaptcha.Close();
            #endregion

            #region Chuyển captcha thành chữ về string id captchaText
            // chuyển captcha thành chữ
            // về string id captchaText


            try
            {
                OCRWebService OCRservice = new OCRWebService();

                OCRservice.Timeout = 600000;

                OCRWSInputImage input_image = new OCRWSInputImage();

                input_image.fileName = "data1280.jpg";                          // Input image file NAME
                input_image.fileData = buffer;   // Input image file PATH

                OCRWSSettings ocrSettings = new OCRWSSettings();

                ocrSettings.convertToBW = false;                            // convert to Black/White 
                // It is recommended to set TRUE for result improvement 
                // for color image and photo  

                ocrSettings.getOCRText = true;                              // return OCRed text

                OCRWS_Language[] langs = {  OCRWS_Language.ENGLISH, 
                                            OCRWS_Language.GERMAN };

                ocrSettings.ocrLanguages = langs;                           // Recognition languages

                ocrSettings.createOutputDocument = true;                    // create and return output file

                ocrSettings.outputDocumentFormat = OCRWS_OutputFormat.DOC;  // Output document format 

                /* 
                OCRWSZone ocrZone = new OCRWSZone();                            // Setup for zonal OCR
                ocrZone.Top     = 0;
                ocrZone.Left    = 0;
                ocrZone.Height  = 700;
                ocrZone.Width   = 700;

                // add one zone
                ocrSettings.ocrZones = new OCRWSZone[1];              
                ocrSettings.ocrZones[0] = ocrZone;  
                */

                OCRWSResponse ocrResponse = OCRservice.OCRWebServiceRecognize("dreamingfighter", "381CE5F0-4074-4A64-B593-A28EBD1AB968", input_image, ocrSettings);


                if (!String.IsNullOrEmpty(ocrResponse.errorMessage))
                {
                    throw new Exception("Không thể nhận dạng ký tự, anh Đạt làm quá tốt :D");
                }
                else
                {

                    string[][] OCRedText = ocrResponse.ocrText; // OCRedText[z][p]    z - zone, p - pages (for multipage mode)

                    for (int z = 0; z < OCRedText.Length; z++)
                    {
                        for (int p = 0; p < OCRedText[z].Length; p++)
                        {
                            captchaText += OCRedText[z][p];
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return captchaText.Trim();
            #endregion
        }

        public static string GetAspSessionId(string url)
        {
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.CookieContainer = new CookieContainer();
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            foreach (Cookie cookie in webRequest.CookieContainer.GetCookies(new Uri(url)))
                if (cookie.Name == Constant.ASPSessionIdName)
                    return cookie.Value;
            return "";
        }

        public static string GetFreshCookie(string session)
        {
            return string.Format("__utma={0}; __utmz={1}; {2}={3}",
                                HttpUtility.UrlEncode("95685443.759717589754176000.1250085879.1250085879.1250085879.1"),
                                HttpUtility.UrlEncode("95685443.1250085879.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)"),
                                Constant.ASPSessionIdName,
                                HttpUtility.UrlEncode(session));
        }
    }
}
