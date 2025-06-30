using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;

namespace AnalyticsDemo.Infra.Persistence.Repository.Interfaces
{
    public interface ICampaignReadRepository
    {
        Task<CampaignPerformance> GetCampaignMetricsAsync(CampaignMetricsRequest campaignMetricsRequest, CancellationToken cancellationToken);
    }
}
