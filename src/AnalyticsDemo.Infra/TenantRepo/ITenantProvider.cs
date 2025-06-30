using AnalyticsDemo.Domain.Tenant;

namespace AnalyticsDemo.Infra.TenantRepo
{
    public interface ITenantProvider
    {
        Tenant GetTenant();
    }
}
