using Auto.Pay.BusinessLogic.Entities;
using Auto.Pay.Persistence.Entities;
using Auto.Pay.Persistence.Interface;
using Auto.Pay.Transversal.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auto.Pay.BusinessLogic.Core
{
    public class PaymentReferenceBusinessLogic
    {
        private readonly IUnitOfWorkPersistence _unitOfWorkInfrastructure;
        private readonly IConfiguration _configuracion;

        public PaymentReferenceBusinessLogic(IUnitOfWorkPersistence unitOfWorkInfrastructure, IConfiguration iConfig)
        {
            _unitOfWorkInfrastructure = unitOfWorkInfrastructure;
            _configuracion = iConfig;
        }

        public PaymentReferenceQuriiEBL Add(string paymentReferenceCode, DateTime creationDate, int amount, string paymentReferenceObject)
        {

            PaymentReferenceEP paymentReference = _unitOfWorkInfrastructure.PaymentReference.Add(new PaymentReferenceEP()
            {
                PaymentReferenceCode = paymentReferenceCode,
                CreationDate = creationDate,
                Amount = amount,
                PaymentReferenceObject = paymentReferenceObject
            });

            _unitOfWorkInfrastructure.SaveChanges();

            return paymentReference.MapTo<PaymentReferenceQuriiEBL>();
        }
    }
}