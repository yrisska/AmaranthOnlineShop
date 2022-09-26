using AmaranthOnlineShop.API.Middlewares.Models;
using FluentValidation;
using System.Net;

namespace AmaranthOnlineShop.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                httpContext.Response.StatusCode = e switch
                {
                    ValidationException _ => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = e.Message
                }.ToString());
            }
        }
    }
}
