using System.Data;

namespace AnalyticsDemo.Infra.Persistence.Repository.Interfaces
{
    public interface IWriteOnlyRepository<T> where T : class
    {

        IDbConnection? DbConnection { get; }

        IDbTransaction? Transaction { get; }
        Task<int> ExecuteAsync(string sql, object param, int? commandTimeout);

        void BeginTransaction();

        void CommitChanges();

        void Rollback();
    }
}
