using MediatR;

namespace AnalyticsDemo.Application.AdMetrics.Queries.Ads
{
    /// <summary>
    ///  query to retrieve the number of ad clicks that resulted in added to basket.
    /// </summaryad
    /// <remarks>This can be is used to analyze the performance of advertisements by determining how many
    /// clicks led to basket additions. It extends <see cref="GetAdQueryBase"/> and returns a <see langword="long"/>
    /// value representing the total count od ad cliolk.</remarks>
    public record class GetAdClicksToBasketQuery : GetAdQueryBase, IRequest<long>
    {
    }
}
