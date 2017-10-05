// Decompiled with JetBrains decompiler
// Type: Cyotek.Web.BbCodeFormatter.LineBreaksFormatter
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using System;
using System.Collections.Generic;

namespace Cyotek.Web.BbCodeFormatter
{
  internal class LineBreaksFormatter : IHtmlFormatter
  {
    private readonly string[] _exclusionCodes;
    private readonly List<IHtmlFormatter> _formatters;

    public LineBreaksFormatter(string[] exclusionCodes)
    {
      _exclusionCodes = exclusionCodes;
        _formatters = new List<IHtmlFormatter>
        {
            new SearchReplaceFormatter("\r", ""),
            new SearchReplaceFormatter("\n\n", "</p><p>"),
            new SearchReplaceFormatter("\n", "<br />")
        };
    }

    public string Format(string data)
    {
      int num = 0;
      int nextBlockStart;
      do
      {
          nextBlockStart = GetNextBlockStart(num, data, out var matchedTag);
        string data1 = nextBlockStart == -1 ? (num == -1 || num >= data.Length ? null : data.Substring(num)) : data.Substring(num, nextBlockStart - num);
        if (data1 != null)
        {
          int length = data1.Length;
          foreach (IHtmlFormatter formatter in _formatters)
            data1 = formatter.Format(data1);
          if (nextBlockStart != -1)
          {
            data = data.Substring(0, num) + data1 + data.Substring(nextBlockStart);
            nextBlockStart += data1.Length - length;
            num = GetBlockEnd(nextBlockStart, data, matchedTag);
          }
          else
            data = data.Substring(0, num) + data1;
        }
      }
      while (nextBlockStart != -1);
      return data;
    }

    private int GetBlockEnd(int startingPosition, string data, string tag)
    {
      string str = $"[/{tag}]";
      int num = data.IndexOf(str, startingPosition, StringComparison.InvariantCultureIgnoreCase);
      if (num == -1)
        num = data.Length;
      return num;
    }

    private int GetNextBlockStart(int startingPosition, string data, out string matchedTag)
    {
      int num1 = -1;
      matchedTag = null;
      foreach (string exclusionCode in _exclusionCodes)
      {
        string str = $"[{exclusionCode}]";
        int num2 = data.IndexOf(str, startingPosition, StringComparison.InvariantCultureIgnoreCase);
        if (num2 > -1 && (num2 < num1 || num1 == -1))
        {
          matchedTag = exclusionCode;
          num1 = num2;
        }
      }
      return num1;
    }
  }
}
