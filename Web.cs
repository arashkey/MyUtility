
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace MyUtility
{
    public static class Web
    {
        //private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string GetIp(HttpContext request)
        {
            return GetIp(request.Request);
        }

        public static string GetIp(HttpRequest request)
        {
            return request.ServerVariables["REMOTE_ADDR"];
        }

        public static string GetCookie(HttpContext context, string key)
        {
            if (context.Request.Cookies[key].IsNull() || context.Request.Cookies[key].Value.IsNullOrEmpty()) return null;

            return context.Server.HtmlDecode(context.Request.Cookies[key].Value);
        }

        public static void SetCookie(HttpContext context, string key, string value, DateTime dateValid)
        {
            context.Response.Cookies.Add(new HttpCookie(key, value)
            {
                Value = context.Server.HtmlEncode(value),
                Expires = dateValid
            });
        }

        public static string GetUrl(HttpRequest Request)
        {
            return Request.Url.GetLeftPart(UriPartial.Authority);
        }
        public static string GetPageName(HttpRequest Request)
        {
            string url = Request.Url.ToString();
            return url.Replace(Request.Url.GetLeftPart(UriPartial.Authority), "");
            //var pageName = url.Substring(url.LastIndexOf("/"), url.Length - url.LastIndexOf("/"));
            //return pageName;
        }

        public static string GetFullUrl(HttpRequest Request)
        {
            return Request.Url.ToString();
        }

        public static string GetVirtualPath(HttpRequest Request)
        {
            var rootUrl = Request.Url.GetLeftPart(UriPartial.Authority);

            //context.Request.Url.AbsolutePath.ToString();
            return Request.Url.ToString().Replace(rootUrl, "");
        }

        public static string GetUrlReferrer(HttpRequest Request)
        {
            return Request.UrlReferrer.IsNull() ? null : Request.UrlReferrer.ToString();
        }

        public static IpInfo GetIPInfo(string ip)
        {
            string urlAddress = string.Format("http://www.freegeoip.net/json/{0}", ip);
            var data = GetDataFromUrl(urlAddress);
#if WEB
            IpInfo ipInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<IpInfo>(data);
#else
            IpInfo ipInfo = new IpInfo();
#endif

            return ipInfo;
        }

        public static string GetDataFromUrl(string url)
        {
            try
            {
                string data = "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
                request.UserAgent = ".NET Framework Example Client";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream receiveStream = response.GetResponseStream())
                    {
                        StreamReader readStream = null;
                        if (response.CharacterSet == null || string.IsNullOrEmpty(response.CharacterSet))
                            readStream = new StreamReader(receiveStream);
                        else
                            readStream = new StreamReader(receiveStream, System.Text.Encoding.GetEncoding(response.CharacterSet));


                        data = readStream.ReadToEnd();
                        response.Close();
                        readStream.Close();
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
                ExceptionReport.log(ex);
                return null;
            }
         
        }





        //public static IpInfo GetCountryInfo(string ip)
        //{
        //    try
        //    {
        //        string url = string.Format
        //        (
        //        "http://api.ipinfodb.com/v3/ip-city/?key=9730aa0c8b5c67b560947f664bf9c4f5128a3b81b0ff6f3f0f16dca1bea46fcb&ip={0}&format=json&callback=",
        //        ip
        //        );
        //        // IpInfo ipInfo = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IpInfo>(jsonString);
        //        string jsonString = new System.Net.WebClient().DownloadString(url);

        //        return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IpInfo>(jsonString);
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionReport.log(ex);
        //        return null;
        //    }
        //}

        public static string GetHtmlFromUrl(string url)
        {
            WebClient client = new WebClient();

            //client.ResponseHeaders.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
            WebHeaderCollection headers = new WebHeaderCollection();
            headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10; rv:33.0) Gecko/20100101 Firefox/33.0";
            client.Headers = headers;

            return client.DownloadString(url);
            //Stream data = client.OpenRead(url);
            //StreamReader reader = new StreamReader(data);
            //string s = reader.ReadToEnd();
            //data.Close();
            //reader.Close();
            //return s;
        }

        public static byte[] GetByteDataFromUrl(string remoteUri)
        {
            WebClient myWebClient = new WebClient();
            return myWebClient.DownloadData(remoteUri);
        }
    }

    public class IpInfo
    {
        public string ip { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string region_code { get; set; }
        public string region_name { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string metro_code { get; set; }
        public string area_code { get; set; }
        public string timeZone { get; set; }

        public string statusCode { get; set; }
        public string statusMessage { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("statusCode={0}\r\n", statusCode);
            sb.AppendFormat("statusMessage={0}\r\n", statusMessage);
            sb.AppendFormat("ipAddress ={0}\r\n", ip);
            sb.AppendFormat("countryCode={0}\r\n", country_code);
            sb.AppendFormat("countryName={0}\r\n", country_name);
            sb.AppendFormat("regionName ={0}\r\n", region_name);
            sb.AppendFormat("cityName={0}\r\n", city);
            sb.AppendFormat("zipCode ={0}\r\n", zipcode);
            sb.AppendFormat("latitude ={0}\r\n", latitude);
            sb.AppendFormat("longitude={0}\r\n", longitude);
            sb.AppendFormat("timeZone ={0}\r\n", timeZone);

            return sb.ToString();
        }
    }
}
