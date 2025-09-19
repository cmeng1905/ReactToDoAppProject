using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace ToDoApp.Application.Exceptions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };

            //var result = exception switch
            //{
            //    ValidationException => JsonConvert.SerializeObject(new ErrorDto
            //    {
            //        Errors = new List<string> { exception.Message }
            //    }),
            //    _ => JsonConvert.SerializeObject(new
            //    {
            //        message = exception.Message,
            //        errorType = exception.GetType().Name,
            //        statusCode = context.Response.StatusCode
            //    })
            //};
            var result = JsonConvert.SerializeObject(new
            {
                message = exception.Message,
                errorType = exception.GetType().Name,
                statusCode = context.Response.StatusCode
            });

            return context.Response.WriteAsync(result);
        }
    }
}
