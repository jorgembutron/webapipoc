using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Company.Biz.WebApi.Exceptions;

namespace Company.Biz.WebApi.Middleware
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var exceptionType = exception.GetType();
            var errorResponse = new ErrorResponse
            {
                Error = new Error
                {
                    Method = context.Request.GetDisplayUrl(),
                    EventId = Guid.NewGuid().ToString(),
                    Message = string.Empty
                }
            };

            switch (exception)
            {
                case { } when exceptionType == typeof(ArgumentNullException):
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case { } when exceptionType == typeof(BusinessException):
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case { } when exceptionType == typeof(NotFoundException):
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    errorResponse.Error.Message = "Something happened on our backend.";
                    break;
            }

            errorResponse.Error.HttpStatusCode = context.Response.StatusCode;
            errorResponse.Error.Message = exception.Message;

            var textErrorResponse = JsonSerializer.Serialize(errorResponse);

            _logger.LogError(textErrorResponse);

            return context.Response.WriteAsync(textErrorResponse);
        }
    }
}
