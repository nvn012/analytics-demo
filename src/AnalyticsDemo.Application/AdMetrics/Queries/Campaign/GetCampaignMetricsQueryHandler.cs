using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;
using AnalyticsDemo.Infra.Persistence.Repository.Interfaces;
using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Campaign
{
    internal class GetCampaignMetricsQueryHandler : IRequestHandler<GetCampaignMetricsQuery, CampaignPerformance>
    {
        private readonly ICampaignReadRepository _campaignReadRepository;
        public GetCampaignMetricsQueryHandler(ICampaignReadRepository campaignReadRepository)
        {
            _campaignReadRepository = campaignReadRepository;
        }

        public async Task<CampaignPerformance> Handle(GetCampaignMetricsQuery request, CancellationToken cancellationToken)
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

            if(campaignPerformance == null)
            {
                throw new InvalidOperationException($"No metrics found for campaign with ID {request.CampaignId}");
            }

            return campaignPerformance;
        }
    }
}
