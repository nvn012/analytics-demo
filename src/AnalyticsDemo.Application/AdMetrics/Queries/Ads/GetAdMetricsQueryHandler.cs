using AnalyticsDemo.Application.Interfaces;
using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;
using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    public record GetAdMetricsQueryHandler : IRequestHandler<GetAdMetricsQuery, AdPerformance>
    {
        private readonly IAdMetricsReadRepository _adMetricsRepository;
        private readonly IAppLogger<GetAdMetricsQueryHandler> _logger;
        public GetAdMetricsQueryHandler(IAdMetricsReadRepository adMetricsReadRepository, IAppLogger<GetAdMetricsQueryHandler> logger)
        {
            _adMetricsRepository = adMetricsReadRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public Task<AdPerformance> Handle(GetAdMetricsQuery request, CancellationToken cancellationToken)
        {
            try
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

                if (adMetrics == null)
                {
                    throw new InvalidOperationException("No ad metrics found for the given request.");
                }

                return adMetrics;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting  ad perofmance.");
                throw;
            }
        }
    }
}
