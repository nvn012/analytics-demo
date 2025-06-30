using AnalyticsDemo.Application.Interfaces;
using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;
using AnalyticsDemo.Infra.Persistence.Repository.Interfaces;
using AnalyticsDemo.Infra.TenantRepo;

namespace AnalyticsDemo.Infra.Persistence.Repository
{
    public class AdMetricsReadRepository : ReadOnlyRepository<AdPerformance>, IAdMetricsReadRepository
    {
        private readonly ITenantProvider _tenantProvider;
        private readonly ICacheService _cacheService;
        private readonly IAppLogger<AdMetricsReadRepository> _appLogger;

        public AdMetricsReadRepository(IDbConnectionFactory dbConnectionFactory, ITenantProvider tenantProvider,
            ICacheService cacheService, IAppLogger<AdMetricsReadRepository> appLogger) :
            base(dbConnectionFactory, tenantProvider)
        {
            _tenantProvider = tenantProvider ?? throw new ArgumentNullException(nameof(tenantProvider));
            _cacheService = cacheService;
            _appLogger = appLogger;
        }

        public async Task<long> GetAdClicksAsync(Guid campaignID, Guid AdId, TimeSpan? granularity, CancellationToken cancellationToken)
        {
            //Check in cahe
            //var cacheKey = $"ad:clicks:{campaignID}:{AdId}:{granularity?.TotalMinutes ?? 0}";

            //var cachedValue = await _cacheService.GetAsync<long?>(cacheKey);
            //if (cachedValue.HasValue)
            //    return cachedValue.Value;

            //falback to dbb./

            //Example Query
            //SELECT COUNT(*) FROM UserImpressions WHERE CampaignId = @CampaignId AND AdId = @AdId
            //AND Type = 'Click' AND OccurredAt >= @StartDate AND OccurredAt < @EndDate

            //Example execution
            //var parameters = new
            //{
            //    CampaignId = campaignID,
            //    AdId = AdId,
            //    StartDate = (DateTime?)null, // Add date filtering if needed
            //    EndDate = (DateTime?)null
            //};

            //var result = await DbConnection.QuerySingleAsync<long>(sql, parameters);

            //Log info

            _appLogger.LogInformation("Fetching ad clicks for CampaignId: {CampaignId}, AdId: {AdId}, Granularity: {Granularity}",
                campaignID, AdId, granularity);

            return 200L;
        }

        public async Task<long> GetAdConversionsAsync(Guid campaignID, Guid AdId, TimeSpan? granularity, CancellationToken cancellationToken)
        {
            return 200L;
        }

        public async Task<AdPerformance> GetAdMetricsAsync(AdMetricsRequest adMetricsRequest, CancellationToken cancellationToken)
        {
            return new AdPerformance
            {
                AdId = adMetricsRequest.AdId,
                Clicks = 200L,
                Impressions = 200L,
                ClickToBasket = 50L
            };
        }

        public async Task<long> GetImpressionAsync(Guid campaignID, Guid AdId, TimeSpan? granularity, CancellationToken cancellationToken)
        {
            return 200L;
        }
    }
}
