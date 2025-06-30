using AnalyticsDemo.Application.Interfaces;
using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;
using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Campaign
{
    internal class GetCampaignMetricsQueryHandler : IRequestHandler<GetCampaignMetricsQuery, CampaignPerformance>
    {
        private readonly ICampaignReadRepository _campaignReadRepository;
        private readonly IAppLogger<GetCampaignMetricsQueryHandler> _logger;
        public GetCampaignMetricsQueryHandler(ICampaignReadRepository campaignReadRepository, IAppLogger<GetCampaignMetricsQueryHandler> appLogger)
        {
            _campaignReadRepository = campaignReadRepository;
            _logger = appLogger ?? throw new ArgumentNullException(nameof(appLogger));
        }

        public async Task<CampaignPerformance> Handle(GetCampaignMetricsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request);

                var campaignMetricsRequest = new CampaignMetricsRequest
                {
                    CampaignId = request.CampaignId,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    AdMetricsRequest = request.AdMetricsRequest
                };

                var campaignPerformance = await _campaignReadRepository.GetCampaignMetricsAsync(campaignMetricsRequest, cancellationToken);

                if (campaignPerformance == null)
                {
                    throw new InvalidOperationException($"No metrics found for campaign with ID {request.CampaignId}");
                }

                return campaignPerformance;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching campaign metrics for CampaignId: {CampaignId}", request.CampaignId);
                throw;
            }
        }
    }
}
