using Auto.Pay.BusinessLogic.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auto.Pay.Application.Dtos
{
    public class RegisterOrderDTO : EntityDTO
    {
        [JsonProperty(PropertyName = "idSystem")]
        public int IdSystem { get; set; }

        [JsonProperty(PropertyName = "paymentReference")]
        public string PaymentReference { get; set; }

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


    public static class RegisterOrderDtoExtensions
    {

        public static OrderEBL ConvertToEntity(this RegisterOrderDTO registerOrderDTO)
        {
            if (registerOrderDTO == null)
            {
                return null;
            }

            return new OrderEBL
            {
                IdSystem = registerOrderDTO.IdSystem,
                BindingId = registerOrderDTO.BindingId,
                OrderNumber = registerOrderDTO.PaymentReference,
                Amount = registerOrderDTO.Amount,
                Currency = registerOrderDTO.Currency,
                Language = registerOrderDTO.Language,
                ExpirationDate = registerOrderDTO.ExpirationDate,
                SessionTimeoutSecs = registerOrderDTO.SessionTimeoutSecs,
                ClientId = registerOrderDTO.ClientId,
                Description = registerOrderDTO.Description,
                FailUrl = registerOrderDTO.FailUrl,
                ReturnUrl = registerOrderDTO.ReturnUrl,
                Features = registerOrderDTO.Features,
                JsonParams = registerOrderDTO.JsonParams,
                MerchantLogin = registerOrderDTO.MerchantLogin,
                PageView = registerOrderDTO.PageView
            };
        }

        public static IEnumerable<OrderEBL> ConvertToEntity(this IEnumerable<RegisterOrderDTO> entities)
        {
            return entities?.Select(x => x.ConvertToEntity()).ToList();
        }

    }
}
