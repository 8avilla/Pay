using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
