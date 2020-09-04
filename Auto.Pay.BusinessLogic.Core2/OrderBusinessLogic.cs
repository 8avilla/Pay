using Auto.Pay.BusinessLogic.Entities;
using Auto.Pay.Persistence.Entities;
using Auto.Pay.Persistence.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Auto.Pay.BusinessLogic.Core
{
    public class OrderBusinessLogic
    {
        private readonly IUnitOfWorkPersistence _unitOfWorkInfrastructure;
        private readonly IConfiguration _configuracion;
        private readonly string _userNamePay;
        private readonly string _passwordPay;
        private readonly string _languageDefault;
        private readonly string _currencyDefault;

        public OrderBusinessLogic(IUnitOfWorkPersistence unitOfWorkInfrastructure, IConfiguration iConfig)
        {
            _unitOfWorkInfrastructure = unitOfWorkInfrastructure;
            _configuracion = iConfig;
            _userNamePay = _configuracion.GetSection("Pay:UserName").Value;
            _passwordPay = _configuracion.GetSection("Pay:Password").Value;
            _languageDefault = _configuracion.GetSection("Pay:LanguageDefault").Value;
            _currencyDefault = _configuracion.GetSection("Pay:CurrencyDefault").Value;
        }

        public ResponseStatusOrderCredibancoEBL StatusOrden(string orderCredibancoId, string language)
        {

            if ( string.IsNullOrEmpty(language) || language == "string")
            {
                language = _languageDefault;
            }

            OrderEP orderEP = _unitOfWorkInfrastructure.Order.FindFirstOrDefault<OrderEP>(o => o.OrderCredibancoId.Equals(orderCredibancoId));

            if (orderEP == null)
            {
                throw new  ArgumentException("No existe el Order Id");
            }

            string requestUri = _configuracion.GetSection("Pay:UrlStatusOrder").Value;

            using (HttpClient client = new HttpClient())
            {
                requestUri = string.Format(requestUri + "?userName={0}&password={1}&orderId={2}&language={3}", 
                    _userNamePay, _passwordPay, orderCredibancoId, language);

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

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Pay Autofinanciera");

                string urlGetPaymentGuide = _configuracion.GetSection("Pay:UrlGetPaymentGuide").Value.Trim();

                string requestUri = urlGetPaymentGuide + requestRegisterOrderCredibancoEBL.PaymentReferenceGuid;

                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                response.EnsureSuccessStatusCode();

                string responseBody = response.Content.ReadAsStringAsync().Result;

                paymentReferenceQuriiEBL = JsonConvert.DeserializeObject<PaymentReferenceQuriiEBL>(responseBody);
            }

            requestRegisterOrderCredibancoEBL.Amount= paymentReferenceQuriiEBL.Amount;
            requestRegisterOrderCredibancoEBL.UserName= _userNamePay;
            requestRegisterOrderCredibancoEBL.Password = _passwordPay;
            requestRegisterOrderCredibancoEBL.ReturnUrl = "http://localhost/guiapago/?PaymentReferenceGuid=" + requestRegisterOrderCredibancoEBL.PaymentReferenceGuid ;
            requestRegisterOrderCredibancoEBL.FailUrl = "http://localhost/guiapago/status.html?PaymentReferenceGuid=" + requestRegisterOrderCredibancoEBL.PaymentReferenceGuid;
            
            if (string.IsNullOrEmpty(requestRegisterOrderCredibancoEBL.Currency) || requestRegisterOrderCredibancoEBL.Currency == "string")
            {
                requestRegisterOrderCredibancoEBL.Currency = _currencyDefault;
            }

            if (string.IsNullOrEmpty(requestRegisterOrderCredibancoEBL.Language) || requestRegisterOrderCredibancoEBL.Language == "string")
            {
                requestRegisterOrderCredibancoEBL.Language = _languageDefault;
            }

            requestRegisterOrderCredibancoEBL.ExpirationDate = DateTime.Now.AddMinutes(int.Parse(_configuracion.GetSection("Pay:ExpirationDateMinutes").Value));
            requestRegisterOrderCredibancoEBL.IdSystem = 1;
            requestRegisterOrderCredibancoEBL.OrderSistemId = Guid.NewGuid().ToString();

            ResponseRegisterOrderCredibancoEBL responseRegisterOrderCredibancoEBL = null;

            using (HttpClient client = new HttpClient())
            {
                string urlRegisterOrderCredibanco = _configuracion.GetSection("Pay:UrlRegisterOrder").Value;

                string requestUri = string.Format(urlRegisterOrderCredibanco + "?userName={0}&password={1}&orderNumber={2}&amount={3}&currency={4}&returnUrl={5}"
                    , _userNamePay, _passwordPay, requestRegisterOrderCredibancoEBL.OrderSistemId, requestRegisterOrderCredibancoEBL.Amount.ToString() + "00", requestRegisterOrderCredibancoEBL.Currency, requestRegisterOrderCredibancoEBL.ReturnUrl);

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