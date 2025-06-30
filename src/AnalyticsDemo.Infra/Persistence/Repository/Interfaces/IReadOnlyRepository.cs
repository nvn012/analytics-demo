using System.Data;

namespace AnalyticsDemo.Infra.Persistence.Repository.Interfaces
{
    public interface IReadOnlyRepository<T> where T : class
    {
        /// <summary>
        /// Gets the DbConnection.
        /// </summary>
        IDbConnection DbConnection { get; }

        Task<IEnumerable<U>> QueryAsync<U>(string sql, object? param, IDbTransaction? transaction, int? commandTimeout);
    }
}
