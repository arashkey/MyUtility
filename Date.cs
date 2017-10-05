using System;
using System.Globalization;

namespace MyUtility
{
    public static class Date
    {
        //private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public enum TypeOfShowDateAndTime { JustDate, DateAndShortTime };
        public static string[] mountName = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        public static string[] dayName = { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
        public static string GetPersianDate(object date)
        {
            if (date == null)
                return null;
            return GetPersianDate(date.ToString().ToDate());
        }
        public static string GetPersianDateWithMoreDetail(DateTime latinDate)
        {
            try
            {
                var persianCalendar = new PersianCalendar();
                //شنبه 21 ارديبهشت 1392
                string d = string.Format
                  (
                    "{3} {2} {1} {0}",
                    persianCalendar.GetYear(latinDate),//1392
                    mountName[persianCalendar.GetMonth(latinDate) - 1],//اردیبهشت
                    persianCalendar.GetDayOfMonth(latinDate).ToString("00"),//21
                    dayName[(int)persianCalendar.GetDayOfWeek(latinDate)] //شنبه
                  );
                
                return d;
            }
            catch
            {
                return null;
            }
        }

        public static string GetPersianDate(DateTime latinDate, TypeOfShowDateAndTime type = TypeOfShowDateAndTime.JustDate)
        {
            try
            {
                var persianCalendar = new PersianCalendar();

                string d= persianCalendar.GetYear(latinDate) + "/" + persianCalendar.GetMonth(latinDate).ToString("00") + "/" +
                       persianCalendar.GetDayOfMonth(latinDate).ToString("00");
                if (type == TypeOfShowDateAndTime.DateAndShortTime)
                {
                    d += " - " + latinDate.ToShortTimeString();
                }
                return d;
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
                PersianCalendar p = new PersianCalendar();

                string[] parts = persianDate.Split('/', '-');

                int year = parts[0].ToInt(), mount = parts[1].ToInt(), day = parts[2].ToInt();
                if (year <= 0 || mount <= 0 || day <= 0)
                    return null;
                if (year < 1300) year += 1300;

                return p.ToDateTime(year, mount, day, 0, 0, 0, 0);

                /*
                var str = persianDate.Split('/');

                if (str[0].Length == 2) str[0] = "13" + str[0];

                if (str[1].Length == 1) str[1] = "0" + str[1];

                if (str[2].Length == 1) str[2] = "0" + str[2];

                var persianCulture = new CultureInfo("fa-IR");

                var persianDateTime = DateTime.ParseExact(string.Join("/", str), "yyyy/MM/dd", persianCulture);

                var jc = new PersianCalendar();

                return jc.ToDateTime(persianDateTime.Year, persianDateTime.Month, persianDateTime.Day,
                                     persianDateTime.Hour, persianDateTime.Minute, persianDateTime.Second,
                                     persianDateTime.Millisecond);
                  */
            }
            catch
            {
                return null;
            }
        }

        public static int GetAge(DateTime birthDate)
        {
            return DateTime.Now.Year - birthDate.Year;
        }
    }
}