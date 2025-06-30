namespace AnalyticsDemo.Domain.DTO.Campaign
{
    public record Ad
    {
        public Guid CampaignId { get; set; }
        public Guid AdId { get; set; }
        public string AdName { get; set; } = string.Empty;
        public string AdType { get; set; } = string.Empty;
        public string AdTypeDescription { get; set; }= string.Empty;
        public string AdStatus { get; set; } = string.Empty;
        public DateTime AdCreatedOn { get; set; }
        public DateTime? AdExpiry { get; set; }
        public bool IsActive { get; set; }
        public required Product Product { get; set; }
    }
}
