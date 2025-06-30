using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    public record class GetAdClicksToBasketQuery : GetAdQueryBase, IRequest<long>
    {
    }
}
