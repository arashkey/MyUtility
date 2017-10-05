// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.CSharpFormat
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

namespace Manoli.Utils.CSharpFormat
{
  public class CSharpFormat : CLikeFormat
  {
    public static SourceFormat Create(SourceLanguages Language)
    {
      if (Language == SourceLanguages.CSharp)
        return new Manoli.Utils.CSharpFormat.CSharpFormat();
      if (Language == SourceLanguages.Html)
        return new HtmlFormat();
      if (Language == SourceLanguages.VisualBasic)
        return new VisualBasicFormat();
      if (Language == SourceLanguages.FoxPro)
        return new FoxProFormat();
      if (Language == SourceLanguages.TSql)
        return new TsqlFormat();
      if (Language == SourceLanguages.JavaScript)
        return new JavaScriptFormat();
      if (Language == SourceLanguages.Monad)
        return new MshFormat();
      return new PlainTextFormat();
    }

    public static SourceFormat Create(string Language)
    {
      Language = Language.ToLower();
      if (Language == "c#" || Language == "csharp")
        return Manoli.Utils.CSharpFormat.CSharpFormat.Create(SourceLanguages.CSharp);
      if (Language == "html" || Language == "xml")
        return Manoli.Utils.CSharpFormat.CSharpFormat.Create(SourceLanguages.Html);
      if (Language == "javascript" || Language == "jscript")
        return Manoli.Utils.CSharpFormat.CSharpFormat.Create(SourceLanguages.JavaScript);
      if (Language == "vb" || Language == "vb.net" || (Language == "visualbasic" || Language == "visual basic"))
        return Manoli.Utils.CSharpFormat.CSharpFormat.Create(SourceLanguages.VisualBasic);
      if (Language == "sql" || Language == "tsql")
        return Manoli.Utils.CSharpFormat.CSharpFormat.Create(SourceLanguages.TSql);
      if (Language == "fox" || Language == "vfp" || Language == "foxpro")
        return Manoli.Utils.CSharpFormat.CSharpFormat.Create(SourceLanguages.FoxPro);
      return Manoli.Utils.CSharpFormat.CSharpFormat.Create(SourceLanguages.PlainText);
    }

    protected override string Keywords
    {
      get
      {
        return "abstract as base bool break byte case catch char \r\nchecked class const continue decimal default delegate do double else\r\nenum event explicit extern false finally fixed float for foreach goto \r\nif implicit in int into interface internal is lock long namespace new null\r\nobject operator out override partial params private protected public readonly\r\nref return sbyte sealed select short sizeof stackalloc static string struct\r\nswitch this throw true try typeof uint ulong unchecked unsafe ushort\r\nusing value var virtual void volatile where while yield";
      }
    }

    protected override string Preprocessors
    {
      get
      {
        return "#if #else #elif #endif #define #undef #warning #error #line #region #endregion #pragma";
      }
    }
  }
}
