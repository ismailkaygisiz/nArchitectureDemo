using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ILoggableRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LoggerServiceBase _loggerService;

        public LoggingBehavior(IHttpContextAccessor httpContextAccessor, LoggerServiceBase loggerService)
        {
            _httpContextAccessor = httpContextAccessor;
            _loggerService = loggerService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<LogParameter> parameters = new List<LogParameter>()
            {
                new() { Type = request.GetType().Name, Value = request },
            };

            LogDetail logDetail = new LogDetail()
            {
                MethodName = next.Method.Name,
                Parameters = parameters,
                User = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "?",
            };

            _loggerService.Information(JsonSerializer.Serialize(logDetail));
            return await next();
        }
    }
}
