using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    public record GetAdQueryBase
    {
        public Guid AdId { get; set; }
        public Guid CampaignId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
