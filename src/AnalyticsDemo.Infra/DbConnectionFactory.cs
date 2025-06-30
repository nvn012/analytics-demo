using AnalyticsDemo.Infra.Persistence.Enum;
using AnalyticsDemo.Infra.TenantRepo;
using Npgsql;
using System.Data;

namespace AnalyticsDemo.Infra
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        protected IDbConnection? connection { get; set; }
        public DbConnectionFactory()
        {
            
        }
        public IDbConnection CreateDBConnection(ITenantProvider tenantProvider, ConnectionType connectionType)
        {
            try
            {
                if (tenantProvider != null)
                {
                    var tenant = tenantProvider.GetTenant();
                    var connectionString = (connectionType == ConnectionType.Read ? tenant.ReadConnectionString 
                        : tenant.WriteConnectionString);
                    connection = new NpgsqlConnection();
                    connection.ConnectionString = connectionString;
                    return connection;
                }
                else
                {
                    throw new ArgumentNullException(nameof(tenantProvider));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
