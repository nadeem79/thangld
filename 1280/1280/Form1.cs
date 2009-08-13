using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using _1280.com.ocrwebservice.www;

namespace _1280
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Byte[] buffer = null;
            string captchaText = "";
            string sessionId = "";

            #region Lấy session ID có id sessionId
            HttpWebRequest sessionRequest = (HttpWebRequest)HttpWebRequest.Create(@"http://login.1280.com/register.aspx");
            sessionRequest.Method = "GET";

            sessionRequest.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            sessionRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-GB; rv:1.9.1.2) Gecko/20090729 Firefox/3.5.2";
            sessionRequest.ContentType = @"text/html; charset=utf-8";


            HttpWebResponse sessionResponse = (HttpWebResponse)sessionRequest.GetResponse();
            //this.textBox1.Text = response.Headers["Set-Cookie"];

            string[] cookies = sessionResponse.Headers["Set-Cookie"].Split(';');

            //string sessionIdLine = (from str in cookies
              //                      where str.Contains("ASP.NET_SessionId")
                //                    select str).SingleOrDefault<string>();
            string sessionIdLine = "";
            sessionId = sessionIdLine.Split('=')[1];
            sessionResponse.Close();
            #endregion

            #region Lấy captcha thành byte[] có id buffer
            // Lấy captcha
            // thành byte[] có id buffer
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(@"http://login.1280.com/CaptCha.aspx");
            request.Method = "GET";

            request.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-GB; rv:1.9.1.2) Gecko/20090729 Firefox/3.5.2";
            request.ContentType = "text/html; charset=utf-8";
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Cookie("ASP.NET_SessionId", sessionId, "/", "login.1280.com"));
            request.CookieContainer.Add(new Cookie("__utma", "95685443.4216212853846835700.1249877157.1250043921.1250046312.4", "/", "login.1280.com"));
            request.CookieContainer.Add(new Cookie("__utmz", "95685443.1249877157.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)", "/", "login.1280.com"));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream captcha = response.GetResponseStream();
            
            // create a write stream
            //FileStream writeStream = new FileStream(saveTo, FileMode.Create, FileAccess.Write);
            // write to the stream
            //ReadWriteStream(response.GetResponseStream(), writeStream);

            long length = response.ContentLength;
            buffer = new Byte[length];
            int bytesRead = captcha.Read(buffer, 0, (int)length);
            response.Close();
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

                OCRWSResponse ocrResponse = OCRservice.OCRWebServiceRecognize("y47hrtshtrs", "381CE5F0-4074-4A64-B593-A28EBD1AB968", input_image, ocrSettings);


                if (!String.IsNullOrEmpty(ocrResponse.errorMessage))
                {
                    MessageBox.Show("ERROR :" + ocrResponse.errorMessage);

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
                MessageBox.Show(ex.Message);
            }

            #endregion

            #region Bắt đầu đăng ký, yeah

            

            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "ASP.NET_SessionId=" + sessionId;
            postData += "&__EVENTARGUMENT=";
            postData += "&__EVENTTARGET=";
            postData += @"&__EVENTVALIDATION=/wEWCwLPlJ50Av2T2dIOAp7W9eUPAs2Ck8ILAsWs+KMEArnVqrwLAr3xrJgIAtST16sIAvCJ76wHAtn4wm4CubWe/AI=";
            postData += "&__LASTFOCUS";
            postData += @"&__VIEWSTATE=/wEPDwUKMTMzMTM0ODEzNmQYAQUeX19Db250cm9sc1JlcXVpcmVQb3N0QmFja0tleV9fFgQFGmN0bDAwJENvbnRlbnRMZWZ0JGNrYkFncmVlBR1jdGwwMCRDb250ZW50TGVmdCRidG5SZWdpc3RlcgUaY3RsMDAkQ29udGVudExlZnQkYnRuUmVzZXQFG2N0bDAwJENvbnRlbnRSaWdodCRidG5Mb2dpbg==";
            postData += "&ctl00$ContentLeft$btnRegister.x=24";
            postData += "&ctl00$ContentLeft$btnRegister.x=11";
            postData += "&ctl00$ContentLeft$ckbAgree=on";

            postData += "&ctl00$ContentLeft$txtEmail=hathaethehte@gmail.com";
            postData += "&ctl00$ContentLeft$txtName=hetashehehe";
            postData += "&ctl00$ContentLeft$txtNickName=hea5yetjyrsye";
            postData += "&ctl00$ContentLeft$txtPassword=123123";
            postData += "&ctl00$ContentLeft$txtValidateCode=" + captchaText;
            postData += "&ctl00$ContentLeft$txtValidatePass=123123";

            byte[] data = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest registerRequest = (HttpWebRequest)HttpWebRequest.Create(@"http://login.1280.com/Register.aspx");
            registerRequest.ContentLength = data.Length;
            registerRequest.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            registerRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-GB; rv:1.9.1.2) Gecko/20090729 Firefox/3.5.2";
            registerRequest.ContentType = "application/x-www-form-urlencoded";
            registerRequest.Referer = "http://login.1280.com/Register.aspx";
            registerRequest.ProtocolVersion = HttpVersion.Version10;
            registerRequest.Method = "POST";
            registerRequest.Headers.Add("Accept-Language", "en-gb,en;q=0.5");

            registerRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
            registerRequest.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");

            registerRequest.CookieContainer = new CookieContainer();
            registerRequest.CookieContainer.Add(new Cookie("ASP.NET_SessionId", sessionId, "/", "login.1280.com"));
            registerRequest.CookieContainer.Add(new Cookie("__utma", "95685443.4216212853846835700.1249877157.1250043921.1250046312.4", "/", "login.1280.com"));
            registerRequest.CookieContainer.Add(new Cookie("__utmz", "95685443.1249877157.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)", "/", "login.1280.com"));

            Stream requestStream = registerRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            try
            {
                HttpWebResponse registerResponse = (HttpWebResponse)registerRequest.GetResponse();
                StreamReader registerText = new StreamReader(response.GetResponseStream());
                string responseBodyText = registerText.ReadToEnd();
                registerText.Close();

                using (StreamWriter sw = new StreamWriter("d:\register.html", false))
                {
                    sw.Write(registerText);
                }
                MessageBox.Show("Done Register");
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "HttpPost: Response error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string sessionId = "";

            #region Lấy session ID có id sessionId
            HttpWebRequest sessionRequest = (HttpWebRequest)HttpWebRequest.Create(@"http://login.1280.com/Login.aspx");
            sessionRequest.Method = "GET";

            sessionRequest.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            sessionRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-GB; rv:1.9.1.2) Gecko/20090729 Firefox/3.5.2";

            HttpWebResponse sessionResponse = (HttpWebResponse)sessionRequest.GetResponse();
            //this.textBox1.Text = response.Headers["Set-Cookie"];

            string[] cookies1 = sessionResponse.Headers["Set-Cookie"].Split(';');
            string sessionIdLine = "";
            //string sessionIdLine = (from str in cookies1
            //                        where str.Contains("ASP.NET_SessionId")
            //                        select str).SingleOrDefault<string>();
            sessionId = sessionIdLine.Split('=')[1];
            sessionResponse.Close();
            #endregion


            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "&ctl00$ContentRight$btnLogin.x=47";
            postData += "&ctl00$ContentRight$btnLogin.x=9";
            postData += "&ctl00$ContentRight$chkSavePass=on";
            postData += "&ctl00$ContentRight$txtEmail.x=DF.thangld@gmail.com";
            postData += "&ctl00$ContentRight$txtPassword=meocondethuong";

            string newData = @"__LASTFOCUS=&__VIEWSTATE=%2FwEPDwUKLTc3NTUyMTE4MA9kFgJmD2QWAgIDD2QWBAIBD2QWAgIDDxYCHgRocmVmBRZodHRwOi8vZm9ydW0uMTI4MC5jb20vZAIDD2QWAgIBD2QWAgIDDxBkZBYAZBgBBR5fX0NvbnRyb2xzUmVxdWlyZVBvc3RCYWNrS2V5X18WAwUeY3RsMDAkQ29udGVudFJpZ2h0JGNoa1NhdmVQYXNzBRtjdGwwMCRDb250ZW50UmlnaHQkYnRuTG9naW4FHGN0bDAwJENvbnRlbnRSaWdodCRidG5GaW5pc2hXtd4vVk3z8AJNd6QNAf2eXd1m0w%3D%3D&__EVENTTARGET=&__EVENTARGUMENT=&__EVENTVALIDATION=%2FwEWBgL36fqqBwKH8an8CALuzNbdAwLztMlKArm1nvwCAvvZvMoCtOj6T%2BLM4Yk8gOYJILivUc%2F5%2FJM%3D&ctl00$ContentRight$txtEmail=DF.thangld@gmail.com&ctl00$ContentRight$txtPassword=meocondethuong&ctl00$ContentRight$chkSavePass=on&ctl00$ContentRight$btnLogin.x=42&ctl00$ContentRight$btnLogin.y=8";

            byte[] data = Encoding.UTF8.GetBytes(newData);

            HttpWebRequest registerRequest = (HttpWebRequest)HttpWebRequest.Create(@"http://login.1280.com/Login.aspx");
            registerRequest.ContentLength = data.Length;
            registerRequest.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            registerRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-GB; rv:1.9.1.2) Gecko/20090729 Firefox/3.5.2";
            registerRequest.ContentType = "application/x-www-form-urlencoded";
            registerRequest.Referer = "http://login.1280.com/Login.aspx";
            registerRequest.ProtocolVersion = HttpVersion.Version10;
            registerRequest.Method = "POST";
            registerRequest.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
            registerRequest.Headers.Add("Cookie", "__utma=95685443.460615571331293500.1250040126.1250040126.1250040126.1; __utmz=95685443.1250040126.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); " + sessionIdLine);
            registerRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
            registerRequest.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");

            Stream requestStream = registerRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            try
            {
                HttpWebResponse registerResponse = (HttpWebResponse)registerRequest.GetResponse();

                //string[] cookies = registerResponse.Headers["Set-Cookie"].Split(';');

                //string sessionIdLine = (from str in cookies
                //                        where str.Contains("TokenKey")
                //                        select str).SingleOrDefault<string>();
                //string tokenKey = sessionIdLine.Split('=')[1];

                StreamReader registerText = new StreamReader(registerResponse.GetResponseStream());
                string responseBodyText = registerText.ReadToEnd();
                registerText.Close();

                using (StreamWriter sw = new StreamWriter(@"d:\register.html", false))
                {
                    sw.Write(responseBodyText);
                    sw.Close();
                }
                //MessageBox.Show(tokenKey);
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "HttpPost: Response error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void ReadWriteStream(Stream readStream, Stream writeStream) 
        {
            int Length = 256;
            Byte [] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer,0,Length);
            // write the required bytes
            while( bytesRead > 0 ) 
            {
                writeStream.Write(buffer,0,bytesRead);
                bytesRead = readStream.Read(buffer,0,Length);
            }
            readStream.Close();
            writeStream.Close();
        }

        private void twButton_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "ctl00$body$bttnRegister=Đăng ký";
            postData += "&ctl00$body$chkAgreement=on";
            postData += "&ctl00$body$email=htsrhstehteshjh@hgtd.ndg";
            postData += "&ctl00$body$password=123123";
            postData += "&ctl00$body$retype_password=123123";
            postData += "&ctl00$body$txtBirthdate=1986-05-23-00-00-00";
            postData += "&ctl00$body$username=frgdgsydhdshdjhters";

            postData += "&__EVENTARGUMENT=";
            postData += "&__EVENTTARGET=";
            postData += "&__EVENTVALIDATION=/wEWCAK+rOHjCQK+gedpApqktbANAvn/gqUNAqfFloEIAurjj+oOArC0nokJAsfTmeUPBFJBI3lMW8QDvma4nI8sK7IzTHg=";
            postData += "&__VIEWSTATE=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";

            string newData = @"__LASTFOCUS=&__VIEWSTATE=%2FwEPDwUKLTc3NTUyMTE4MA9kFgJmD2QWAgIDD2QWBAIBD2QWAgIDDxYCHgRocmVmBRZodHRwOi8vZm9ydW0uMTI4MC5jb20vZAIDD2QWAgIBD2QWAgIDDxBkZBYAZBgBBR5fX0NvbnRyb2xzUmVxdWlyZVBvc3RCYWNrS2V5X18WAwUeY3RsMDAkQ29udGVudFJpZ2h0JGNoa1NhdmVQYXNzBRtjdGwwMCRDb250ZW50UmlnaHQkYnRuTG9naW4FHGN0bDAwJENvbnRlbnRSaWdodCRidG5GaW5pc2hXtd4vVk3z8AJNd6QNAf2eXd1m0w%3D%3D&__EVENTTARGET=&__EVENTARGUMENT=&__EVENTVALIDATION=%2FwEWBgL36fqqBwKH8an8CALuzNbdAwLztMlKArm1nvwCAvvZvMoCtOj6T%2BLM4Yk8gOYJILivUc%2F5%2FJM%3D&ctl00$ContentRight$txtEmail=DF.thangld@gmail.com&ctl00$ContentRight$txtPassword=meocondethuong&ctl00$ContentRight$chkSavePass=on&ctl00$ContentRight$btnLogin.x=42&ctl00$ContentRight$btnLogin.y=8";

            byte[] data = Encoding.UTF8.GetBytes(newData);

            HttpWebRequest registerRequest = (HttpWebRequest)HttpWebRequest.Create(@"http://localhost:1776/register.aspx");
            
            registerRequest.ContentLength = data.Length;
            registerRequest.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            registerRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-GB; rv:1.9.1.2) Gecko/20090729 Firefox/3.5.2";
            registerRequest.ContentType = "application/x-www-form-urlencoded";
            registerRequest.Referer = @"http://localhost:1776/register.aspx";
            registerRequest.ProtocolVersion = HttpVersion.Version10;
            registerRequest.Method = "POST";
            registerRequest.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
            registerRequest.AllowAutoRedirect = true;
            registerRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
            registerRequest.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
            registerRequest.Headers.Add("Cookie", "ASP.NET_SessionId=5qfdcynspj2fijqfmpidfs55");
            
            Stream requestStream = registerRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            try
            {
                HttpWebResponse registerResponse = (HttpWebResponse)registerRequest.GetResponse();

                string[] cookies = registerResponse.Headers["Set-Cookie"].Split(';');

                //string sessionIdLine = (from str in cookies
                //                        where str.Contains("TokenKey")
                //                        select str).SingleOrDefault<string>();
                //string tokenKey = sessionIdLine.Split('=')[1];

                StreamReader registerText = new StreamReader(registerResponse.GetResponseStream());
                string responseBodyText = registerText.ReadToEnd();
                registerText.Close();

                using (StreamWriter sw = new StreamWriter(@"d:\register.html", false))
                {
                    sw.Write(responseBodyText);
                }
                //MessageBox.Show(tokenKey);
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "HttpPost: Response error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
