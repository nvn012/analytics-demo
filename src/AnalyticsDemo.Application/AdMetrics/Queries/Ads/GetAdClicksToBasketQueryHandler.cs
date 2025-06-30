using AnalyticsDemo.Application.Interfaces;
using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    /// <summary>
    /// hand;er for <seealso cref="GetAdClicksToBasketQuery"/>
    /// </summary>
    /// <param name="adMetricsRepository"></param>
    public class GetAdClicksToBasketQueryHandler(IAdMetricsReadRepository adMetricsRepository, IAppLogger<GetAdClicksToBasketQueryHandler> appLogger) : IRequestHandler<GetAdClicksToBasketQuery, long>
    {
        private readonly IAdMetricsReadRepository _adMetricsRepository = adMetricsRepository;
        private readonly IAppLogger<GetAdClicksToBasketQueryHandler> _appLogger = appLogger;

        public async Task<long> Handle(GetAdClicksToBasketQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request), "Request cannot be null");

                TimeSpan? granularity = null;

                var adClicks = await _adMetricsRepository.GetAdConversionsAsync(request.CampaignId, request.AdId, granularity, cancellationToken);

                return adClicks;
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex, "Error occurred while getting adtobasket for CampaignId: {CampaignId}, AdId: {AdId}", request.CampaignId, request.AdId);
                throw;
            }
        }
    }
}
