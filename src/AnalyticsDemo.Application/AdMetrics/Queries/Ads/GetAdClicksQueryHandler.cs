using AnalyticsDemo.Application.Interfaces;
using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    /// <summary>
    /// handler for <seealso cref="GetAdClicksQuery"/>
    /// </summary>
    /// <param name="adMetricsRepository"> injected by di</param>
    public class GetAdClicksQueryHandler(IAdMetricsReadRepository adMetricsRepository, IAppLogger<GetAdClicksQueryHandler> logger) : IRequestHandler<GetAdClicksQuery, long>
    {
        private readonly IAdMetricsReadRepository _adMetricsRepository = adMetricsRepository;
        private readonly IAppLogger<GetAdClicksQueryHandler> _logger = logger;

        public async Task<long> Handle(GetAdClicksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("getting ad cloicks for CampaignId: {CampaignId}, AdId: {AdId}", request.CampaignId, request.AdId);
                if (request is null)
                    throw new ArgumentNullException(nameof(request), "Request cannot be null");

                TimeSpan? granularity = null;

                var adClicks = await _adMetricsRepository.GetAdClicksAsync(request.CampaignId, request.AdId, granularity, cancellationToken);

                return adClicks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while gettingh ad clicks for CampaignId: {CampaignId}, AdId: {AdId}", request.CampaignId, request.AdId);
                throw;
            }
        }
    }
}
