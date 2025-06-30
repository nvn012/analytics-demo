using AnalyticsDemo.Application.Interfaces;
using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;
using AnalyticsDemo.Infra.TenantRepo;

namespace AnalyticsDemo.Infra.Persistence.Repository
{
    public class CampaignReadRepository : ReadOnlyRepository<CampaignPerformance>, ICampaignReadRepository
    {
        private readonly ITenantProvider _tenantProvider;
        private readonly ICacheService _cacheService;
        private readonly IAppLogger<CampaignReadRepository> _logger;
        public CampaignReadRepository(IDbConnectionFactory dbConnectionFactory, ITenantProvider tenantProvider,
            ICacheService cacheService, IAppLogger<CampaignReadRepository> logger) : 
            base(dbConnectionFactory, tenantProvider)
        {
            _tenantProvider = tenantProvider;
            _cacheService = cacheService;
            _logger = logger;
        }

        public Task<CampaignPerformance> GetCampaignMetricsAsync(CampaignMetricsRequest campaignMetricsRequest, CancellationToken cancellationToken)
        {
            //check in cache first
            //var cacheKey = $"ad:clicks:{campaignID}:{AdId}:{granularity?.TotalMinutes ?? 0}";
            //var cachedData = _cacheService.Get<CampaignPerformance>(cacheKey);
            //if (cachedData != null)
            //{
            //    return Task.FromResult(cachedData);
            //}

            //if not in cache goto Db.


            // Here you would typically query the database to get the campaign metrics.
            // For demp , i amreturning  CampaignPerformance object.

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
