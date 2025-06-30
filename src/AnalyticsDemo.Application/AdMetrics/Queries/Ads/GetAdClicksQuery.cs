using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    public record GetAdClicksQuery : GetAdQueryBase, IRequest<long>
    {
        
    }
}
