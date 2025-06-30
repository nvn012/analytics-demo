using System.Data;

namespace AnalyticsDemo.Infra.Persistence.Repository.Interfaces
{
    /// <summary>
    /// base repository for write related repositories.
    /// it also supports transaction management, if we have multiplewries we can
    /// pass transaction from top to bottem
    /// created this repo if tomorow we have to extend out api to create ads/campeigns etc
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
