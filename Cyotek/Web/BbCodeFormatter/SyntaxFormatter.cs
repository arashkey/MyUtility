// Decompiled with JetBrains decompiler
// Type: Cyotek.Web.BbCodeFormatter.SyntaxFormatter
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using Manoli.Utils.CSharpFormat;
using System.Text.RegularExpressions;
using System.Web;

namespace Cyotek.Web.BbCodeFormatter
{
  internal class SyntaxFormatter : RegexFormatter
  {
    private readonly SourceFormat _formatter;

    public SyntaxFormatter(SourceFormat formatter, string pattern, string replace)
      : this(formatter, pattern, replace, true)
    {
    }

    public SyntaxFormatter(SourceFormat formatter, string pattern, string replace, bool ignoreCase)
      : base(pattern, replace, ignoreCase)
    {
      _formatter = formatter;
    }

    public override string Format(string data)
    {
      return Regex.Replace(data, new MatchEvaluator(SyntaxMatcher));
    }

    private string SyntaxMatcher(Match match)
    {
      return match.Result(string.Format(Replace, _formatter.FormatCode(HttpUtility.HtmlDecode(match.Groups[1].Value))));
    }
  }
}
