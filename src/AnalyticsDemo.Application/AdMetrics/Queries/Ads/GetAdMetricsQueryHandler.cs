using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;
using AnalyticsDemo.Infra.Persistence.Repository.Interfaces;
using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    public record GetAdMetricsQueryHandler : IRequestHandler<GetAdMetricsQuery, AdPerformance>
    {
        private readonly IAdMetricsReadRepository _adMetricsRepository;

        public GetAdMetricsQueryHandler(IAdMetricsReadRepository adMetricsReadRepository)
        {
            _adMetricsRepository = adMetricsReadRepository;
        }
        public Task<AdPerformance> Handle(GetAdMetricsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var adMetricsRequest = new AdMetricsRequest()
            {
                CampaignId = request.CampaignId,
                AdId = request.AdId,
                StartDate = request.StartTime,
                EndDate = request.EndTime
            };

            var adMetrics = _adMetricsRepository.GetAdMetricsAsync(adMetricsRequest, cancellationToken);

            if(adMetrics == null)
            {
                throw new InvalidOperationException("No ad metrics found for the given request.");
            }

            return adMetrics;
        }
    }
}
