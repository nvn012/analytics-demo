namespace AnalyticsDemo.Domain.Request
{
    /// <summary>
    /// Request dto to get ad metrics
    /// </summary>
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
