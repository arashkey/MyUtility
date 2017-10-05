// Decompiled with JetBrains decompiler
// Type: MyUtility.ExtendStringBuilder
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using log4net;
using System;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace MyUtility
{
  public static class ExtendStringBuilder
  {
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    public static int IndexOf(this StringBuilder sb, string value, int startIndex = 0, bool ignoreCase = false)
    {
      if (sb == null)
        throw new ArgumentNullException(nameof (sb));
      if (startIndex == -1)
        startIndex = sb.Length - 1;
      if (startIndex >= sb.Length)
        throw new ArgumentException("startIndex must be lower than sb.Lengh");
      int length = value.Length;
      int num = sb.Length - length + 1;
      if (ignoreCase)
      {
        for (int index1 = startIndex; index1 < num; ++index1)
        {
          if (char.ToLower(sb[index1]) == char.ToLower(value[0]))
          {
            int index2 = 1;
            while (index2 < length && char.ToLower(sb[index1 + index2]) == char.ToLower(value[index2]))
              ++index2;
            if (index2 == length)
              return index1;
          }
        }
        return -1;
      }
      for (int index1 = startIndex; index1 < num; ++index1)
      {
        if (sb[index1] == value[0])
        {
          int index2 = 1;
          while (index2 < length && sb[index1 + index2] == value[index2])
            ++index2;
          if (index2 == length)
            return index1;
        }
      }
      return -1;
    }

    public static int LastIndexOf(this StringBuilder sb, char find, bool ignoreCase = false, int startIndex = 0, CultureInfo culture = null)
    {
      if (sb == null)
        throw new ArgumentNullException(nameof (sb));
      if (startIndex == -1)
        startIndex = sb.Length - 1;
      if (startIndex >= sb.Length)
        throw new ArgumentException("startIndex must be lower than sb.Lengh");
      if (culture == null)
        culture = CultureInfo.InvariantCulture;
      int num = -1;
      if (ignoreCase)
        find = char.ToUpper(find, culture);
      for (int index = startIndex; index >= 0; --index)
      {
        char ch = ignoreCase ? char.ToUpper(sb[index], culture) : sb[index];
        if (find == ch)
        {
          num = index;
          break;
        }
      }
      return num;
    }

    public static int LastIndexOf(this StringBuilder sb, string find, bool ignoreCase = false, int startIndex = 0, CultureInfo culture = null)
    {
      if (sb == null || sb.Length == 0)
        throw new ArgumentNullException(nameof (sb));
      if (startIndex == 0)
        startIndex = sb.Length - find.Length;
      if (startIndex >= sb.Length)
        throw new ArgumentException("startIndex must be lower than sb.Lengh");
      if (culture == null)
        culture = CultureInfo.InvariantCulture;
      int length = sb.Length;
      if (ignoreCase)
        find = find.ToUpper(culture);
      for (int index1 = startIndex; index1 >= 0; --index1)
      {
        char ch = ignoreCase ? char.ToUpper(sb[index1], culture) : sb[index1];
        if (find[0] == ch)
        {
          int index2 = 0;
          while (index2 < find.Length && find[index2] == sb[index1 + index2])
            ++index2;
          if (index2 == find.Length)
            return index1;
        }
      }
      return -1;
    }

    public static int IndexOf(StringBuilder sb, char ch)
    {
      int index = -1;
      while (++index < sb.Length)
      {
        if (sb[index] == ch)
          return index;
      }
      return -1;
    }

    public static StringBuilder Substring(this StringBuilder str, int startIndex, int len = -1)
    {
      if (startIndex < 0)
        throw new ArgumentOutOfRangeException("The start index are smaller than 0!");
      if (startIndex >= str.Length)
        throw new ArgumentOutOfRangeException("The start index is bigger than string length!");
      StringBuilder stringBuilder = new StringBuilder();
      if (len == -1)
        len = str.Length;
      for (int index = startIndex; index < len; ++index)
        stringBuilder.Append(str[index]);
      return stringBuilder;
    }
  }
}
