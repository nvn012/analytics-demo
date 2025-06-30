using AnalyticsDemo.Application.AdMetrics.Queries.Ads;
using AnalyticsDemo.Application.Interfaces;
using AnalyticsDemo.Domain.DTO.Campaign;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnalyticsDemo.Api.Controllers
{
    [ApiController]
   // [Authorize(AuthenticationSchemes = "Bearer")]
    public class AdMetricsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAppLogger<AdMetricsController> _logger;

        public AdMetricsController(IMediator mediator, IAppLogger<AdMetricsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Returns the number of customers who clicked on the ad
        /// </summary>
        /// <param name="adId">Ad identifier</param>
        /// <param name="campaignId">Campaign identifier</param>
        /// <param name="startDate">Optional start date for filtering</param>
        /// <param name="endDate">Optional end date for filtering</param>
        /// <returns>Click count</returns>
        [HttpGet("ad/{adId}/campaign/{campaignId}/clicks")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetClicks(
            [FromRoute] string adId,
            [FromRoute] string campaignId,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            try
            {
                _logger.LogInformation("Getting click metrics for ad {AdId} in campaign {CampaignId}", adId, campaignId);
                var query = new GetAdClicksQuery
                {
                    CampaignId = Guid.Parse(campaignId),
                    AdId = Guid.Parse(adId),
                    StartTime = startDate,
                    EndTime = endDate
                };
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting click metrics for ad {AdId} in campaign {CampaignId}", adId, campaignId);
                return BadRequest(new { Message = "An error occurred while retrieving click metrics." });
            }
        }

        /// <summary>
        /// Returns the number of customers who viewed the ads
        /// </summary>
        /// <param name="adId">Ad identifier</param>
        /// <param name="campaignId">Campaign identifier</param>
        /// <param name="startDate">Optional start date for filtering</param>
        /// <param name="endDate">Optional end date for filtering</param>
        /// <returns>Impression count</returns>
        [HttpGet("ad/{adId}/campaign/{campaignId}/impressions")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetImpressions(
            [FromRoute] string adId,
            [FromRoute] string campaignId,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            try
            {
                _logger.LogInformation("Getting impression metrics for ad {AdId} in campaign {CampaignId}", adId, campaignId);
                var query = new GetAdImpressionQuery
                {
                    CampaignId = Guid.Parse(campaignId),
                    AdId = Guid.Parse(adId),
                    StartTime = startDate,
                    EndTime = endDate
                };
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting impression metrics for ad {AdId} in campaign {CampaignId}", adId, campaignId);
                return BadRequest(new { Message = "An error occurred while retrieving impression metrics." });
            }
        }

        /// <summary>
        /// Returns the number of customers who added a product to cart after clicking the ad
        /// </summary>
        /// <param name="adId">Ad identifier</param>
        /// <param name="campaignId">Campaign identifier</param>
        /// <param name="startDate">Optional start date for filtering</param>
        /// <param name="endDate">Optional end date for filtering</param>
        /// <returns>Click to basket count</returns>
        [HttpGet("ad/{adId}/campaign/{campaignId}/clickToBasket")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetClickToBasket(
            [FromRoute] string adId,
            [FromRoute] string campaignId,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            try
            {
                _logger.LogInformation("Getting click-to-basket metrics for ad {AdId} in campaign {CampaignId}", adId, campaignId);
                var query = new GetAdClicksToBasketQuery
                {
                    CampaignId = Guid.Parse(campaignId),
                    AdId = Guid.Parse(adId),
                    StartTime = startDate,
                    EndTime = endDate
                };
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting click-to-basket metrics for ad {AdId} in campaign {CampaignId}", adId, campaignId);
                return BadRequest(new { Message = "An error occurred while retrieving click-to-basket metrics." });
            }
        }

        /// <summary>
        /// Returns complete ad performance metrics including click-to-basket count
        /// </summary>
        /// <param name="adId">Ad identifier</param>
        /// <param name="campaignId">Campaign identifier</param>
        /// <param name="startDate">Optional start date for filtering</param>
        /// <param name="endDate">Optional end date for filtering</param>
        /// <returns>Click to basket count</returns>
        [HttpGet("ad/{adId}/campaign/{campaignId}/adPerformance")]
        [ProducesResponseType(typeof(AdPerformance), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAdPerformance(
            [FromRoute] string adId,
            [FromRoute] string campaignId,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            try
            {
                _logger.LogInformation("Getting click-to-basket metrics for ad {AdId} in campaign {CampaignId}", adId, campaignId);
                var query = new GetAdMetricsQuery
                {
                    CampaignId = Guid.Parse(campaignId),
                    AdId = Guid.Parse(adId),
                    StartTime = startDate,
                    EndTime = endDate
                };
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting click-to-basket metrics for ad {AdId} in campaign {CampaignId}", adId, campaignId);
                return BadRequest(new { Message = "An error occurred while retrieving click-to-basket metrics." });
            }
        }
    }
}
