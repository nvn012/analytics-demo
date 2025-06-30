namespace AnalyticsDemo.Domain.Request
{
    public record CampaignMetricsRequest
    {
        public Guid CampaignId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //just in case user wants to get Metrics for a specific Ad, otherwise it will return metrics for all Ads in the Campaign
        public List<AdMetricsRequest> AdMetricsRequest { get; set; } = [];
    }
}
