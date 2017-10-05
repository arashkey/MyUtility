// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.CLikeFormat
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

namespace Manoli.Utils.CSharpFormat
{
  public abstract class CLikeFormat : CodeFormat
  {
    protected override string CommentRegEx => "/\\*.*?\\*/|//.*?(?=\\r|\\n)";

      protected override string StringRegEx => "@?\"\"|@?\".*?(?!\\\\).\"|''|'.*?(?!\\\\).'";
  }
}
