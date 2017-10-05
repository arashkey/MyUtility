// Decompiled with JetBrains decompiler
// Type: Cyotek.Web.BbCodeFormatter.PlainTextProcessor
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using System.Collections.Generic;

namespace Cyotek.Web.BbCodeFormatter
{
  public static class PlainTextProcessor
  {
    private static readonly List<IHtmlFormatter> _formatters = new List<IHtmlFormatter>();

    static PlainTextProcessor()
    {
      _formatters.Add(new SearchReplaceFormatter("\r", ""));
      _formatters.Add(new SearchReplaceFormatter("\n\n", "</p><p>"));
      _formatters.Add(new SearchReplaceFormatter("\n", "<br />"));
    }

    public static string Format(string data)
    {
      foreach (IHtmlFormatter formatter in _formatters)
        data = formatter.Format(data);
      return "<p>" + data + "</p>";
    }
  }
}
