namespace AnalyticsDemo.Application.Interfaces
{
    /// <summary>
    /// generic Logger service on top of serilog for application logging
    /// We can log to file, opensearc or any iother destination 
    /// can be configured in appsettings.json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(Exception ex, string message, params object[] args);
    }
}
