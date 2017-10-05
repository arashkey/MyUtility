// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.JavaScriptFormat
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

namespace Manoli.Utils.CSharpFormat
{
  public class JavaScriptFormat : CLikeFormat
  {
    protected override string Keywords => "var function abstract as base bool break byte case catch char checked class const continue date debugger decimal default delegate do double else enum event explicit extern false finally fixed float for foreach goto if implicit in int interface internal is lock long namespace new null object operator out override params private protected public readonly ref return sbyte sealed short sizeof stackalloc static string struct switch this throw true try typeof uint ulong unchecked unsafe ushort using virtual void while";

      protected override string Preprocessors => "@\\w*";
  }
}
