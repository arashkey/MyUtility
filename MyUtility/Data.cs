// Decompiled with JetBrains decompiler
// Type: MyUtility.Data
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MyUtility
{
  public static class Data
  {
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

    public static StringBuilder TrimEnd(this StringBuilder s, char ch)
    {
      try
      {
        while (s[s.Length - 1] == ch)
          s.Remove(s.Length - 1, 1);
        return s;
      }
      catch (Exception ex)
      {
        return s;
      }
    }

    public static StringBuilder TrimEnd(this StringBuilder s, string str)
    {
      try
      {
        bool flag = true;
        while (flag && s.Length >= str.Length)
        {
          for (int index = 0; index < str.Length & flag; ++index)
          {
            if (s[s.Length - str.Length + index] != str[index])
              flag = false;
          }
          if (flag)
            s.Remove(s.Length - str.Length, str.Length);
        }
        return s;
      }
      catch (Exception ex)
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

    public static int ToInt(this Decimal s)
    {
      return (int) s;
    }

    public static int ToInt(this object s)
    {
      try
      {
        string s1 = s.ToString();
        int result = -1;
        int.TryParse(s1, out result);
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
        return -1.0;
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
      if (o.Length < count)
        return o;
      return o.Substring(0, count);
    }

    public static string RemoveHtml(this string o)
    {
      return MyUtility.Data._htmlRegex.Replace(o, string.Empty);
    }

    public static Decimal ToDecimal(this string s)
    {
      try
      {
        return Convert.ToDecimal(s.ToString());
      }
      catch
      {
        return Decimal.MinusOne;
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
      return listToClone.Select<T, T>(item => (T) item.Clone()).ToList<T>();
    }

    public static DataTable ToDataTable<T>(this IList<T> data)
    {
      PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof (T));
      DataTable dataTable = new DataTable();
      for (int index = 0; index < properties.Count; ++index)
      {
        PropertyDescriptor propertyDescriptor = properties[index];
        dataTable.Columns.Add(propertyDescriptor.Name);
      }
      object[] objArray = new object[properties.Count];
      foreach (T obj in data)
      {
        for (int index = 0; index < objArray.Length; ++index)
          objArray[index] = properties[index].GetValue(obj);
        dataTable.Rows.Add(objArray);
      }
      return dataTable;
    }
  }
}
