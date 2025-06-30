using AnalyticsDemo.Application.Interfaces;
using Serilog;

namespace AnalyticsDemo.Infra.Logger
{
    public class SerilogLogger<T> : IAppLogger<T>
    {
        private readonly ILogger _logger;
        private readonly string _typeName;

        public SerilogLogger(ILogger logger)
        {
            _logger = logger.ForContext<T>();
            _typeName = typeof(T).Name;
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.Information($"[{_typeName}] {message}", args);
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            _logger.Error(ex, $"[{_typeName}] {message}", args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.Warning($"[{_typeName}] {message}", args);
        }
    }
}
