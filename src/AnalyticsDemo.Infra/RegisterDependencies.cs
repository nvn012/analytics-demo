using AnalyticsDemo.Application.Interfaces;
using AnalyticsDemo.Infra.Logger;
using AnalyticsDemo.Infra.Persistence.Repository;
using AnalyticsDemo.Infra.Persistence.Repository.Interfaces;
using AnalyticsDemo.Infra.TenantRepo;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace AnalyticsDemo.Infra
{
    public static class RegisterDependencies
    {
        public static IServiceCollection RegisterInfraDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITenantProvider, TenantProvider>();
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<IAdMetricsReadRepository, AdMetricsReadRepository>();
            services.AddScoped<ICampaignReadRepository, CampaignReadRepository>();
            services.AddSingleton(typeof(IAppLogger<>), typeof(SerilogLogger<>));
            services.AddSingleton(Log.Logger);
            return services;
        }
    }
}
