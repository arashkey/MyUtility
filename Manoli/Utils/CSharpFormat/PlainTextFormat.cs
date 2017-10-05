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
    public override bool CaseSensitive => false;

      protected override string CommentRegEx => "";

      protected override string StringRegEx => "";

      protected override string Keywords => "";

      protected override string Preprocessors => "";

      private string FormatCode(string source, bool lineNumbers, bool alternate, bool embedStyleSheet, bool subCode)
    {
      StringBuilder stringBuilder1 = new StringBuilder(source);
      stringBuilder1.Replace("&", "&amp;");
      stringBuilder1.Replace("<", "&lt;");
      stringBuilder1.Replace(">", "&gt;");
      stringBuilder1.Replace("\t", string.Empty.PadRight(TabSpaces));
      source = stringBuilder1.ToString();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (embedStyleSheet)
      {
        stringBuilder2.Append("<style type=\"text/css\">\n");
        stringBuilder2.Append(GetCssString());
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
