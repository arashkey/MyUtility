// Decompiled with JetBrains decompiler
// Type: MyUtility.Number2String
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using log4net;
using System.Reflection;

namespace MyUtility
{
  public static class Number2String
  {
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private static readonly string[] yakan = new string[10]
    {
      "صفر",
      "یک",
      "دو",
      "سه",
      "چهار",
      "پنج",
      "شش",
      "هفت",
      "هشت",
      "نه"
    };
    private static readonly string[] dahgan = new string[10]
    {
      "",
      "",
      "بیست",
      "سی",
      "چهل",
      "پنجاه",
      "شصت",
      "هفتاد",
      "هشتاد",
      "نود"
    };
    private static readonly string[] dahyek = new string[10]
    {
      "ده",
      "یازده",
      "دوازده",
      "سیزده",
      "چهارده",
      "پانزده",
      "شانزده",
      "هفده",
      "هجده",
      "نوزده"
    };
    private static readonly string[] sadgan = new string[10]
    {
      "",
      "یکصد",
      "دویست",
      "سیصد",
      "چهارصد",
      "پانصد",
      "ششصد",
      "هفتصد",
      "هشتصد",
      "نهصد"
    };
    private static readonly string[] basex = new string[5]
    {
      "",
      "هزار",
      "میلیون",
      "میلیارد",
      "تریلیون"
    };

    private static string getnum3(int num3)
    {
      string str1 = "";
      int num = num3 % 100;
      int index1 = num3 / 100;
      if (index1 != 0)
        str1 = Number2String.sadgan[index1] + " و ";
      string str2;
      if (num >= 10 && num <= 19)
      {
        str2 = str1 + Number2String.dahyek[num - 10];
      }
      else
      {
        int index2 = num / 10;
        if (index2 != 0)
          str1 = str1 + Number2String.dahgan[index2] + " و ";
        int index3 = num % 10;
        if (index3 != 0)
          str1 = str1 + Number2String.yakan[index3] + " و ";
        str2 = str1.Substring(0, str1.Length - 3);
      }
      return str2;
    }

    public static string Num2Str(string snum)
    {
      string str = "";
      if (snum == "")
        return "صفر";
      if (snum == "0")
        return Number2String.yakan[0];
      snum = snum.PadLeft(((snum.Length - 1) / 3 + 1) * 3, '0');
      int num = snum.Length / 3 - 1;
      for (int index = 0; index <= num; ++index)
      {
        int num3 = int.Parse(snum.Substring(index * 3, 3));
        if (num3 != 0)
          str = str + Number2String.getnum3(num3) + " " + Number2String.basex[num - index] + " و ";
      }
      return str.Substring(0, str.Length - 3);
    }
  }
}
