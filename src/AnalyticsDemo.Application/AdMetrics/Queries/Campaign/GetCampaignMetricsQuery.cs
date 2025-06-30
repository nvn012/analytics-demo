using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;
using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Campaign
{
    public record GetCampaignMetricsQuery : IRequest<CampaignPerformance>
    {
        public Guid CampaignId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<AdMetricsRequest> AdMetricsRequest { get; set; } = [];
    }
}
