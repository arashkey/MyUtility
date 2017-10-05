// Decompiled with JetBrains decompiler
// Type: MyUtility.Banking.ParsianBank
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using log4net;
using System.Reflection;

namespace MyUtility.Banking
{
  public static class ParsianBank
  {
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    public const string PAYMENTURL = "https://pec.shaparak.ir/pecpaymentgateway/default.aspx?au=";
    public const int MAXVALIDTIME = 10;

    public static string GetStatusMessage(ParsianBank.StatusBankResult statusBankResult)
    {
      switch (statusBankResult)
      {
        case ParsianBank.StatusBankResult.SaleIsAlreadyDoneSuccessfully:
          return "عمليات قبلا با موفقيت انجام شده است";
        case ParsianBank.StatusBankResult.InvalidMerchantOrder:
          return "شماره تراکنش فروشنده درست نميباشد";
        case ParsianBank.StatusBankResult.Successful:
          return "موفق";
        case ParsianBank.StatusBankResult.PreRequest:
          return "وضعيت بلا تكليف";
        case ParsianBank.StatusBankResult.AccessViolation:
        case ParsianBank.StatusBankResult.MerchantAuthenticationFailed:
          return "پين  یا فروشنده درست نميباشد";
        case ParsianBank.StatusBankResult.IpIsWrong:
          return "آی پی سرور اشتباه است";
        default:
          return "پیام دیگری از سرور بازگشت داده شده است با کد";
      }
    }

    public static ParsianBank.StatusBankResult GetStatusType(byte status)
    {
      if (status <= 1U)
      {
        if (status != 0 && status != 1)
          goto label_4;
      }
      else
      {
        switch (status)
        {
          case 20:
          case 21:
          case 22:
          case 30:
          case 34:
            break;
          default:
            goto label_4;
        }
      }
      return (ParsianBank.StatusBankResult) status;
label_4:
      return ParsianBank.StatusBankResult.Other;
    }

    public enum StatusBankResult
    {
      Successful = 0,
      PreRequest = 1,
      AccessViolation = 20,
      MerchantAuthenticationFailed = 21,
      IpIsWrong = 22,
      SaleIsAlreadyDoneSuccessfully = 30,
      InvalidMerchantOrder = 34,
      Other = 35,
    }
  }
}
