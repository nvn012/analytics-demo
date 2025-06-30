namespace AnalyticsDemo.Infra.Persistence.Enum
{
    /// <summary>
    /// we are suing cqrs pattern here.
    /// we can have seprate DBs for read or write ops
    /// the framework will resolve the connection type based on the operation in runtime
    /// amd redirects query to appropriate DB
    /// </summary>
    public enum ConnectionType
    {
        Read,
        Write
    }
}
