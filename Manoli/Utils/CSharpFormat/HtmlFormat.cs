// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.HtmlFormat
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Manoli.Utils.CSharpFormat
{
  public class HtmlFormat : SourceFormat
  {
    private Manoli.Utils.CSharpFormat.CSharpFormat csf;
    private JavaScriptFormat jsf;
    private Regex attribRegex;

    public HtmlFormat()
    {
      this.CodeRegex = new Regex("((?<=&lt;script(?:\\s.*?)?&gt;).+?(?=&lt;/script&gt;))|(&lt;!--.*?--&gt;)|(&lt;%@.*?%&gt;|&lt;%|%&gt;)|((?<=&lt;%).*?(?=%&gt;))|((?:&lt;/?!?\\??(?!%)|(?<!%)/?&gt;)+)|((?<=&lt;/?!?\\??(?!%))[\\w\\.:-]+(?=.*&gt;))|((?<=&lt;(?!%)/?!?\\??[\\w:-]+).*?(?=(?<!%)/?&gt;))|(&amp;\\w+;)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
      this.attribRegex = new Regex("(=?\".*?\"|=?'.*?')|([\\w:-]+)", RegexOptions.Singleline);
      this.csf = new Manoli.Utils.CSharpFormat.CSharpFormat();
      this.jsf = new JavaScriptFormat();
    }

    private string AttributeMatchEval(Match match)
    {
      if (match.Groups[1].Success)
        return "<span class=\"kwrd\">" + match.ToString() + "</span>";
      if (match.Groups[2].Success)
        return "<span class=\"attr\">" + match.ToString() + "</span>";
      return match.ToString();
    }

    protected override string MatchEval(Match match)
    {
      if (match.Groups[1].Success)
      {
        match.ToString();
        return this.jsf.FormatSubCode(match.ToString());
      }
      if (match.Groups[2].Success)
      {
        StringReader stringReader = new StringReader(match.ToString());
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
      if (match.Groups[3].Success)
        return "<span class=\"asp\">" + match.ToString() + "</span>";
      if (match.Groups[4].Success)
        return this.csf.FormatSubCode(match.ToString());
      if (match.Groups[5].Success)
        return "<span class=\"kwrd\">" + match.ToString() + "</span>";
      if (match.Groups[6].Success)
        return "<span class=\"html\">" + match.ToString() + "</span>";
      if (match.Groups[7].Success)
        return this.attribRegex.Replace(match.ToString(), new MatchEvaluator(this.AttributeMatchEval));
      if (match.Groups[8].Success)
        return "<span class=\"attr\">" + match.ToString() + "</span>";
      return match.ToString();
    }
  }
}
