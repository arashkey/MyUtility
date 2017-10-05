// Decompiled with JetBrains decompiler
// Type: MyUtility.IpInfo
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using System;
using System.Text;

namespace MyUtility
{
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
      StringBuilder stringBuilder = new StringBuilder();
      string format1 = "statusCode={0}\r\n";
      string statusCode = this.statusCode;
      stringBuilder.AppendFormat(format1, statusCode);
      string format2 = "statusMessage={0}\r\n";
      string statusMessage = this.statusMessage;
      stringBuilder.AppendFormat(format2, statusMessage);
      string format3 = "ipAddress ={0}\r\n";
      string ip = this.ip;
      stringBuilder.AppendFormat(format3, ip);
      string format4 = "countryCode={0}\r\n";
      string countryCode = this.country_code;
      stringBuilder.AppendFormat(format4, countryCode);
      string format5 = "countryName={0}\r\n";
      string countryName = this.country_name;
      stringBuilder.AppendFormat(format5, countryName);
      string format6 = "regionName ={0}\r\n";
      string regionName = this.region_name;
      stringBuilder.AppendFormat(format6, regionName);
      string format7 = "cityName={0}\r\n";
      string city = this.city;
      stringBuilder.AppendFormat(format7, city);
      string format8 = "zipCode ={0}\r\n";
      string zipcode = this.zipcode;
      stringBuilder.AppendFormat(format8, zipcode);
      string format9 = "latitude ={0}\r\n";
      // ISSUE: variable of a boxed type
       stringBuilder.AppendFormat(format9,   latitude);
      string format10 = "longitude={0}\r\n";
      // ISSUE: variable of a boxed type
      var longitude = (ValueType) this.longitude;
      stringBuilder.AppendFormat(format10, longitude);
      string format11 = "timeZone ={0}\r\n";
      string timeZone = this.timeZone;
      stringBuilder.AppendFormat(format11, timeZone);
      return stringBuilder.ToString();
    }
  }
}
