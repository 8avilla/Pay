using Auto.Pay.BusinessLogic.Entities;
using Auto.Pay.Persistence.Entities;
using Auto.Pay.Persistence.Interface;
using Auto.Pay.Transversal.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace Auto.Pay.BusinessLogic.Core
{
    public class OrderBusinessLogic
    {
        private readonly IUnitOfWorkPersistence _unitOfWorkInfrastructure;
        private readonly IConfiguration _configuracion;

        public OrderBusinessLogic(IUnitOfWorkPersistence unitOfWorkInfrastructure, IConfiguration iConfig)
        {
            _unitOfWorkInfrastructure = unitOfWorkInfrastructure;
            _configuracion = iConfig;
        }

        public ResponseStatusOrderCredibancoEBL StatusOrden(string orderCredibancoId, string businessID, string paymentReferenceGuid)
        {
            PaymentSettings paymentSetting = Constants.GetPaymentSettings(businessID);

            //if ( string.IsNullOrEmpty(language) || language == "string")
            //{
            //    language = paymentSetting.LanguageDefault;
            //}

            OrderEP orderEP = _unitOfWorkInfrastructure.Order.FindFirstOrDefault<OrderEP>(o => o.OrderCredibancoId.Equals(orderCredibancoId));

            if (orderEP == null)
            {
                throw new  ArgumentException("No existe el Order Id");
            }

            using (HttpClient client = new HttpClient())
            {
                string requestUri = string.Format(paymentSetting.UrlStatusOrder + "?userName={0}&password={1}&orderId={2}&language={3}",
                    paymentSetting.UserName, paymentSetting.Password, orderCredibancoId, paymentSetting.LanguageDefault);

                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;

                ResponseStatusOrderCredibancoEBL responseStatusOrder = JsonConvert.DeserializeObject<ResponseStatusOrderCredibancoEBL>(responseBody);

                orderEP.ResponseOrdersStatusObject = JsonConvert.SerializeObject(responseStatusOrder);
                orderEP.AmountPaid = int.Parse(responseStatusOrder.Amount);
                orderEP.PaymentStatus = int.Parse(responseStatusOrder.ErrorCode);
                orderEP.DescriptionPaymentStatus = responseStatusOrder.ErrorMessage;

                _unitOfWorkInfrastructure.Order.Update(orderEP);
                _unitOfWorkInfrastructure.SaveChanges();

                return responseStatusOrder;
            }

        }
        public ResponseRegisterOrderCredibancoEBL RegisterOrder(RequestRegisterOrderCredibancoEBL requestRegisterOrderCredibancoEBL)
        {
            PaymentReferenceQuriiEBL paymentReferenceQuriiEBL = null;

            PaymentSettings paymentSetting = Constants.GetPaymentSettings(requestRegisterOrderCredibancoEBL.BusinessID);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Pay " + paymentSetting.BusinessName);

                string requestUri = paymentSetting.UrlGetPaymentGuide.Trim() + requestRegisterOrderCredibancoEBL.PaymentReferenceGuid;
                //requestUri = "http://dummy.restapiexample.com/api/v1/employees";
                //requestUri = "https://pay.tiendaautofinanciera.com/default/test";

                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                response.EnsureSuccessStatusCode();

                string responseBody = response.Content.ReadAsStringAsync().Result;

                //return new ResponseRegisterOrderCredibancoEBL {
                //    ErrorMessage = responseBody
                //};

                paymentReferenceQuriiEBL = JsonConvert.DeserializeObject<PaymentReferenceQuriiEBL>(responseBody);
            }

            requestRegisterOrderCredibancoEBL.Amount= paymentReferenceQuriiEBL.Amount;
            requestRegisterOrderCredibancoEBL.UserName= paymentSetting.UserName;
            requestRegisterOrderCredibancoEBL.Password = paymentSetting.Password;
            requestRegisterOrderCredibancoEBL.ReturnUrl = paymentSetting.ReturnUrl + requestRegisterOrderCredibancoEBL.PaymentReferenceGuid + "&businessID=" + requestRegisterOrderCredibancoEBL.BusinessID;
            requestRegisterOrderCredibancoEBL.FailUrl = paymentSetting.FailUrl + requestRegisterOrderCredibancoEBL.PaymentReferenceGuid + "&businessID=" + requestRegisterOrderCredibancoEBL.BusinessID;

            if (string.IsNullOrEmpty(requestRegisterOrderCredibancoEBL.Currency) || requestRegisterOrderCredibancoEBL.Currency == "string")
            {
                requestRegisterOrderCredibancoEBL.Currency = paymentSetting.CurrencyDefault;
            }

            if (string.IsNullOrEmpty(requestRegisterOrderCredibancoEBL.Language) || requestRegisterOrderCredibancoEBL.Language == "string")
            {
                requestRegisterOrderCredibancoEBL.Language = paymentSetting.LanguageDefault;
            }

            requestRegisterOrderCredibancoEBL.ExpirationDate = DateTime.Now.AddMinutes(paymentSetting.ExpirationDateMinutes);
            requestRegisterOrderCredibancoEBL.IdSystem = 1;
            requestRegisterOrderCredibancoEBL.OrderSistemId = DateTime.Now.ToString().Trim().Replace(".","").Replace("/", "").Replace(":", "").Replace(" ", "").Replace("a", "").Replace("m", "").Replace("p", "");
            Random random = new Random();
            requestRegisterOrderCredibancoEBL.OrderSistemId += random.Next(1, 60000000);
            //Regex regex = new Regex(@"/($[0-9,]+(.[0-9]{2})?)/");
            //Match h = regex.Match(DateTime.Now.ToString().Trim());

            ResponseRegisterOrderCredibancoEBL responseRegisterOrderCredibancoEBL = null;

            using (HttpClient client = new HttpClient())
            {
                string requestUri = string.Format(paymentSetting.UrlRegisterOrder + "?userName={0}&password={1}&orderNumber={2}&amount={3}&currency={4}&returnUrl={5}&failUrl={6}"
                    , paymentSetting.UserName, paymentSetting.Password, requestRegisterOrderCredibancoEBL.OrderSistemId, requestRegisterOrderCredibancoEBL.Amount.ToString() + "00",
                    requestRegisterOrderCredibancoEBL.Currency, requestRegisterOrderCredibancoEBL.ReturnUrl, requestRegisterOrderCredibancoEBL.FailUrl);

                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                response.EnsureSuccessStatusCode();

                string responseBody = response.Content.ReadAsStringAsync().Result;

                responseRegisterOrderCredibancoEBL = JsonConvert.DeserializeObject<ResponseRegisterOrderCredibancoEBL>(responseBody);
            }

            OrderEP orderEP = new OrderEP()
            {
                PaymentReferenceGuid = requestRegisterOrderCredibancoEBL.PaymentReferenceGuid,
                Amount = requestRegisterOrderCredibancoEBL.Amount,
                CreationDate = DateTime.Now,
                OrderCredibancoId = responseRegisterOrderCredibancoEBL.OrderId,
                RequestRegisterOrderObject = JsonConvert.SerializeObject(requestRegisterOrderCredibancoEBL),
                ResponseRegisterOrderObject = JsonConvert.SerializeObject(responseRegisterOrderCredibancoEBL)
            };

            _unitOfWorkInfrastructure.Order.Add(orderEP);
            _unitOfWorkInfrastructure.SaveChanges();

            return responseRegisterOrderCredibancoEBL;
        }

    }
}