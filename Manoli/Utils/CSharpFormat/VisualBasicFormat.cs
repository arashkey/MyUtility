// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.VisualBasicFormat
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

namespace Manoli.Utils.CSharpFormat
{
  public class VisualBasicFormat : CodeFormat
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
        return "(?:'|REM\\s).*?(?=\\r|\\n)";
      }
    }

    protected override string StringRegEx
    {
      get
      {
        return "\"\"|\".*?\"|''";
      }
    }

    protected override string Keywords
    {
      get
      {
        return "AddHandler AddressOf AndAlso Alias And Ansi As Assembly Auto Boolean ByRef Byte ByVal Call Case Catch CBool CByte CChar CDate CDec CDbl Char CInt Class CLng CObj Const CShort CSng CStr CType Date Decimal Declare Default Delegate Dim DirectCast Do Double Each Else ElseIf End EndIf Enum Erase Error Event Exit False Finally For Friend Function Get GetType Global GoSub GoTo Handles If Implements Imports In Inherits Integer Interface Is Let Lib Like Long Loop Me Mod Module MustInherit MustOverride MyBase MyClass Namespace Narrowing New Next Not Nothing NotInheritable NotOverridable Object On Operator Option Optional Or OrElse Overloads Overridable Overrides ParamArray Preserve Private Property Protected Public RaiseEvent ReadOnly ReDim REM RemoveHandler Resume Return Select Set Shadows Shared Short Single Static Step Stop String Structure Sub SyncLock Then Throw To True Try TryCast TypeOf Unicode Until Variant Wend When While With Widening WithEvents WriteOnly Xor";
      }
    }

    protected override string Preprocessors
    {
      get
      {
        return "#\\s*Const #\\s*If #\\s*Else #\\s*ElseIf #\\s*End\\s+If #\\s*ExternalSource #\\s*End\\s+ExternalSource #\\s*Region #\\s*End\\s+Region";
      }
    }
  }
}
