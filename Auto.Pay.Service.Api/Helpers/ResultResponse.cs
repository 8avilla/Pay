using Auto.Pay.Transversal.Common;
using Microsoft.AspNet.Mvc.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Pay.Servicio.Api.Helpers
{
    public class ResultResponse : ActionResult
    {
        private readonly object _data;
        private readonly int _code;

        public ResultResponse(object data, int code) {
            _data = data;
            _code = code;
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            Response response = new Response
            {
                Data = _data
            };

            HttpResponse httpResponse = context.HttpContext.Response;
            httpResponse.StatusCode = _code;

            string json = response.ConvertJson();

            byte[] bytes = Encoding.UTF8.GetBytes(json);
            int length = bytes.Length;

            //this must be set before start writing into the stream
            httpResponse.ContentLength = length;
            httpResponse.ContentType = "application/json";

            httpResponse.Body.WriteAsync(bytes, 0, length);
            return TaskCache.CompletedTask;
        }
    }
}
