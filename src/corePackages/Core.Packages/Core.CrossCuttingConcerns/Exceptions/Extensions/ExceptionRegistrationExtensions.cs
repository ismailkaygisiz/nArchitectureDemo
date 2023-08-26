using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Core.CrossCuttingConcerns.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.CrossCuttingConcerns.Exceptions.Extensions
{
    public static class ExceptionRegistrationExtensions
    {
        public static IServiceCollection AddExceptionHandlers(this IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(ExceptionHandler), (s, t) => serviceLifetime switch
            {
                ServiceLifetime.Singleton => s.AddSingleton(t),
                ServiceLifetime.Scoped => s.AddScoped(t),
                ServiceLifetime.Transient => s.AddTransient(t),
                _ => throw new NotImplementedException(),
            });
            return services;
        }
    }
}
