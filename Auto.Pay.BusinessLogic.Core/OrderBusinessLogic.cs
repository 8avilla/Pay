using Auto.Pay.BusinessLogic.Entities;
using Auto.Pay.Persistence.Entities;
using Auto.Pay.Persistence.Interface;
using Auto.Pay.Transversal.Mapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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

        public ResponseStatusOrderEBL StatusOrden(string orderId, string paymentReference, string language)
        {

            if ( string.IsNullOrEmpty(language) || language == "string")
            {
                language = _languageDefault;
            }

            string requestUri = _configuracion.GetSection("Pay:UrlStatusOrder").Value;

            using (HttpClient client = new HttpClient())
            {
                requestUri = string.Format(requestUri + "?userName={0}&password={1}&orderId={2}&orderNumber={3}&language={4}"
                    , _userNamePay, _passwordPay, orderId, paymentReference, language);

                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;

                ResponseStatusOrderEBL responseStatusOrder = JsonConvert.DeserializeObject<ResponseStatusOrderEBL>(responseBody);

                
                return responseStatusOrder;
            }

        }
        public ResponseRegisterOrderEBL RegisterOrder(OrderEBL order)
        {
            string userNamePay = _configuracion.GetSection("Pay:UserName").Value;
            string passwordPay = _configuracion.GetSection("Pay:Password").Value;


            //PaymentReferenceEP paymentReferenceEP = _unitOfWorkInfrastructure.PaymentReference.FindSingleBy<PaymentReferenceEP>(p => p.PaymentReferenceCode == order.PaymentReferenceCode);
            PaymentReferenceEP paymentReferenceEP = _unitOfWorkInfrastructure.PaymentReference.GetById(2);

            if (paymentReferenceEP == null)
            {
                throw new ArgumentNullException("No se encuentra la referencia");
            }

            order.Amount= paymentReferenceEP.Amount;
            order.UserName= userNamePay;
            order.Password = passwordPay;
            order.ReturnUrl = "http://localhost/guiapago/";
            order.FailUrl = "http://localhost/guiapago/status.html";
            
            if (string.IsNullOrEmpty(order.Currency) || order.Currency == "string")
            {
                order.Currency = _currencyDefault;
            }

            if (string.IsNullOrEmpty(order.Language) || order.Language == "string")
            {
                order.Language = _languageDefault;
            }

            order.ExpirationDate = DateTime.Now.AddDays(int.Parse(_configuracion.GetSection("Pay:ExpirationDateDays").Value));
            order.PageView = null;
            order.MerchantLogin = null;
            order.JsonParams = null;
            order.SessionTimeoutSecs = null;
            order.OrderNumber = Guid.NewGuid().ToString();

            string requestUri = _configuracion.GetSection("Pay:UrlRegisterOrder").Value;

            using (HttpClient client = new HttpClient())
            {
                requestUri = string.Format(requestUri + "?userName={0}&password={1}&orderNumber={2}&amount={3}&currency={4}&returnUrl={5}"
                    , userNamePay, passwordPay, order.OrderNumber, order.Amount, order.Currency, order.ReturnUrl);
               
                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                response.EnsureSuccessStatusCode();

                string responseBody = response.Content.ReadAsStringAsync().Result;

                ResponseRegisterOrderEBL responseRegisterOrder = JsonConvert.DeserializeObject<ResponseRegisterOrderEBL>(responseBody);

                OrderEP orderEP = order.MapTo<OrderEP>();

                orderEP.PaymentFromUrlCredibanco = responseRegisterOrder.FormUrl;
                orderEP.OrderCredibancoId = responseRegisterOrder.OrderId;
                orderEP.PaymentStatus = responseRegisterOrder.ErrorCode;
                orderEP.DescriptionPaymentStatus = responseRegisterOrder.ErrorMessage;

                _unitOfWorkInfrastructure.Order.Add(orderEP);
                _unitOfWorkInfrastructure.SaveChanges();

                return responseRegisterOrder;
            }
        }

    }
}