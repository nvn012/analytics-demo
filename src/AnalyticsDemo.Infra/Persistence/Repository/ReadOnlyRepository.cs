using AnalyticsDemo.Infra.Persistence.Repository.Interfaces;
using AnalyticsDemo.Infra.TenantRepo;
using Microsoft.Extensions.Logging;
using System.Data;
using Dapper;

namespace AnalyticsDemo.Infra.Persistence.Repository
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class
    {
        private readonly IDbConnection _dbConnection;

        public ReadOnlyRepository(IDbConnectionFactory dbConnectionFactory, ITenantProvider tenantProvider)
        {
            _dbConnection = dbConnectionFactory.CreateDBConnection(tenantProvider, Enum.ConnectionType.Read);
        }
        public IDbConnection DbConnection
        {
            get
            {
                return _dbConnection;
            }
        }

        public async Task<IEnumerable<U>> QueryAsync<U>(string sql, object? param, IDbTransaction? transaction, int? commandTimeout)
        {

            try
            {
                return await _dbConnection.QueryAsync<U>(sql, param, transaction: transaction, commandTimeout: commandTimeout);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
