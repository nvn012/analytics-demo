using AnalyticsDemo.Application.Claims;
using AnalyticsDemo.Domain.Tenant;
using Microsoft.Extensions.Configuration;

namespace AnalyticsDemo.Infra.TenantRepo
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IClaimsAccessor _claimsAccessor;
        private Tenant _tenant;

        public TenantProvider(IConfiguration configuration, IClaimsAccessor claimsAccessor)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            _configuration = configuration;
            _claimsAccessor = claimsAccessor;

            string tenantToken = _claimsAccessor.TenantToken;
        }

        public Tenant GetTenant()
        {
            var tenantsSection = _configuration.GetSection("Tenants");
            var firstTenantSection = tenantsSection.GetChildren().FirstOrDefault();

            //we can also use the tenant token to get the tenant details.

            return _tenant ??= new Tenant
            {
                TenantId = _claimsAccessor.ClaimsData.TenantId,
                TenantName = _claimsAccessor.ClaimsData.TenantDisplayName,
                ReadConnectionString = _configuration["Tenants:ReadConnectionString"],
                WriteConnectionString = _configuration["Tenants:WriteConnectionString"]
            };


            //In prod we can setup a cache and aws param store to get the tenant details
        }
    }
}
