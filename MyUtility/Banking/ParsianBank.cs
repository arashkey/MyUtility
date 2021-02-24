// Decompiled with JetBrains decompiler
// Type: MyUtility.Banking.ParsianBank
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using System.Reflection;

namespace MyUtility.Banking
{
    public static class ParsianBank
    {
        public const string PAYMENTURL = "https://pec.shaparak.ir/pecpaymentgateway/default.aspx?au=";
        public const int MAXVALIDTIME = 10;

        public static string GetStatusMessage(StatusBankResult statusBankResult)
        {
            switch (statusBankResult)
            {
                case StatusBankResult.SaleIsAlreadyDoneSuccessfully:
                    return "عمليات قبلا با موفقيت انجام شده است";
                case StatusBankResult.InvalidMerchantOrder:
                    return "شماره تراکنش فروشنده درست نميباشد";
                case StatusBankResult.Successful:
                    return "موفق";
                case StatusBankResult.PreRequest:
                    return "وضعيت بلا تكليف";
                case StatusBankResult.AccessViolation:
                case StatusBankResult.MerchantAuthenticationFailed:
                    return "پين  یا فروشنده درست نميباشد";
                case StatusBankResult.IpIsWrong:
                    return "آی پی سرور اشتباه است";
                default:
                    return "پیام دیگری از سرور بازگشت داده شده است با کد";
            }
        }

        public static StatusBankResult GetStatusType(byte status)
        {
            if (status <= 1U)
            {
                if (status != 0 && status != 1)
                    return (StatusBankResult)status;
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
                        return StatusBankResult.Other;
                }
            }
            return (StatusBankResult)status;
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
