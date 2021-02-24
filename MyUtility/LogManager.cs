using System;
using System.IO;

namespace MyUtility
{
    public static class LogManager
    {


        public static void Error(Exception ex)
        {
            var errorFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Error.txt");
            File.AppendAllText(errorFilePath, $"Error ({DateTime.Now}) :{ex.Message} : {ex.StackTrace}");
        }
    }
}
