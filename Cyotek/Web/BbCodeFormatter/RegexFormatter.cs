// Decompiled with JetBrains decompiler
// Type: Cyotek.Web.BbCodeFormatter.RegexFormatter
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using System.Text.RegularExpressions;

namespace Cyotek.Web.BbCodeFormatter
{
  internal class RegexFormatter : IHtmlFormatter
  {
    private Regex _regex;
    private string _replace;

    public RegexFormatter(string pattern, string replace)
      : this(pattern, replace, true)
    {
    }

    public RegexFormatter(string pattern, string replace, bool ignoreCase)
    {
      RegexOptions options = RegexOptions.Compiled;
      if (ignoreCase)
        options |= RegexOptions.IgnoreCase;
      this._replace = replace;
      this._regex = new Regex(pattern, options);
    }

    public virtual string Format(string data)
    {
      return this._regex.Replace(data, this._replace);
    }

    protected Regex Regex
    {
      get
      {
        return this._regex;
      }
    }

    protected string Replace
    {
      get
      {
        return this._replace;
      }
    }
  }
}
