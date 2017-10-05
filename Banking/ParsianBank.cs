namespace MyUtility.Banking
{
    public static class ParsianBank
    {
        //private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public const string PAYMENTURL = "https://www.pecco24.com:27635/pecpaymentgateway/default.aspx?au=";
        public const string PAYMENTURL = "https://pec.shaparak.ir/pecpaymentgateway/default.aspx?au=";

        public const int MAXVALIDTIME = 10;

        public enum StatusBankResult
        {
            Successful = 0, PreRequest = 1, AccessViolation = 20, MerchantAuthenticationFailed = 21, IpIsWrong = 22, SaleIsAlreadyDoneSuccessfully = 30,
            InvalidMerchantOrder = 34
                //, PinNotCorrect, OperationDoneBefore, TrasactionNumberNotCorrect
                , Other
        };


        public static string GetStatusMessage(StatusBankResult statusBankResult)
        {
            switch (statusBankResult)
            {
                case StatusBankResult.Successful:
                    return "موفق";

                case StatusBankResult.PreRequest:
                    return "وضعيت بلا تكليف";

                case StatusBankResult.IpIsWrong :
                    return "آی پی سرور اشتباه است";

                case StatusBankResult.AccessViolation:
                case StatusBankResult.MerchantAuthenticationFailed:
                    return "پين  یا فروشنده درست نميباشد";

                case StatusBankResult.SaleIsAlreadyDoneSuccessfully:
                    return "عمليات قبلا با موفقيت انجام شده است";

                case StatusBankResult.InvalidMerchantOrder:
                    return "شماره تراکنش فروشنده درست نميباشد";

                case StatusBankResult.Other:
                    break;
            }
            return "پیام دیگری از سرور بازگشت داده شده است با کد";
        }

        public static StatusBankResult GetStatusType(byte status)
        {
            switch (status)
            {
                case 0:
                case 1:
                case 20:
                case 21:
                case 22:
                case 30:
                case 34:
                    return (StatusBankResult)status;

            }
            return StatusBankResult.Other;
        }
    }
}
