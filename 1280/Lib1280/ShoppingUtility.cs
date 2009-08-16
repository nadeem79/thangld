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
            string tokenKey = LoginUtility.GetTokenKey("DF.thangld@gmail.com", "meocondethuong");

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

        public static void SpamProduct(string email, string password)
        {
            string tokenKey = LoginUtility.GetTokenKey(email, password);
            string hiddenId = "";
            string viewState = "";
            string eventValidation = "";

            CookieContainer cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie();
            cookie.Domain = "muaban.1280.com";
            cookie.Path = "/";
            cookie.Name = "TokenKey";
            cookie.Value = tokenKey;
            cookieContainer.Add(cookie);

            string page = Utility.Post(Constant.ShoppingPostbackUrl, "", cookieContainer);
            hiddenId = ShoppingUtility.GetHiddenUserId(page);
            viewState = Utility.ExtractViewState(page);
            eventValidation = Utility.ExtractEventValidation(page);

            string url = "http://muaban.1280.com/Shopping/Sell/ProcessUpload.aspx?type=1";
            //Instantiate new CustomWebRequest class
            CustomWebRequest wr = new CustomWebRequest(url);
            //Set values for parameters
            wr.ParamsCollection.Add(new ParamsStruct("__VIEWSTATE", "/wEPDwUKMTc2NjgwOTU0MWRk"));
            wr.ParamsCollection.Add(new ParamsStruct("file", File.OpenRead(@"d:\16174_view.jpg"), ParamsStruct.ParamType.File, "16174_view.jpg"));
            wr.ParamsCollection.Add(new ParamsStruct("hddUploadSucsess", "0"));
            wr.ParamsCollection.Add(new ParamsStruct("FileName", ""));
            wr.ParamsCollection.Add(new ParamsStruct("PathUpload", "2009/08/15/0000000000000B03/06-55-14"));
            wr.ParamsCollection.Add(new ParamsStruct("hddCommand", "1"));
            wr.ParamsCollection.Add(new ParamsStruct("hddType", "1"));
            //For file type, send the inputstream of selected file
            //wr.ParamsCollection.Add(new ParamsStruct("file", file.PostedFile.InputStream, ParamsStruct.ParamType.File, file.PostedFile.FileName));
            //PostData
            wr.PostData(cookieContainer);
            //Set responsestring to textbox1
            string str = wr.ResponseString;



            Dictionary<string, string> postValues = new Dictionary<string, string>();
            postValues.Add("__EVENTARGUMENT", "");
            postValues.Add("__EVENTTARGET", "");
            postValues.Add("__EVENTVALIDATION", HttpUtility.UrlEncode(eventValidation));
            postValues.Add("__LASTFOCUS", "");
            postValues.Add("__VIEWSTATE", HttpUtility.UrlEncode(viewState));
            postValues.Add("ctl00$ContentLeft$btnAdd.x", "43");
            postValues.Add("ctl00$ContentLeft$btnAdd.y", "7");

            postValues.Add("hidUserID", HttpUtility.UrlEncode(hiddenId));
            postValues.Add("keyword", "");
            postValues.Add("ctl00$Header$hidLogout", HttpUtility.UrlEncode("/Shopping/User/Logout.aspx"));
            postValues.Add("ctl00$MainContent$txtProductName", HttpUtility.UrlEncode("Tên sản phẩm"));
            postValues.Add("ctl00$MainContent$txtPrice", "200"); // giá sản phẩm
            postValues.Add("ctl00$MainContent$txtPricePromotion", "150"); // giá khuyến mại
            postValues.Add("ctl00$MainContent$txtColor", "Color"); // màu sắc sản phẩm
            postValues.Add("txtPriceOther", HttpUtility.UrlEncode("Giá bán")); // 
            postValues.Add("txtPriceOtherPromo", HttpUtility.UrlEncode("Giá khuyến mãi")); // 
            postValues.Add("txtPriceDescOther", HttpUtility.UrlEncode("Ghi chú (màu/kích thước/.")); // 
            postValues.Add("ctl00$MainContent$txtDesc", "150"); // mô tả sản phẩm
            postValues.Add("ctl00$MainContent$txtPromotionInfo", "150"); // thông tin khuyến mại
            postValues.Add("txtContent", HttpUtility.UrlEncode("<p>eryjukilkjhgrfedw</p>")); // 
            postValues.Add("ctl00$MainContent$hddPathUpload", HttpUtility.UrlEncode("2009/08/15/0000000000000B2A/04-44-57/")); // 
            postValues.Add("ctl00$MainContent$hddImageList", HttpUtility.UrlEncode("16174_view.jpg (thumbProduct.jpg);")); // 
            postValues.Add("ctl00$MainContent$ddlCategory", "21"); // chủng loại hàng hóa
            postValues.Add("ctl00$MainContent$ddlType", "40"); // nhãn hiệu hàng hóa
            postValues.Add("ctl00$MainContent$ddlLocation", "11"); // nơi bán hàng
            postValues.Add("rdoPayType", "3"); // 
            postValues.Add("ctl00$MainContent$txtPayInfo", "rrthyjygrfdesf"); // thông tin vận chuyên
            postValues.Add("ctl00$MainContent$txtWeight", ""); // 
            postValues.Add("txtHNAddress", ""); // 
            postValues.Add("hddActionHN", "1"); // 
            postValues.Add("txtHCMAddress", ""); // 
            postValues.Add("hddActionHCM", "1"); // 
            postValues.Add("rdoInsuranceType", "69"); // 
            postValues.Add("ctl00$MainContent$txtProductNameReqE_ClientState", ""); // 
            postValues.Add("ctl00$MainContent$PriceReqE_ClientState", ""); // 
            postValues.Add("ctl00$MainContent$DescReqE_ClientState", ""); // 
            postValues.Add("ctl00$MainContent$ValidatorCalloutExtender1_ClientState", ""); // 
            postValues.Add("ctl00$MainContent$ValidatorCalloutExtender2_ClientState", ""); // 
            postValues.Add("ctl00$MainContent$ValidatorCalloutExtender3_ClientState", ""); // 
            postValues.Add("ctl00$MainContent$CascadingDropDown1_ClientState", HttpUtility.UrlEncode("21:::Điện Thoại")); // 
            postValues.Add("ctl00$MainContent$CascadingDropDown2_ClientState", HttpUtility.UrlEncode("40:::Blackberry")); // 
            postValues.Add("hiddenInputToUpdateATBuffer_CommonToolkitScripts", "1"); // 

            List<string> keys = postValues.Keys.ToList<string>();
            string postData = string.Format("{0}={1}", keys[0], postValues[keys[0]]);
            for (int i = 1; i < keys.Count; i++)
                postData += string.Format("&{0}={1}", keys[i], postValues[keys[i]]);

            Cookie aspCookie1 = cookieContainer.GetCookies(new Uri(Constant.ShoppingPostbackUrl))["TokenKey"];

            string message = Utility.Post(Constant.ShoppingPostbackUrl, postData, cookieContainer);
            Cookie aspCookie = cookieContainer.GetCookies(new Uri(Constant.ShoppingPostbackUrl))[Constant.ASPSessionIdName];
            using (StreamWriter sw = new StreamWriter(@"d:\shopping.html", false, Encoding.UTF8))
            {
                sw.Write(message);
                sw.Close();
            }
        }

        public static void SpamComment(string email, string password, int id)
        {
            string tokenKey = LoginUtility.GetTokenKey(email, password);
            string hiddenId = "";
            string viewState = "";
            string eventValidation = "";

            CookieContainer cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie();
            cookie.Domain = "muaban.1280.com";
            cookie.Path = "/";
            cookie.Name = "TokenKey";
            cookie.Value = tokenKey;
            cookieContainer.Add(cookie);

            string page = Utility.Post(string.Format("http://muaban.1280.com/Shopping/Member/Shop.aspx?MemberID={0}", id), "", cookieContainer);
            hiddenId = ShoppingUtility.GetHiddenUserId(page);
            viewState = Utility.ExtractViewState(page);
            eventValidation = Utility.ExtractEventValidation(page);

            Dictionary<string, string> postValues = new Dictionary<string, string>();
            postValues.Add("__EVENTARGUMENT", "");
            postValues.Add("__EVENTTARGET", "");
            postValues.Add("__VIEWSTATE", HttpUtility.UrlEncode(viewState));

//            ctl00$Header$hidLogout	/Shopping/User/Logout.aspx
//ctl00$MainContent$btnSend.x	66
//ctl00$MainContent$btnSend.y	19
//ctl00$MainContent$hidContent	<p>hetgrgdrfsjyhrfd</p>
//ctl00$MainContent$pageID	1
//ctl00$MainContent$pageSMS	
//hidSubmit	0
//hidUserID	2819
//keyword	
//txtComment	<p>hetgrgdrfsjyhrfd</p>

            postValues.Add("ctl00$Header$hidLogout", HttpUtility.UrlEncode("/Shopping/User/Logout.aspx"));
            postValues.Add("ctl00$ContentLeft$btnSend.x", "0");
            postValues.Add("ctl00$ContentLeft$btnSend.y", "0");


            postValues.Add("ctl00$ContentLeft$hidContent", HttpUtility.UrlEncode("<p>hetgrgdrfsjyhrfd</p>"));
            postValues.Add("ctl00$ContentLeft$pageID", "1");
            postValues.Add("ctl00$ContentLeft$pageSMS", "");
            postValues.Add("hidSubmit", "0");
            postValues.Add("hidUserID", hiddenId);
            postValues.Add("keyword", "");
            postValues.Add("txtComment", HttpUtility.UrlEncode("<p>hetgrgdrfsjyhrfd</p>"));


            List<string> keys = postValues.Keys.ToList<string>();
            string postData = string.Format("{0}={1}", keys[0], postValues[keys[0]]);
            for (int i = 1; i < keys.Count; i++)
                postData += string.Format("&{0}={1}", keys[i], postValues[keys[i]]);

            string page1 = Utility.Post(string.Format("http://muaban.1280.com/Shopping/Member/Shop.aspx?MemberID={0}", id), postData, cookieContainer);
            using (StreamWriter sw = new StreamWriter(@"d:\comment.html", false, Encoding.UTF8))
            {
                sw.Write(page1);
                sw.Close();
            }
        }
    }
}
