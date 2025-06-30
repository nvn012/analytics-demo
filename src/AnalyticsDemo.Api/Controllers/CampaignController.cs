using AnalyticsDemo.Application.AdMetrics.Queries.Ads;
using AnalyticsDemo.Application.AdMetrics.Queries.Campaign;
using AnalyticsDemo.Application.Interfaces;
using AnalyticsDemo.Domain.DTO.Campaign;
using AnalyticsDemo.Domain.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnalyticsDemo.Api.Controllers
{
    [ApiController]
    // [Authorize(AuthenticationSchemes = "Bearer")]
    public class CampaignController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAppLogger<CampaignController> _logger;

        public CampaignController(IMediator mediator, IAppLogger<CampaignController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// returns the performance of a campaign based on the provided campaign ID, ads, and date range.
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="ads"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpPost("campaign/{campaignId}/performance")]
        [ProducesResponseType(typeof(CampaignPerformance), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPerformance(
            [FromQuery] string campaignId,
            [FromBody] List<AdMetricsRequest>? ads,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            if (string.IsNullOrEmpty(campaignId))
            {
                _logger.LogInformation("Campaign ID is null or empty.");
                return BadRequest("Campaign ID cannot be null or empty.");
            }
            try
            {
                var getCampaignMetricsQuery = new GetCampaignMetricsQuery
                {
                    CampaignId = Guid.Parse(campaignId),
                    AdMetricsRequest = ads ?? [],
                    StartDate = startDate,
                    EndDate = endDate
                };
                var result = await _mediator.Send(getCampaignMetricsQuery);
                if (result == null)
                {
                    _logger.LogWarning($"No performance data found for campaign ID: {campaignId}");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving campaign performance data.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
