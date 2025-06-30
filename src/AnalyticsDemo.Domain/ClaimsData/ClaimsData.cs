namespace AnalyticsDemo.Domain.ClaimsData
{
    public class ClaimsData
    {
        public string NameIdentifier { get; set; }
        public string ClientId { get; set; }
        public long AuthTime { get; set; }
        public string TenantDisplayName { get; set; }
        public string TenantId { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string ProductName { get; set; }
        public string TenantRegistrationName { get; set; }
    }
}
