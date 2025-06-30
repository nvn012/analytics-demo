using AnalyticsDemo.Application.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace AnalyticsDemo.Application
{
    public static class RegisterDependencies
    {
        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(RegisterDependencies).Assembly));

            services.AddScoped<IClaimsAccessor, ClaimsAccessor>();

            return services;
        }
    }
}
