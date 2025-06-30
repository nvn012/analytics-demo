using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;
using AnalyticsDemo.Infra.Persistence.Repository.Interfaces;
using AnalyticsDemo.Infra.TenantRepo;

namespace AnalyticsDemo.Infra.Persistence.Repository
{
    public class AdMetricsReadRepository : ReadOnlyRepository<AdPerformance>, IAdMetricsReadRepository
    {
        private readonly ITenantProvider _tenantProvider;
        public AdMetricsReadRepository(IDbConnectionFactory dbConnectionFactory, ITenantProvider tenantProvider) :
            base(dbConnectionFactory, tenantProvider)
        {
            _tenantProvider = tenantProvider ?? throw new ArgumentNullException(nameof(tenantProvider));
        }

        public Task<long> GetAdClicksAsync(Guid campaignID, Guid AdId, TimeSpan? granularity, CancellationToken cancellationToken)
        {
            return Task.FromResult(200L);
        }

        public Task<long> GetAdConversionsAsync(Guid campaignID, Guid AdId, TimeSpan? granularity, CancellationToken cancellationToken)
        {
            return Task.FromResult(200L);
        }

        public Task<AdPerformance> GetAdMetricsAsync(AdMetricsRequest adMetricsRequest, CancellationToken cancellationToken)
        {
            return Task.FromResult(new AdPerformance
            {
                AdId = adMetricsRequest.AdId,
                Clicks = 200L,
                Impressions = 200L,
                ClickToBasket = 50L
            });
        }

        public Task<long> GetImpressionAsync(Guid campaignID, Guid AdId, TimeSpan? granularity, CancellationToken cancellationToken)
        {
            return Task.FromResult(200L);
        }
    }
}
