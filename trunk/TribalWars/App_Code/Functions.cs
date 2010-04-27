using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;
using beans;
using System.Xml.Linq;
using System.Linq;

/// <summary>
/// Summary description for Functions
/// </summary>
public class Functions
{

    public static string FormatTime(TimeSpan time)
    {
        return (time.Days * 24 + time.Hours).ToString("00") + ":" + time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
    }
    public static string FormatTime(long miliseconds)
    {
        return FormatTime(miliseconds, true);
    }
    public static string FormatTime(long value, bool isMilisecond)
    {

        TimeSpan t = isMilisecond ? TimeSpan.FromMilliseconds(value) : TimeSpan.FromSeconds(value);
        return FormatTime(t);
    }

    private static bool ThumbnailCallback()
    {
        return true;
    }
    public static bool UploadImage(Stream stream, string filename)
    {
        System.Drawing.Image image = null;
        try
        {
            bool bCreateThumb = false;
            image = new Bitmap(stream);
            int width = image.Width;
            int height = image.Height;
            if (width > 240)
            {
                bCreateThumb = true;
                height = (int)(height * 240 / width);
                width = 240;
            }
            if (height > 180)
            {
                bCreateThumb = true;
                width = (int)(width * 180 / height);
                height = 180;
            }
            if (bCreateThumb)
                image = image.GetThumbnailImage(width, height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
            if (File.Exists(filename))
                File.Delete(filename);
            image.Save(filename);
        }
        catch
        {
            return false;
        }
        finally
        {
            image = null;
        }
        

        return true;
    }

    public static string GetImageUrl(beans.ResourcesType resource)
    {
        switch (resource)
        {
            case ResourcesType.Clay:
                return "<img src=\"images/resources/clay.png\" title=\"Clay\" alt=\"\" />";
            case ResourcesType.Wood:
                return "<img src=\"images/resources/wood.png\" title=\"Wood\" alt=\"\" />";
            case ResourcesType.Iron:
                return "<img src=\"images/resources/iron.png\" title=\"iron\" alt=\"\" />";
            default:
                return "";
        }
    }

    public static string GetTroopQuantity(int quantity)
    {
        return (quantity == 0) ? "<span class=\"hidden\">0</span>" : quantity.ToString();
    }

    public static bool IsGreaterThenZero(params int[] arguments)
    {
        int sum = 0;
        foreach (int i in arguments)
        {
            if (i < 0)
                return false;
            sum += i;
        }
        return (sum > 0);
    }

    public static string GetResourceString(beans.ResourcesType type, int quantity)
    {
        if (quantity == 0)
            return "";

        switch (type)
        {
            case ResourcesType.Clay:
                return string.Format("<img src=\"images/resources/clay.png\" title=\"Clay\" /> {0}", quantity);
            case ResourcesType.Wood:
                return string.Format("<img src=\"images/resources/wood.png\" title=\"Wood\" /> {0}", quantity);
            case ResourcesType.Iron:
                return string.Format("<img src=\"images/resources/iron.png\" title=\"Iron\" /> {0}", quantity);
            default:
                return "";
        }

    }

    public static String SanitizeText(string text)
    {
        try
        {
            XElement doc = XElement.Parse("<span>" + text + "</span>");

            doc.Descendants().Where(elem => elem.Name == "script" || elem.Name == "object")
               .ToList().ForEach(elem =>
               {
                   elem.AddAfterSelf(new XText((String)elem));
                   elem.Remove();
               });
            String retvalue = doc.ToString();
            return retvalue;
        }
        catch (System.Xml.XmlException)
        {
            return Microsoft.Security.Application.AntiXss.HtmlEncode(text);
        }
    }


    //protected static void SendMail(string sHost, int nPort, string sUserName, string sPassword, string sFromName, string sFromEmail,
    //    string sToName, string sToEmail, string sHeader, string sMessage, bool fSSL)
    //{
    //    if (sToName.Length == 0)
    //        sToName = sToEmail;
    //    if (sFromName.Length == 0)
    //        sFromName = sFromEmail;

    //    System.Web.Mail.MailMessage Mail = new System.Web.Mail.MailMessage();
    //    Mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = sHost;
    //    Mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusing"] = 2;

    //    Mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"] = nPort.ToString();
    //    if (fSSL)
    //        Mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"] = "true";

    //    if (sUserName.Length == 0)
    //    {
    //        //Ingen auth 
    //    }
    //    else
    //    {
    //        Mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
    //        Mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = sUserName;
    //        Mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = sPassword;
    //    }

    //    Mail.To = sToEmail;
    //    Mail.From = sFromEmail;
    //    Mail.Subject = sHeader;
    //    Mail.Body = sMessage;
    //    Mail.BodyFormat = System.Web.Mail.MailFormat.Html;

    //    System.Web.Mail.SmtpMail.SmtpServer = sHost;
    //    System.Web.Mail.SmtpMail.Send(Mail);
    //}

    //public static void SendGmailFromDreamingFighter(string sToName, string sToEmail, string sHeader, string sMessage)
    //{
    //    Functions.SendMail("smtp.gmail.com", 
    //                        465, 
    //                        "df.thangld@gmail.com", 
    //                        "meocondethuong", 
    //                        "DreamingFighter",
    //                        "df.thangld@gmail.com",
    //                        sToName,
    //                        sToEmail,
    //                        sHeader,
    //                        sMessage, 
    //                        true);
    //}

    public static StringConfiguration GetConfig(string key)
    {
        if (HttpContext.Current.Session[Constant.DebugMode] == null)
            return beans.Configuration.TribalWarsConfiguration.GetStringConfigurationItem(key);

        return beans.Configuration.TribalWarsConfiguration.GetStringConfigurationItem(key, true);
    }
}
