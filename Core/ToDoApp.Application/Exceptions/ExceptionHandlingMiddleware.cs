using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace ToDoApp.Application.Exceptions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next,IHostEnvironment env)
        {
            _next = next;
            _env = env;
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
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
            //var result = JsonConvert.SerializeObject(new
            //{
            //    message = exception.Message,
            //    errorType = exception.GetType().Name,
            //    statusCode = context.Response.StatusCode
            //});
            var response = new ProblemDetails
            {
                Status = 500,
                Detail = _env.IsDevelopment() ? exception.StackTrace?.ToString() : null,
                Title = exception.Message
            };
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var result = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(result);
        }
    }
}
