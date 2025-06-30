namespace AnalyticsDemo.Domain.Request
{
    public record AdMetricsRequest
    {
        public Guid CampaignId { get; set; }
        public Guid AdId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? AdType { get; set; }
        public string? AdStatus { get; set; } 
    }
}
