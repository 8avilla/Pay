using Microsoft.AspNetCore.Mvc;
using Auto.Pay.Servicio.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Auto.Pay.Application.Interfaces;
using System;

namespace Auto.Pay.Servicio.Api.Controllers
{
    [Route("[controller]")]
	[ApiController]
	[AllowAnonymous]
	public partial class PaymentReferenceController : ControllerLegacy
	{
		private readonly IPaymentReferenceApplication _paymentReferenceApplication;
		public PaymentReferenceController(IPaymentReferenceApplication paymentReferenceApplication)
		{
			_paymentReferenceApplication = paymentReferenceApplication;
		}

		//[HttpPost("Add")]
  //      public ActionResult Add(string paymentReferenceCode, DateTime creationDate, int amount, string paymentReferenceObject)
		//{
		//	var g = Guid.NewGuid();

		//	return SuccesCreated(_paymentReferenceApplication.Add(paymentReferenceCode, creationDate, amount, paymentReferenceObject));
		//}
	}
}

