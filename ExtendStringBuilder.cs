using System;
using System.Globalization;
using System.Text;

namespace MyUtility
{
    public static class ExtendStringBuilder
    {
        //private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Returns the index of the start of the contents in a StringBuilder
        /// </summary>        
        /// <param name="value">The string to find</param>
        /// <param name="startIndex">The starting index.</param>
        /// <param name="ignoreCase">if set to <c>true</c> it will ignore case</param>
        /// <returns></returns>
        public static int IndexOf(this StringBuilder sb, string value, int startIndex = 0, bool ignoreCase = false)
        {
            if (sb == null) throw new ArgumentNullException("sb");
            if (startIndex == -1) startIndex = sb.Length - 1;
            if (startIndex >= sb.Length) throw new ArgumentException("startIndex must be lower than sb.Lengh");
            int index;
            int length = value.Length;
            int maxSearchLength = (sb.Length - length) + 1;

            if (ignoreCase)
            {
                for (int i = startIndex; i < maxSearchLength; ++i)
                {
                    if (Char.ToLower(sb[i]) == Char.ToLower(value[0]))
                    {
                        index = 1;
                        while ((index < length) && (Char.ToLower(sb[i + index]) == Char.ToLower(value[index])))
                            ++index;

                        if (index == length)
                            return i;
                    }
                }

                return -1;
            }

            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (sb[i] == value[0])
                {
                    index = 1;
                    while ((index < length) && (sb[i + index] == value[index]))
                        ++index;

                    if (index == length)
                        return i;
                }
            }

            return -1;
        }

        public static int LastIndexOf(this StringBuilder sb, char find, bool ignoreCase = false, int startIndex = 0, CultureInfo culture = null)
        {
            if (sb == null) throw new ArgumentNullException("sb");
            if (startIndex == -1) startIndex = sb.Length - 1;
            if (startIndex >= sb.Length) throw new ArgumentException("startIndex must be lower than sb.Lengh");
            if (culture == null) culture = CultureInfo.InvariantCulture;

            int lastIndex = -1;
            if (ignoreCase) find = Char.ToUpper(find, culture);
            char c;
            for (int i = startIndex; i >= 0; i--)
            {
                c = ignoreCase ? Char.ToUpper(sb[i], culture) : (sb[i]);
                if (find == c)
                {
                    lastIndex = i;
                    break;
                }
            }
            return lastIndex;
        }
        public static int LastIndexOf(this StringBuilder sb, string find, bool ignoreCase = false, int startIndex = 0, CultureInfo culture = null)
        {
            if (sb == null || sb.Length == 0) throw new ArgumentNullException("sb");
            if (startIndex == 0) startIndex = sb.Length - find.Length;
            if (startIndex >= sb.Length) throw new ArgumentException("startIndex must be lower than sb.Lengh");
            if (culture == null) culture = CultureInfo.InvariantCulture;
            int len = sb.Length;

            if (ignoreCase) find = find.ToUpper(culture);
            char c;
            int j = 0;
            for (int i = startIndex; i >= 0; i--)
            {
                c = ignoreCase ? Char.ToUpper(sb[i], culture) : (sb[i]);
                if (find[0] == c)
                {
                    j = 0;
                    while (j < find.Length && find[j] == sb[i + j])
                    {
                        j++;
                    }
                    if (j == find.Length)
                        return i;
                }
            }
            return -1;
        }
        public static int IndexOf(StringBuilder sb, char ch)
        {
            int intVal1 = -1;

            while (++intVal1 < sb.Length)
            {
                if (sb[intVal1] == ch)
                {
                    return intVal1;
                }
            }
            return -1;
        }

        public static StringBuilder Substring(this StringBuilder str, int startIndex, int len = -1)
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(
                "The start index are smaller than 0!");
            }

            if (startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException(
                "The start index is bigger than string length!");
            }

            StringBuilder sb = new StringBuilder();
            if (len == -1)
            {
                len = str.Length;
            }
            for (int i = startIndex; i < len; i++)
            {
                sb.Append(str[i]);
            }

            return sb;
        }

    }
}
