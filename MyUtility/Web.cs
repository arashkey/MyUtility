
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

        public static string GetUrl(HttpRequest request)
        {
            return request.Url.GetLeftPart(UriPartial.Authority);
        }
        public static string GetPageName(HttpRequest request)
        {
            string url = request.Url.ToString();
            return url.Replace(request.Url.GetLeftPart(UriPartial.Authority), "");
            //var pageName = url.Substring(url.LastIndexOf("/"), url.Length - url.LastIndexOf("/"));
            //return pageName;
        }

        public static string GetFullUrl(HttpRequest request)
        {
            return request.Url.ToString();
        }

        public static string GetVirtualPath(HttpRequest request)
        {
            var rootUrl = request.Url.GetLeftPart(UriPartial.Authority);

            //context.Request.Url.AbsolutePath.ToString();
            return request.Url.ToString().Replace(rootUrl, "");
        }

        public static string GetUrlReferrer(HttpRequest request)
        {
            return request.UrlReferrer.IsNull() ? null : request.UrlReferrer.ToString();
        }

        public static IpInfo GetIpInfo(string ip)
        {
            string urlAddress = $"http://www.freegeoip.net/json/{ip}";
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
                        StreamReader readStream;
                        if (string.IsNullOrEmpty(response.CharacterSet))
                            readStream = new StreamReader(receiveStream ?? throw new InvalidOperationException());
                        else
                            readStream = new StreamReader(receiveStream ?? throw new InvalidOperationException(), Encoding.GetEncoding(response.CharacterSet));


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
            WebHeaderCollection headers = new WebHeaderCollection
            {
                [HttpRequestHeader.UserAgent] =
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10; rv:33.0) Gecko/20100101 Firefox/33.0"
            };
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
        public string Ip { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string MetroCode { get; set; }
        public string AreaCode { get; set; }
        public string TimeZone { get; set; }

        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("statusCode={0}\r\n", StatusCode);
            sb.AppendFormat("statusMessage={0}\r\n", StatusMessage);
            sb.AppendFormat("ipAddress ={0}\r\n", Ip);
            sb.AppendFormat("countryCode={0}\r\n", CountryCode);
            sb.AppendFormat("countryName={0}\r\n", CountryName);
            sb.AppendFormat("regionName ={0}\r\n", RegionName);
            sb.AppendFormat("cityName={0}\r\n", City);
            sb.AppendFormat("zipCode ={0}\r\n", Zipcode);
            sb.AppendFormat("latitude ={0}\r\n", Latitude);
            sb.AppendFormat("longitude={0}\r\n", Longitude);
            sb.AppendFormat("timeZone ={0}\r\n", TimeZone);

            return sb.ToString();
        }
    }
}
