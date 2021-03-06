﻿// Decompiled with JetBrains decompiler
// Type: Cyotek.Web.BbCodeFormatter.RegexFormatter
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using System.Text.RegularExpressions;

namespace Cyotek.Web.BbCodeFormatter
{
  internal class RegexFormatter : IHtmlFormatter
  {
    private readonly Regex _regex;
    private readonly string _replace;

    public RegexFormatter(string pattern, string replace)
      : this(pattern, replace, true)
    {
    }

    public RegexFormatter(string pattern, string replace, bool ignoreCase)
    {
      RegexOptions options = RegexOptions.Compiled;
      if (ignoreCase)
        options |= RegexOptions.IgnoreCase;
      _replace = replace;
      _regex = new Regex(pattern, options);
    }

    public virtual string Format(string data)
    {
      return _regex.Replace(data, _replace);
    }

    protected Regex Regex => _regex;

      protected string Replace => _replace;
  }
}
