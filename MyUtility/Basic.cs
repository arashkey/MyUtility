// Decompiled with JetBrains decompiler
// Type: MyUtility.Basic
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using log4net;
using System.IO;
using System.Reflection;

namespace MyUtility
{
  public class Basic
  {
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private static string _assemblyDirectory;

    public static string AssemblyDirectory
    {
      get
      {
        if (Basic._assemblyDirectory == null)
          Basic._assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", ""));
        return Basic._assemblyDirectory;
      }
    }
  }
}
