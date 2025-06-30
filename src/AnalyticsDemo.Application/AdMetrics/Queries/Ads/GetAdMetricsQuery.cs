using AnalyticsDemo.Domain.DTO.Campaign;
using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    /// <summary>
    /// This query is to get the performance metrics of a specific ad within a campaign.
    /// start date and end date provides if we want to see in specific timeperiopd.
    /// </summary>
    public record GetAdMetricsQuery : IRequest<AdPerformance>
    {
        public Guid CampaignId { get; set; }
        public Guid AdId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
