using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Core.CrossCuttingConcerns.Exceptions.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpExceptionHandler _httpExceptionHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LoggerServiceBase _loggerService;

        public ExceptionMiddleware(RequestDelegate next, HttpExceptionHandler httpExceptionHandler, IHttpContextAccessor httpContextAccessor, LoggerServiceBase loggerService)
        {
            _next = next;
            _httpExceptionHandler = httpExceptionHandler;
            _httpContextAccessor = httpContextAccessor;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            await LogException(context, exception);

            context.Response.ContentType = "application/json";
            _httpExceptionHandler.Response = context.Response;
            await _httpExceptionHandler.HandleExceptionAsync(exception);
        }

        private Task LogException(HttpContext context, Exception exception)
        {
            List<LogParameter> parameters = new List<LogParameter>()
            {
                new() { Type = context.GetType().Name, Value = exception.ToString() },
            };

            ExceptionLogDetail logDetail = new ExceptionLogDetail()
            {
                MethodName = _next.Method.Name,
                Parameters = parameters,
                ExceptionMessage = exception.Message,
                User = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "?",
            };

            _loggerService.Error(JsonSerializer.Serialize(logDetail));

            return Task.CompletedTask;
        }
    }
}
