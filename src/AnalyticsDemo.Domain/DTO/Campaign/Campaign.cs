namespace AnalyticsDemo.Domain.DTO.Campaign
{
    public record Campaign
    {
        public Guid CampaignId { get; set; }
        public DateTime? CampaignStartDate { get; set; }
        public DateTime? CampaignEndDate { get;set; }
        public string CampaignName { get; set; } = string.Empty;
        public string CampaignType { get; set; } = string.Empty;
        public string CampaignDescription { get; set; } = string.Empty;
        public required List<Ad> Ads { get; set; }
    }
}
