namespace AnalyticsDemo.Domain.DTO.Campaign
{
    public record AdPerformance
    {
        public Guid AdId { get; set; }
        public long Clicks { get; set; }
        public long Impressions { get; set; }
        public long ClickToBasket { get; set; }
    }
}
