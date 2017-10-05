
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace MyUtility
{
    public static class String
    {
        //private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        const string StrongKey = "arash.c0Se20BGeYcbuYe";
        static string RandomKey
        {
            get
            {
                var filePath = Basic.AssemblyDirectory + "\\" + "EKey.dat";

                if (File.Exists(filePath))
                {
                    return StrongKey + File.ReadAllText(filePath);
                }
                else
                {
                    var key = GetRandomString(10);

                    File.WriteAllText(filePath, key);

                    return StrongKey + key;
                }
            }
        }


        #region Get Random String
        private static readonly Random Rnd = new Random();

        private const string Lower = "abcdefghijklmnopqrstuvwxyz";

        private const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private const string Number = "0123456789";

        private const string Symbol = "@#$%^&*()!?<>|";

        public static string GetRandomString(int count)
        {
            return GetRandomString(count, true, true, true, false);
        }

        public static string GetRandomString(int count, bool isLower, bool isUpper, bool isNumber, bool isSymbol)
        {
            var randomString = new StringBuilder();

            var charPool = new StringBuilder();

            if (isUpper) charPool.Append(Upper);

            if (isLower) charPool.Append(Lower);

            if (isNumber) charPool.Append(Number);

            if (isSymbol) charPool.Append(Symbol);

            var len = charPool.Length;

            if (len > 0)
                for (var i = 0; i < Convert.ToInt16(count); i++)
                {
                    randomString.Append(charPool[Rnd.Next(0, len)]);
                }
            return randomString.ToString();
        }
        #endregion

        public static string Hash(string inputString)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(inputString);

            var hash = new MD5CryptoServiceProvider();

            var hashBytes = hash.ComputeHash(plainTextBytes);

            var hashValue = Convert.ToBase64String(hashBytes);

            return hashValue;
        }

        public static string Encript(string inputString)
        {
            return Encript(inputString, RandomKey);
        }

        public static string Encript(string inputString, string key)
        {
            //  byte[] encryptedData = Encoding.UTF8.GetBytes(inputString);

            using (var objDesCrypto = new TripleDESCryptoServiceProvider())
            {
                byte[] byteBuff;

                using (var objHashMd5 = new MD5CryptoServiceProvider())
                {
                    string strTempKey = key;

                    var byteHash = objHashMd5.ComputeHash(Encoding.ASCII.GetBytes(strTempKey));

                    objDesCrypto.Key = byteHash;

                    objDesCrypto.Mode = CipherMode.ECB; //CBC, CFB

                    byteBuff = Encoding.ASCII.GetBytes(inputString);
                }
                inputString = Convert.ToBase64String(objDesCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }

            return inputString;
        }

        public static string Decript(string inputString)
        {
            return Decript(inputString, RandomKey);
        }

        public static string Decript(string input, string key)
        {
            string strDecrypted;

            using (TripleDESCryptoServiceProvider objDesCrypto = new TripleDESCryptoServiceProvider())
            {
                byte[] byteHash;

                using (MD5CryptoServiceProvider objHashMd5 = new MD5CryptoServiceProvider())
                {
                    string strTempKey = key;

                    byteHash = objHashMd5.ComputeHash(Encoding.ASCII.GetBytes(strTempKey));
                }

                objDesCrypto.Key = byteHash;

                objDesCrypto.Mode = CipherMode.ECB; //CBC, CFB

                var byteBuff = Convert.FromBase64String(input);
                try
                {
                    strDecrypted = Encoding.ASCII.GetString(objDesCrypto.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return strDecrypted;
        }

        public static string EnNum2Fa(string enNum)
        {
            var nLen = enNum.Length;

            if (nLen == 0)
            {
                return enNum;
            }
            var sFrStr = "";
            for (int i = 1; i < nLen; i++)
            {
                char ch = enNum[i];
                if (ch <= 57 & ch >= 48)
                {
                    ch = ((char)(ch + 1728));
                }
                sFrStr += ch;

            }

            return sFrStr;

        }

        public static string StringOrNull(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            return input;
        }
    }
}
