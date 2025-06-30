using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;

namespace AnalyticsDemo.Application.Interfaces
{
    /// <summary>
    /// repositry for ad related db operations
    /// </summary>
    public interface IAdMetricsReadRepository
    {
        Task<long> GetAdClicksAsync(Guid campaignID, Guid AdId, TimeSpan? granularity, CancellationToken cancellationToken);
        Task<long> GetImpressionAsync(Guid campaignID, Guid AdId, TimeSpan? granularity, CancellationToken cancellationToken);
        Task<long> GetAdConversionsAsync(Guid campaignID, Guid AdId, TimeSpan? granularity, CancellationToken cancellationToken);
        Task<AdPerformance> GetAdMetricsAsync(AdMetricsRequest adMetricsRequest, CancellationToken cancellationToken);
    }
}
