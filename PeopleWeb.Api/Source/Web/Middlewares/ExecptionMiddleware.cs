using System.Net;
using PeopleWeb.Api.Source.Domain.Execptions;

namespace PeopleWeb.Api.Source.Web.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
{
    private readonly IHostEnvironment _env = env;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro não tratado: {Message}", ex.Message);
            
            var statusCode = ex switch
            {
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                KeyNotFoundException => HttpStatusCode.NotFound,
                ValidationException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };
            
            var message = ex switch
            {
                UnauthorizedAccessException => "Acesso não autorizado.",
                KeyNotFoundException => "Recurso não encontrado.",
                ValidationException => ex.Message,
                _ => "Erro interno no servidor."
            };

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = new
            {
                success = false,
                message = message,
                // details = _env.IsDevelopment() ? ex.ToString() : null
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}