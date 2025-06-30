using AnalyticsDemo.Domain.DTO.Campaign;
using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    public record GetAdMetricsQuery : IRequest<AdPerformance>
    {
        public Guid CampaignId { get; set; }
        public Guid AdId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
