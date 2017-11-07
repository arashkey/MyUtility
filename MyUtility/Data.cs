
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using log4net;

namespace MyUtility
{
    public static class Data
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
 
        public static StringBuilder TrimEnd(this StringBuilder s, char ch)
        {
            try
            {
                while (s[s.Length - 1] == ch)
                {
                    s.Remove(s.Length - 1, 1);
                }
                return s;
            }
            catch (Exception)
            {
                return s;
            }
        }

        public static StringBuilder TrimEnd(this StringBuilder s, string str)
        {
            try
            {
                var isFound = true;

                while (isFound)
                {
                    if (s.Length < str.Length) break;

                    for (int i = 0; i < str.Length && isFound; i++)

                        if (s[s.Length - str.Length + i] != str[i]) isFound = false;

                    if (isFound) s.Remove(s.Length - str.Length, str.Length);
                }

                return s;
            }
            catch (Exception)
            {
                return s;
            }
        }

        public static long ToLong(this string s)
        {
            try
            {
                return Convert.ToInt64(s);
            }
            catch
            {
                return -1;
            }
        }
        public static int ToInt(this decimal s)
        {
            return (int)s;
        }
        public static int ToInt(this object s)
        {
            try
            {
                string data = s.ToString();
                int result = -1;
                int.TryParse(data, out result);
                return result;

            }
            catch
            {
                return -1;
            }
        }

        public static bool ToBool(this object s)
        {
            try
            {
                return Convert.ToBoolean(s);
            }
            catch
            {
                return false;
            }
        }

        public static double ToDouble(this string s)
        {
            try
            {
                return Convert.ToDouble(s);
            }
            catch
            {
                try
                {
                    return Convert.ToDouble(s,new CultureInfo("en-US"));
                }
                catch  
                {


                    try
                    {
                        return Convert.ToDouble(s, new CultureInfo("fa-IR"));
                    }
                    catch  
                    {

                        return -1;
                    }
                }
            }
        }

        public static DateTime ToDate(this object s)
        {
            try
            {
                return Convert.ToDateTime(s);
            }
            catch
            {
                return new DateTime();
            }
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNull(this object o)
        {
            return o == null;
        }

        public static bool IsNotNull(this object o)
        {
            return o != null;
        }

        public static string LeftMax(this string o, int count)
        {
            if (o.Length < count) return o;
            return o.Substring(0, count);
        }

        /// <summary>
        /// Compiled regular expression for performance.
        /// </summary>
        static readonly Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
        public static string RemoveHtml(this string o)
        {
            return _htmlRegex.Replace(o, string.Empty);
        }


        public static decimal ToDecimal(this string s)
        {
            try
            {
                return Convert.ToDecimal(s.ToString());
            }
            catch
            {
                return -1;
            }
        }

        public static string Left(this string s, int count)
        {
            return s.Substring(0, count);
        }

        public static string Right(this string s, int count)
        {
            return s.Substring(s.Length - count, count);
        }

        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name);// prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
