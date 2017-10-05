// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.PlainTextFormat
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using System.Text;

namespace Manoli.Utils.CSharpFormat
{
  public class PlainTextFormat : CodeFormat
  {
    public override bool CaseSensitive
    {
      get
      {
        return false;
      }
    }

    protected override string CommentRegEx
    {
      get
      {
        return "";
      }
    }

    protected override string StringRegEx
    {
      get
      {
        return "";
      }
    }

    protected override string Keywords
    {
      get
      {
        return "";
      }
    }

    protected override string Preprocessors
    {
      get
      {
        return "";
      }
    }

    private string FormatCode(string source, bool lineNumbers, bool alternate, bool embedStyleSheet, bool subCode)
    {
      StringBuilder stringBuilder1 = new StringBuilder(source);
      stringBuilder1.Replace("&", "&amp;");
      stringBuilder1.Replace("<", "&lt;");
      stringBuilder1.Replace(">", "&gt;");
      stringBuilder1.Replace("\t", string.Empty.PadRight(this.TabSpaces));
      source = stringBuilder1.ToString();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (embedStyleSheet)
      {
        stringBuilder2.Append("<style type=\"text/css\">\n");
        stringBuilder2.Append(SourceFormat.GetCssString());
        stringBuilder2.Append("</style>\n");
      }
      if (!subCode)
        stringBuilder2.Append("<pre class=\"csharpcode\">");
      stringBuilder2.Append(source);
      if (!subCode)
        stringBuilder2.Append("</pre>");
      return stringBuilder2.ToString();
    }
  }
}
