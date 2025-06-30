using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;
using AnalyticsDemo.Infra.Persistence.Repository.Interfaces;
using AnalyticsDemo.Infra.TenantRepo;

namespace AnalyticsDemo.Infra.Persistence.Repository
{
    public class CampaignReadRepository : ReadOnlyRepository<CampaignPerformance>, ICampaignReadRepository
    {
        private readonly ITenantProvider _tenantProvider;
        public CampaignReadRepository(IDbConnectionFactory dbConnectionFactory, ITenantProvider tenantProvider) : 
            base(dbConnectionFactory, tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }
        public Task<CampaignPerformance> GetCampaignMetricsAsync(CampaignMetricsRequest campaignMetricsRequest, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CampaignPerformance
            {
                AdPerformances =
                [
                    new AdPerformance
                    {
                        AdId = Guid.NewGuid(),
                        Impressions = 1000,
                        Clicks = 100
                    },
                    new AdPerformance
                    {
                        AdId = Guid.NewGuid(),
                        Impressions = 2000,
                        Clicks = 200,
                    }
                ],
                CampaignId = campaignMetricsRequest.CampaignId,
                TotalImpressions = 3000,
                TotalClicks = 300
            });
        }
    }
}
