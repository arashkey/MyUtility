// Decompiled with JetBrains decompiler
// Type: Cyotek.Web.BbCodeFormatter.SearchReplaceFormatter
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

namespace Cyotek.Web.BbCodeFormatter
{
  internal class SearchReplaceFormatter : IHtmlFormatter
  {
    private string _pattern;
    private string _replace;

    public SearchReplaceFormatter(string pattern, string replace)
    {
      this._pattern = pattern;
      this._replace = replace;
    }

    public string Format(string data)
    {
      return data.Replace(this._pattern, this._replace);
    }
  }
}
