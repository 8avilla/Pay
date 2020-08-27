using Microsoft.AspNetCore.Mvc;

namespace Auto.Pay.Servicio.Api.Helpers
{
    public class ControllerLegacy : ControllerBase
    {

        [NonAction]
        public static ResultResponse SuccesOk(object obj)
        {
            return new ResultResponse(obj, 200);
        }

        [NonAction]
        public static ResultResponse SuccesCreated(object obj)
        {
            return new ResultResponse(obj, 201);
        }

        [NonAction]
        public static ResultResponse SuccesModified(object obj)
        {
            return new ResultResponse(obj, 204);
        }

        [NonAction]
        public static ResultResponse SuccesRemoved(object obj)
        {
            return new ResultResponse(obj, 204);
        }
    }
}
