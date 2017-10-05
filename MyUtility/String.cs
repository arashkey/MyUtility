// Decompiled with JetBrains decompiler
// Type: MyUtility.String
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using log4net;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace MyUtility
{
  public static class String
  {
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private static readonly Random Rnd = new Random();
    private const string StrongKey = "arash.c0Se20BGeYcbuYe";
    private const string Lower = "abcdefghijklmnopqrstuvwxyz";
    private const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Number = "0123456789";
    private const string Symbol = "@#$%^&*()!?<>|";

    private static string RandomKey
    {
      get
      {
        string path = Basic.AssemblyDirectory + "\\EKey.dat";
        if (File.Exists(path))
          return "arash.c0Se20BGeYcbuYe" + File.ReadAllText(path);
        string randomString = String.GetRandomString(10);
        File.WriteAllText(path, randomString);
        return "arash.c0Se20BGeYcbuYe" + randomString;
      }
    }

    public static string GetRandomString(int count)
    {
      return String.GetRandomString(count, true, true, true, false);
    }

    public static string GetRandomString(int count, bool isLower, bool isUpper, bool isNumber, bool isSymbol)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (isUpper)
        stringBuilder2.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
      if (isLower)
        stringBuilder2.Append("abcdefghijklmnopqrstuvwxyz");
      if (isNumber)
        stringBuilder2.Append("0123456789");
      if (isSymbol)
        stringBuilder2.Append("@#$%^&*()!?<>|");
      int length = stringBuilder2.Length;
      if (length > 0)
      {
        for (int index = 0; index < (int) Convert.ToInt16(count); ++index)
          stringBuilder1.Append(stringBuilder2[String.Rnd.Next(0, length)]);
      }
      return stringBuilder1.ToString();
    }

    public static string Hash(string inputString)
    {
      return Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(inputString)));
    }

    public static string Encript(string inputString)
    {
      return String.Encript(inputString, String.RandomKey);
    }

    public static string Encript(string inputString, string key)
    {
      using (TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider())
      {
        byte[] bytes;
        using (MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider())
        {
          string s = key;
          byte[] hash = cryptoServiceProvider2.ComputeHash(Encoding.ASCII.GetBytes(s));
          cryptoServiceProvider1.Key = hash;
          cryptoServiceProvider1.Mode = CipherMode.ECB;
          bytes = Encoding.ASCII.GetBytes(inputString);
        }
        inputString = Convert.ToBase64String(cryptoServiceProvider1.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
      }
      return inputString;
    }

    public static string Decript(string inputString)
    {
      return String.Decript(inputString, String.RandomKey);
    }

    public static string Decript(string input, string key)
    {
      using (TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider())
      {
        byte[] hash;
        using (MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider())
        {
          string s = key;
          hash = cryptoServiceProvider2.ComputeHash(Encoding.ASCII.GetBytes(s));
        }
        cryptoServiceProvider1.Key = hash;
        cryptoServiceProvider1.Mode = CipherMode.ECB;
        byte[] inputBuffer = Convert.FromBase64String(input);
        try
        {
          return Encoding.ASCII.GetString(cryptoServiceProvider1.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
        }
        catch (Exception ex)
        {
          return null;
        }
      }
    }

    public static string EnNum2Fa(string EnNum)
    {
      int length = EnNum.Length;
      if (length == 0 || EnNum == null)
        return EnNum;
      string str = "";
      for (int index = 1; index < length; ++index)
      {
        char ch = EnNum[index];
        if (ch <= 57 & ch >= 48)
          ch += 'ۀ';
        str += ch.ToString();
      }
      return str;
    }

    public static string StringOrNull(this string input)
    {
      if (string.IsNullOrEmpty(input))
        return null;
      return input;
    }
  }
}
