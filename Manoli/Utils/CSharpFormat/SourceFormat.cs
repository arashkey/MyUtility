// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.SourceFormat
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Manoli.Utils.CSharpFormat
{
  public abstract class SourceFormat
  {
    private byte _tabSpaces;
    private bool _lineNumbers;
    private bool _alternate;
    private bool _embedStyleSheet;
    private Regex codeRegex;

    protected SourceFormat()
    {
      this._tabSpaces = 4;
      this._lineNumbers = false;
      this._alternate = false;
      this._embedStyleSheet = false;
    }

    public byte TabSpaces
    {
      get
      {
        return this._tabSpaces;
      }
      set
      {
        this._tabSpaces = value;
      }
    }

    public bool LineNumbers
    {
      get
      {
        return this._lineNumbers;
      }
      set
      {
        this._lineNumbers = value;
      }
    }

    public bool Alternate
    {
      get
      {
        return this._alternate;
      }
      set
      {
        this._alternate = value;
      }
    }

    public bool EmbedStyleSheet
    {
      get
      {
        return this._embedStyleSheet;
      }
      set
      {
        this._embedStyleSheet = value;
      }
    }

    public string FormatCode(Stream source)
    {
      StreamReader streamReader = new StreamReader(source);
      string end = streamReader.ReadToEnd();
      streamReader.Close();
      return this.FormatCode(end, this._lineNumbers, this._alternate, this._embedStyleSheet, false);
    }

    public string FormatCode(string source)
    {
      return this.FormatCode(source, this._lineNumbers, this._alternate, this._embedStyleSheet, false);
    }

    public string FormatSubCode(string source)
    {
      return this.FormatCode(source, false, false, false, true);
    }

    public static Stream GetCssStream()
    {
      return Assembly.GetExecutingAssembly().GetManifestResourceStream("Manoli.Utils.CSharpFormat.csharp.css");
    }

    public static string GetCssString()
    {
      return new StreamReader(SourceFormat.GetCssStream()).ReadToEnd();
    }

    protected Regex CodeRegex
    {
      get
      {
        return this.codeRegex;
      }
      set
      {
        this.codeRegex = value;
      }
    }

    protected abstract string MatchEval(Match match);

    private string FormatCode(string source, bool lineNumbers, bool alternate, bool embedStyleSheet, bool subCode)
    {
      StringBuilder stringBuilder1 = new StringBuilder(source);
      if (!subCode)
      {
        stringBuilder1.Replace("&", "&amp;");
        stringBuilder1.Replace("<", "&lt;");
        stringBuilder1.Replace(">", "&gt;");
        stringBuilder1.Replace("\t", string.Empty.PadRight(this._tabSpaces));
      }
      source = this.codeRegex.Replace(stringBuilder1.ToString(), new MatchEvaluator(this.MatchEval));
      StringBuilder stringBuilder2 = new StringBuilder();
      if (embedStyleSheet)
      {
        stringBuilder2.Append("<style type=\"text/css\">\n");
        stringBuilder2.Append(SourceFormat.GetCssString());
        stringBuilder2.Append("</style>\n");
      }
      if (lineNumbers | alternate)
      {
        if (!subCode)
          stringBuilder2.Append("<div class=\"csharpcode\">\n");
        StringReader stringReader = new StringReader(source);
        int num1 = 0;
        string str1 = "    ";
        string str2;
        while ((str2 = stringReader.ReadLine()) != null)
        {
          ++num1;
          if (alternate && num1 % 2 == 1)
            stringBuilder2.Append("<pre class=\"alt\">");
          else
            stringBuilder2.Append("<pre>");
          if (lineNumbers)
          {
            int num2 = (int) Math.Log10(num1);
            stringBuilder2.Append("<span class=\"lnum\">" + str1.Substring(0, 3 - num2) + num1.ToString() + ":  </span>");
          }
          if (str2.Length == 0)
            stringBuilder2.Append("&nbsp;");
          else
            stringBuilder2.Append(str2);
          stringBuilder2.Append("</pre>\n");
        }
        stringReader.Close();
        if (!subCode)
          stringBuilder2.Append("</div>");
      }
      else
      {
        if (!subCode)
          stringBuilder2.Append("<pre class=\"csharpcode\">");
        stringBuilder2.Append(source);
        if (!subCode)
          stringBuilder2.Append("</pre>");
      }
      return stringBuilder2.ToString();
    }
  }
}
