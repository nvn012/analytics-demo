using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;

namespace AnalyticsDemo.Application.Interfaces
{
    public interface ICampaignReadRepository
    {
        /// <summary>
        /// gets the campaign metrics based on the provided request.
        /// </summary>
        /// <param name="campaignMetricsRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CampaignPerformance> GetCampaignMetricsAsync(CampaignMetricsRequest campaignMetricsRequest, CancellationToken cancellationToken);
    }
}
