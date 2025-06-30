namespace AnalyticsDemo.Domain.DTO.Campaign
{
    public record CampaignPerformance
    {
        public Guid CampaignId { get; set; }
        public long TotalImpressions { get; set; }
        public long TotalClicks { get; set; }
        public List<AdPerformance>? AdPerformances { get; set; } = [];
    }
}
