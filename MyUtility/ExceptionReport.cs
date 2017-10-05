// Decompiled with JetBrains decompiler
// Type: MyUtility.ExceptionReport
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using log4net;
using log4net.Config;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace MyUtility
{
  public class ExceptionReport
  {
    public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    public const string ConfigFileName = "log4net.config";

    public static void LogConfiguration()
    {
      Type type = typeof (ExceptionReport);
      XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(Basic.AssemblyDirectory, "log4net.config")));
      Console.WriteLine("Logger init :{0}", LogManager.GetLogger(type).ToString());
    }

    public static void log(Exception ex, string ip = "")
    {
      if (ip.IsNullOrEmpty())
        ExceptionReport.Log.Error(ex);
      else
        ExceptionReport.Log.Error("ip :" + ip, ex);
      string path = Basic.AssemblyDirectory + "\\Error.txt";
      string contents = string.Format("\r\n      Error:  {1} : ({2}) {0} {3} {0} {4} {0} Ip : {5} \r\n_________________\r\n", (object) "\r\n--------------\r\n", (object) ex.Message, (object) DateTime.Now, (object) ex.StackTrace, (object) ex.InnerException, (object) ip);
      try
      {
        File.AppendAllText(path, contents);
      }
      catch (Exception ex1)
      {
        try
        {
          ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["error"];
          if (connectionString == null)
          {
            Console.WriteLine("error connection string = \"{0}\" not found", connectionString.ConnectionString);
          }
          else
          {
            SqlConnection connection = new SqlConnection(connectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO  Setting.Error( Message ,DateTime ,StackTrace ,InnerException ,ip)\r\n                                VALUES  ( @Message ,@DateTime ,@StackTrace ,@InnerException ,@ip)", connection);
            sqlCommand.Parameters.AddWithValue("Message", ex.Message);
            sqlCommand.Parameters.AddWithValue("DateTime", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("StackTrace", ex.StackTrace);
            sqlCommand.Parameters.AddWithValue("InnerException", ex.InnerException);
            sqlCommand.Parameters.AddWithValue(nameof (ip), ip);
            connection.Open();
            sqlCommand.ExecuteNonQuery();
            connection.Close();
          }
        }
        catch (Exception ex2)
        {
        }
      }
    }
  }
}
