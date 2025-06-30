namespace AnalyticsDemo.Domain.Tenant
{
    /// <summary>
    /// basic sto for tenat resolved, it can be extended for more details and hooke with 
    /// secrets manager in prod level setup
    /// </summary>
    public class Tenant
    {
        /// <summary>
        /// Gets or sets the TenantId.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or sets the TenantName.
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// Gets or sets the Read Connection string.
        /// </summary>
        public string ReadConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the Write Connection string.
        /// </summary>
        public string WriteConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the Database provider.
        /// </summary>
        public string DBProvider { get; set; }

        public string Host { get; set; }
    }
}
