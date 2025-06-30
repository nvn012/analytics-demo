using AnalyticsDemo.Infra.Persistence.Repository.Interfaces;
using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    public class GetAdClicksToBasketQueryHandler(IAdMetricsReadRepository adMetricsRepository) : IRequestHandler<GetAdClicksToBasketQuery, long>
    {
        private readonly IAdMetricsReadRepository _adMetricsRepository = adMetricsRepository;

        public async Task<long> Handle(GetAdClicksToBasketQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request), "Request cannot be null");

            TimeSpan? granularity = null;

            var adClicks = await _adMetricsRepository.GetAdConversionsAsync(request.CampaignId, request.AdId, granularity, cancellationToken);

            return adClicks;
        }
    }
}
