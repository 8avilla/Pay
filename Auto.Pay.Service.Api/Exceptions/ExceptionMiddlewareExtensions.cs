using Auto.Pay.Transversal.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Auto.Pay.Servicio.Api.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger _logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        _logger.LogError($"message: {contextFeature.Error.Message}, ipUser: {context.Connection.RemoteIpAddress}, idUser: {context.User.Identity.Name}, uri: {context.Request.Path.Value} ,  methodHttp: {context.Request.Method} , controller:, userIsAutenticated: {context.User.Identity.IsAuthenticated.ToString()}");
                        
                        await context.Response.WriteAsync(new Response
                        {
                            Data = null,
                            Success = false,
                            ErrorDetails = new ErrorDetails
                            {
                                Message = contextFeature.Error.Message,
                                StackTrace = contextFeature.Error.StackTrace,
                                StatusCode = context.Response.StatusCode
                            }
                        }.ConvertJson());
                    }
                });
            });
        }

    }
}
