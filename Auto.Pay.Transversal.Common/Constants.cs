using System.Net.Http.Headers;

namespace Auto.Pay.Transversal.Common
{
    public static  class Constants
    {
        public static string AutofinancieraID = "26e0e553-8bb9-41b2-869a-1fddaf06e900";
        public static string FonbienesID = "6831062e-c994-4686-a989-1964b1200cbc";


        public static CredibanCoSetting GetPaymentSettings(string businessID) {

            switch (businessID) {
                case "26e0e553-8bb9-41b2-869a-1fddaf06e900":
                    return new CredibanCoSetting{
                        BusinessName = "Autofinanciera",
                        UserName = "AUTOFINANCIERA-api",
                        Password = "Auto20*"
                    };

                case "6831062e-c994-4686-a989-1964b1200cbc":
                    return new CredibanCoSetting
                    {
                        BusinessName = "Fonbienes",
                        UserName = "ELCTROPLAN-api",
                        Password = "[Password*1]"
                    };

                default:
                    return new CredibanCoSetting();
            }
        }
    }


    public class CredibanCoSetting
    {
        public string UserName { get; set; }
        public string BusinessName { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public string LanguageDefault { get; set; }
        public string CurrencyDefault { get; set; }
        public int ExpirationDateMinutes { get; set; }
        public string UrlRegisterOrder { get; set; }
        public string UrlStatusOrder { get; set; }
        public string UrlGetPaymentGuide { get; set; }
        public string ReturnUrl { get; set; }
        public string FailUrl { get; set; }
    }
}
