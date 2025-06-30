using AnalyticsDemo.Infra.Persistence.Enum;
using AnalyticsDemo.Infra.TenantRepo;
using System.Data;

namespace AnalyticsDemo.Infra
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDBConnection(ITenantProvider tenantProvider, ConnectionType connectionType);
    }
}
