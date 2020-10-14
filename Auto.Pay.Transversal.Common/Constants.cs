using System.Net.Http.Headers;

namespace Auto.Pay.Transversal.Common
{
    public static  class Constants
    {
        public static string AutofinancieraID = "26e0e553-8bb9-41b2-869a-1fddaf06e900";
        public static string FonbienesID = "6831062e-c994-4686-a989-1964b1200cbc";


        public static PaymentSettings GetPaymentSettings(string businessID) {

            switch (businessID) {
                case "26e0e553-8bb9-41b2-869a-1fddaf06e900":
                    return new PaymentSettings{
                        BusinessName = "Autofinanciera",
                        UserName = "AUTOFINANCIERA-api",
                        Password = "Auto20*"
                    };

                case "6831062e-c994-4686-a989-1964b1200cbc":
                    return new PaymentSettings
                    {
                        BusinessName = "Fonbienes",
                        UserName = "ELCTROPLAN-api",
                        Password = "[Password*1]"
                    };

                default:
                    return new PaymentSettings();
            }
        }
    }


    public class PaymentSettings
    {
        public string UserName { get; set; }
        public string BusinessName { get; set; }
        public string Password { get; set; }
        public string LanguageDefault { get => "es"; }
        public string CurrencyDefault { get => "170"; }
        public int ExpirationDateMinutes { get => 20; }


        //public string UrlRegisterOrder { get => "https://eco.credibanco.com/payment/rest/register.do"; }
        public string UrlRegisterOrder { get => "https://ecouat.credibanco.com/payment/rest/register.do"; }


        //public string UrlStatusOrder { get => "https://eco.credibanco.com/payment/rest/getOrderStatusExtended.do"; }
        public string UrlStatusOrder { get => "https://ecouat.credibanco.com/payment/rest/getOrderStatusExtended.do"; }
        public string UrlGetPaymentGuide { get => "https://tiendaautofinanciera.com/ContratoDigital/GetPaymentGuide?PaymentReferenceGuid="; }
        public string ReturnUrl { get => "https://pay.tiendaautofinanciera.com/?PaymentReferenceGuid="; }
        public string FailUrl { get => "https://pay.tiendaautofinanciera.com/status.html?PaymentReferenceGuid="; }

    }
}
