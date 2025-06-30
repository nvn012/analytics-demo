using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    public record class GetAdImpressionQuery : GetAdQueryBase, IRequest<long>
    {
    }
}
