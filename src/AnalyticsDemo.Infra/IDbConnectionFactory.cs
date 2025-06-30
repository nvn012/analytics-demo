using AnalyticsDemo.Infra.Persistence.Enum;
using AnalyticsDemo.Infra.TenantRepo;
using System.Data;

namespace AnalyticsDemo.Infra
{
    public interface IDbConnectionFactory
    {
        /// <summary>
        /// service to create db connection based on tenant and connection type
        /// </summary>
        /// <param name="tenantProvider"></param>
        /// <param name="connectionType"></param>
        /// <returns></returns>
        IDbConnection CreateDBConnection(ITenantProvider tenantProvider, ConnectionType connectionType);
    }
}
