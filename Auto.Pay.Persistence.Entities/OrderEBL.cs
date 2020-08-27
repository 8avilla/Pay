using Newtonsoft.Json;
using System;

namespace Auto.Pay.BusinessLogic.Entities
{
    public partial class OrderEBL : EntityBusinessLogic
    {
        [JsonProperty(PropertyName = "idSystem")]
        public int IdSystem { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "PaymentReferenceCode")]
        public string PaymentReferenceCode { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "orderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        [JsonProperty(PropertyName = "returnUrl")]
        public string ReturnUrl { get; set; }
        public string FailUrl { get; set; }
        public string Description { get; set; }
        public string PageView { get; set; }
        public string ClientId { get; set; }
        public string MerchantLogin { get; set; }
        public string JsonParams { get; set; }
        public int? SessionTimeoutSecs { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string BindingId { get; set; }
        public string Features { get; set; }
    }
}