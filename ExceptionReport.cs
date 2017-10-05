////using log4net;
//using log4net.Config;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace MyUtility
{
    public class ExceptionReport
    {
        //public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        //public const string ConfigFileName = "log4net.config";

        public static void LogConfiguration()
        {
            //Type type = typeof(ExceptionReport);
            //string path = Path.Combine(Basic.AssemblyDirectory, ConfigFileName);
            //FileInfo configFile = new FileInfo(path);
            //XmlConfigurator.ConfigureAndWatch(configFile);
            //ILog log = LogManager.GetLogger(type);
            //Console.WriteLine("Logger init :{0}", log.ToString());
        }
        public static void log(string logString, string ip = "")
        {
            log(new Exception(logString), ip);
        }
        public static void log(Exception ex, string ip = "")
        {
            //try
            //{

            //    if (Log != null)
            //        if (ip.IsNullOrEmpty())
            //            Log.Error(ex);
            //        else
            //            Log.Error("ip :" + ip, ex);
            //}
            //catch
            //{
            //}
            var file = Basic.AssemblyDirectory + @"\Error.txt";

            var message = string.Format
                (
                    "\r\n      Error:  {1} : ({2}) {0} {3} {0} {4} {0} Ip : {5} \r\n_________________\r\n",
                    "\r\n--------------\r\n",
                    ex.Message,
                    DateTime.Now,
                    ex.StackTrace,
                    ex.InnerException,
                    ip
                );
            try
            {
                File.AppendAllText(file, message);
            }
            catch (Exception)
            {
                try
                {
                    var conString = ConfigurationManager.ConnectionStrings["error"];
                    if (conString == null)
                    {
                        Console.WriteLine("error connection string = \"{0}\" not found", conString.ConnectionString);
                        return;
                    }
                    var con = new SqlConnection(conString.ToString());
                    var sql = @"INSERT INTO  Setting.Error( Message ,DateTime ,StackTrace ,InnerException ,ip)
                                VALUES  ( @Message ,@DateTime ,@StackTrace ,@InnerException ,@ip)";

                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("Message", ex.Message);
                    cmd.Parameters.AddWithValue("DateTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("StackTrace", ex.StackTrace);
                    cmd.Parameters.AddWithValue("InnerException", ex.InnerException);
                    cmd.Parameters.AddWithValue("ip", ip);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {

                }
            }
        }


    }
}
