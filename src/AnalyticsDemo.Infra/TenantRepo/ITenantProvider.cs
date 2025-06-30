using AnalyticsDemo.Domain.Tenant;

namespace AnalyticsDemo.Infra.TenantRepo
{
    /// <summary>
    /// basic tenat proviser service
    /// in prod this will be hooked with claims(jwt token) and secrets manager
    /// </summary>
    public interface ITenantProvider
    {
        Tenant GetTenant();
    }
}
