using System.IO;
using System.Reflection;

namespace MyUtility
{
    public class Basic
    {
        //private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static string _assemblyDirectory;

        public static string AssemblyDirectory
        {
            get
            {
              if (_assemblyDirectory == null)
                {

                    string codeBase = Assembly.GetExecutingAssembly().CodeBase;

                    string path = codeBase.Replace("file:///", "");

                    _assemblyDirectory = Path.GetDirectoryName(path);
                }
                return _assemblyDirectory;
            }
        }

     
    }
}
