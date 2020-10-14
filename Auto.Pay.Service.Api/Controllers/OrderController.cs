using Microsoft.AspNetCore.Mvc;
using Auto.Pay.Servicio.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Auto.Pay.Application.Dtos;
using Auto.Pay.Application.Interfaces;

namespace Auto.Pay.Servicio.Api.Controllers
{
    [Route("[controller]")]
	[ApiController]
	[AllowAnonymous]
	public partial class OrderController : ControllerLegacy
	{
		private readonly IOrderApplication _orderApplication;
		public OrderController(IOrderApplication orderApplicatio)
		{
			_orderApplication = orderApplicatio;
		}

		[HttpPost("RegisterOrder")]
        public ActionResult RegisterOrder(RegisterOrderDTO registerOrderDto)
		{
			return SuccesOk(_orderApplication.RegisterOrder(registerOrderDto));
		}

		[HttpGet("StatusOrden")]
		public ActionResult StatusOrden(string orderCredibancoId, string businessID, string paymentReferenceGuid)
		{
			return SuccesOk(_orderApplication.StatusOrden(orderCredibancoId, businessID, paymentReferenceGuid));
		}
	}
}

