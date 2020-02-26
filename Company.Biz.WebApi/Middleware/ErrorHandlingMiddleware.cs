﻿//using Microsoft.AspNetCore.Http;
//using Newtonsoft.Json;
//using System;
//using System.Net;
//using System.Threading.Tasks;

//namespace Company.Biz.WebApi.Middleware
//{
//    public class ErrorHandlingMiddleware
//    {
//        private readonly RequestDelegate next;

//        public ErrorHandlingMiddleware(RequestDelegate next)
//        {
//            this.next = next;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            try
//            {
//                await next(context).ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
//            }
//        }

//        private static async Task HandleExceptionAsync(HttpContext context,Exception exception)
//        {
//            object errors = null;

//            switch (exception)
//            {
//                case RestException re:
//                    errors = re.Errors;
//                    context.Response.StatusCode = (int)re.Code;
//                    break;
//                case Exception e:
//                    errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
//                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//                    break;
//            }

//            context.Response.ContentType = "application/json";

//            var result = JsonConvert.SerializeObject(new
//            {
//                errors
//            });

//            await context.Response.WriteAsync(result).ConfigureAwait(false);
//        }
//    }
//}
