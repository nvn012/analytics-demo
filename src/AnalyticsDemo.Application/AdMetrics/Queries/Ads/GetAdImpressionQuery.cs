using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    /// <summary>
    /// Represents a query to retrieve the number of ad impressions.
    /// </summary>
    /// <remarks>This query is used to request the total count of ad impressions for a specific context. 
    public record class GetAdImpressionQuery : GetAdQueryBase, IRequest<long>
    {
    }
}
