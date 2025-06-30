using System.Data;

namespace AnalyticsDemo.Infra.Persistence.Repository.Interfaces
{
    /// <summary>
    /// base read repilica for read realted repisitories.
    /// we can have base methods in it which are common to read repos.
    /// the implematation will resolve read connection string in run time
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadOnlyRepository<T> where T : class
    {
        /// <summary>
        /// Gets the DbConnection.
        /// </summary>
        IDbConnection DbConnection { get; }

        Task<IEnumerable<U>> QueryAsync<U>(string sql, object? param, IDbTransaction? transaction, int? commandTimeout);
    }
}
