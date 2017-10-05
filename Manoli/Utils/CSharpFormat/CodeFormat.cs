// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.CodeFormat
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Manoli.Utils.CSharpFormat
{
  public abstract class CodeFormat : SourceFormat
  {
    protected abstract string Keywords { get; }

    protected virtual string Preprocessors => "";

      protected abstract string StringRegEx { get; }

    protected abstract string CommentRegEx { get; }

    public virtual bool CaseSensitive => true;

      protected CodeFormat()
    {
      string str1 = Keywords.Replace("\r\n", " ");
      Regex regex1 = new Regex("\\w+|-\\w+|#\\w+|@@\\w+|#(?:\\\\(?:s|w)(?:\\*|\\+)?\\w+)+|@\\\\w\\*+");
      string input1 = str1;
      string replacement1 = "(?<=^|\\W)$0(?=\\W)";
      string str2 = regex1.Replace(input1, replacement1);
      string preprocessors = Preprocessors;
      string replacement2 = "(?<=^|\\s)$0(?=\\s|$)";
      string str3 = regex1.Replace(preprocessors, replacement2);
      Regex regex2 = new Regex(" +");
      string input2 = str2;
      string replacement3 = "|";
      string str4 = regex2.Replace(input2, replacement3);
      string input3 = str3;
      string replacement4 = "|";
      string str5 = regex2.Replace(input3, replacement4);
      if (str5.Length == 0)
        str5 = "(?!.*)_{37}(?<!.*)";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("(");
      stringBuilder.Append(CommentRegEx);
      stringBuilder.Append(")|(");
      stringBuilder.Append(StringRegEx);
      if (str5.Length > 0)
      {
        stringBuilder.Append(")|(");
        stringBuilder.Append(str5);
      }
      stringBuilder.Append(")|(");
      stringBuilder.Append(str4);
      stringBuilder.Append(")");
      RegexOptions regexOptions = CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
      CodeRegex = new Regex(stringBuilder.ToString(), RegexOptions.Singleline | regexOptions);
    }

    protected override string MatchEval(Match match)
    {
      string s = match.ToString();
      if (s == "")
        return "";
      if (s == " ")
        return " ";
      if (match.Groups[1].Success)
      {
        StringReader stringReader = new StringReader(s);
        StringBuilder stringBuilder = new StringBuilder();
        string str;
        while ((str = stringReader.ReadLine()) != null)
        {
          if (stringBuilder.Length > 0)
            stringBuilder.Append("\n");
          stringBuilder.Append("<span class=\"rem\">");
          stringBuilder.Append(str);
          stringBuilder.Append("</span>");
        }
        return stringBuilder.ToString();
      }
      if (match.Groups[2].Success)
        return "<span class=\"str\">" + s + "</span>";
      if (match.Groups[3].Success)
        return "<span class=\"preproc\">" + s + "</span>";
      if (match.Groups[4].Success)
        return "<span class=\"kwrd\">" + s + "</span>";
      return "";
    }
  }
}
