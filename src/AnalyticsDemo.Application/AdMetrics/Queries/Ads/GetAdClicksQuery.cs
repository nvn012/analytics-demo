using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    /// <summary>
    /// Query to get the number of clicks for a specific ad.
    /// </summary>
    public record GetAdClicksQuery : GetAdQueryBase, IRequest<long>
    {
        
    }
}
