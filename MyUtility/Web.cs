// Decompiled with JetBrains decompiler
// Type: MyUtility.Web
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using log4net;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace MyUtility
{
  public static class Web
  {
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    public static string GetIp(HttpContext request)
    {
      return MyUtility.Web.GetIp(request.Request);
    }

    public static string GetIp(HttpRequest request)
    {
      return request.ServerVariables["REMOTE_ADDR"];
    }

    public static string GetCookie(HttpContext context, string key)
    {
      if (context.Request.Cookies[key].IsNull() || context.Request.Cookies[key].Value.IsNullOrEmpty())
        return null;
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
      return Request.Url.ToString().Replace(Request.Url.GetLeftPart(UriPartial.Authority), "");
    }

    public static string GetFullUrl(HttpRequest Request)
    {
      return Request.Url.ToString();
    }

    public static string GetVirtualPath(HttpRequest Request)
    {
      string leftPart = Request.Url.GetLeftPart(UriPartial.Authority);
      return Request.Url.ToString().Replace(leftPart, "");
    }

    public static string GetUrlReferrer(HttpRequest Request)
    {
      if (!Request.UrlReferrer.IsNull())
        return Request.UrlReferrer.ToString();
      return null;
    }

    public static IpInfo GetIPInfo(string ip)
    {
      MyUtility.Web.GetDataFromUrl(string.Format("http://www.freegeoip.net/json/{0}", ip));
      return new IpInfo();
    }

    public static string GetDataFromUrl(string url)
    {
      try
      {
        string str1 = "";
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
        string str2 = "application/x-www-form-urlencoded";
        httpWebRequest.ContentType = str2;
        string str3 = ".NET Framework Example Client";
        httpWebRequest.UserAgent = str3;
        HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
          using (Stream responseStream = response.GetResponseStream())
          {
            StreamReader streamReader = response.CharacterSet == null || string.IsNullOrEmpty(response.CharacterSet) ? new StreamReader(responseStream) : new StreamReader(responseStream, Encoding.GetEncoding(response.CharacterSet));
            str1 = streamReader.ReadToEnd();
            response.Close();
            streamReader.Close();
          }
        }
        return str1;
      }
      catch (Exception ex)
      {
        MyUtility.Web.Log.Error(ex);
        return null;
      }
    }

    public static string GetHtmlFromUrl(string url)
    {
      WebClient webClient = new WebClient();
      WebHeaderCollection headerCollection1 = new WebHeaderCollection();
      headerCollection1[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10; rv:33.0) Gecko/20100101 Firefox/33.0";
      WebHeaderCollection headerCollection2 = headerCollection1;
      webClient.Headers = headerCollection2;
      string address = url;
      return webClient.DownloadString(address);
    }

    public static byte[] GetByteDataFromUrl(string remoteUri)
    {
      return new WebClient().DownloadData(remoteUri);
    }
  }
}
