// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.MshFormat
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

namespace Manoli.Utils.CSharpFormat
{
  public class MshFormat : CodeFormat
  {
    protected override string CommentRegEx => "#.*?(?=\\r|\\n)";

      protected override string StringRegEx => "@?\"\"|@?\".*?(?!\\\\).\"|''|'.*?(?!\\\\).'";

      protected override string Keywords => "function filter global script local private if else elseif for foreach in while switch continue break return default param begin process end throw trap";

      protected override string Preprocessors => "-band -bor -match -notmatch -like -notlike -eq -ne -gt -ge -lt -le -is -imatch -inotmatch -ilike -inotlike -ieq -ine -igt -ige -ilt -ile";
  }
}
