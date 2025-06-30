using AnalyticsDemo.Infra.Persistence.Repository.Interfaces;
using AnalyticsDemo.Infra.TenantRepo;
using Dapper;
using System.Data;

namespace AnalyticsDemo.Infra.Persistence.Repository
{
    public class WriteOnlyRepository<T> : IWriteOnlyRepository<T> where T : class
    {
        protected IDbConnection connection { get; set; }
        protected IDbTransaction transaction { get; set; }

        public WriteOnlyRepository(IDbConnectionFactory dbConnectionFactory, ITenantProvider tenantProvider)
        {
            if (dbConnectionFactory == null) throw new ArgumentNullException(nameof(dbConnectionFactory));
            connection = dbConnectionFactory.CreateDBConnection(tenantProvider, Enum.ConnectionType.Write);
        }

        public IDbConnection DbConnection
        {
            get
            {
                return connection;
            }
        }

        public IDbTransaction Transaction { get { return transaction; } }

        public async Task<int> ExecuteAsync(string sql, object param,
            int? commandTimeout)
        {
            try
            {
                return await connection.ExecuteAsync(sql, param, transaction, commandTimeout);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BeginTransaction()
        {
            if (transaction != null)
            {
                return;
            }
            if (connection.State == ConnectionState.Closed) connection.Open();
            transaction = connection.BeginTransaction();
        }

        public void CommitChanges()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Rollback()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction.Dispose();
                transaction = null;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
