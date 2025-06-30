using AnalyticsDemo.Application.Interfaces;
using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    public class GetAdImpressionQueryHandler(IAdMetricsReadRepository adMetricsRepository, IAppLogger<GetAdImpressionQueryHandler> appLogger) : IRequestHandler<GetAdImpressionQuery, long>
    {
        private readonly IAdMetricsReadRepository _adMetricsRepository = adMetricsRepository;
        private readonly IAppLogger<GetAdImpressionQueryHandler> _appLogger = appLogger;

        public async Task<long> Handle(GetAdImpressionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request), "Request cannot be null");

                TimeSpan? granularity = null;

                var adClicks = await _adMetricsRepository.GetImpressionAsync(request.CampaignId, request.AdId, granularity, cancellationToken);

                return adClicks;
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex, "An error occurred while getting as impressionb");
                throw;
            }
        }
    }
}
