// Decompiled with JetBrains decompiler
// Type: MyUtility.Date
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using log4net;
using System;
using System.Globalization;
using System.Reflection;

namespace MyUtility
{
  public static class Date
  {
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    public static string[] mountName = new string[12]
    {
      "فروردین",
      "اردیبهشت",
      "خرداد",
      "تیر",
      "مرداد",
      "شهریور",
      "مهر",
      "آبان",
      "آذر",
      "دی",
      "بهمن",
      "اسفند"
    };
    public static string[] dayName = new string[7]
    {
      "یکشنبه",
      "دوشنبه",
      "سه شنبه",
      "چهارشنبه",
      "پنجشنبه",
      "جمعه",
      "شنبه"
    };

    public static string GetPersianDate(object date)
    {
      if (date == null)
        return null;
      return Date.GetPersianDate(date.ToString().ToDate(), Date.TypeOfShowDateAndTime.JustDate);
    }

    public static string GetPersianDateWithMoreDetail(DateTime latinDate)
    {
      try
      {
        PersianCalendar persianCalendar = new PersianCalendar();
        return string.Format("{3} {2} {1} {0}", (object) persianCalendar.GetYear(latinDate), (object) Date.mountName[persianCalendar.GetMonth(latinDate) - 1], (object) persianCalendar.GetDayOfMonth(latinDate).ToString("00"), (object) Date.dayName[(int) persianCalendar.GetDayOfWeek(latinDate)]);
      }
      catch
      {
        return null;
      }
    }

    public static string GetPersianDate(DateTime latinDate, Date.TypeOfShowDateAndTime type = Date.TypeOfShowDateAndTime.JustDate)
    {
      try
      {
        PersianCalendar persianCalendar = new PersianCalendar();
        string str = persianCalendar.GetYear(latinDate).ToString() + "/" + persianCalendar.GetMonth(latinDate).ToString("00") + "/" + persianCalendar.GetDayOfMonth(latinDate).ToString("00");
        if (type == Date.TypeOfShowDateAndTime.DateAndShortTime)
          str = str + " - " + latinDate.ToShortTimeString();
        return str;
      }
      catch
      {
        return null;
      }
    }

    public static DateTime? GetLatinDate(string persianDate)
    {
      try
      {
        PersianCalendar persianCalendar = new PersianCalendar();
        string[] strArray = persianDate.Split(new char[2]
        {
          '/',
          '-'
        });
        int index1 = 0;
        int year = strArray[index1].ToInt();
        int index2 = 1;
        int month = strArray[index2].ToInt();
        int index3 = 2;
        int day = strArray[index3].ToInt();
        if (year <= 0 || month <= 0 || day <= 0)
          return new DateTime?();
        if (year < 1300)
          year += 1300;
        return new DateTime?(persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0));
      }
      catch
      {
        return new DateTime?();
      }
    }

    public static int GetAge(DateTime birthDate)
    {
      return DateTime.Now.Year - birthDate.Year;
    }

    public enum TypeOfShowDateAndTime
    {
      JustDate,
      DateAndShortTime,
    }
  }
}
