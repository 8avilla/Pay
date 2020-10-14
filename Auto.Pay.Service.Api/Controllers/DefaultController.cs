using Microsoft.AspNetCore.Mvc;

namespace Auto.Pay.Service.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DefaultController : Controller
    {
        [HttpGet("Test")]
        public string Test()
        {
            return "Running";
        }
    }
}
