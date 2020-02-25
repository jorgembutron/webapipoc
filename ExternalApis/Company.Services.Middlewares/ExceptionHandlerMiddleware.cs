using System;
using System.Net;
using System.Threading.Tasks;
using Company.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace Company.Services.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {



            try
            {
                await _requestDelegate.Invoke(context).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var errorResponse = new ErrorResponse()
            {
                Method = context.Request.GetDisplayUrl(),
                EventId = Guid.NewGuid().ToString(),
                Message = string.Empty
            };

            switch (exception)
            {
                case { } e when exception.GetType() == typeof(BusinessException):
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //return context.Response.WriteAsync()
                    break;
                case { } e when exception.GetType() == typeof(NotFoundException):
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResponse.Message = "Resource not found";

                    
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
