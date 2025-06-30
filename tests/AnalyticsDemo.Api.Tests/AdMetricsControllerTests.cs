using AnalyticsDemo.Api.Controllers;
using AnalyticsDemo.Application.AdMetrics.Queries.Ads;
using AnalyticsDemo.Application.Interfaces;
using AnalyticsDemo.Domain.DTO.Campaign;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AnalyticsDemo.Api.Tests.Controllers
{
    public class AdMetricsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IAppLogger<AdMetricsController>> _loggerMock;
        private readonly AdMetricsController _controller;

        public AdMetricsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<IAppLogger<AdMetricsController>>();
            _controller = new AdMetricsController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task TC01_GetClicks_WithValidParameters_ReturnsOkResultWithClickCount()
        {
            var adId = Guid.NewGuid().ToString();
            var campaignId = Guid.NewGuid().ToString();
            var startDate = DateTime.UtcNow.AddDays(-7);
            var endDate = DateTime.UtcNow;
            var expectedClicks = 150L;

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetAdClicksQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedClicks);

            var result = await _controller.GetClicks(adId, campaignId, startDate, endDate);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);

            _mediatorMock.Verify(m => m.Send(
                It.Is<GetAdClicksQuery>(q =>
                    q.AdId == Guid.Parse(adId) &&
                    q.CampaignId == Guid.Parse(campaignId) &&
                    q.StartTime == startDate &&
                    q.EndTime == endDate),
                It.IsAny<CancellationToken>()), Times.Once);

            _loggerMock.Verify(l => l.LogInformation(
                It.IsAny<string>(),
                It.IsAny<object[]>()), Times.Once);
        }

        [Fact]
        public async Task TC02_GetClicks_WithInvalidGuid_ReturnsBadRequest()
        {
            var invalidAdId = "invalid-guid";
            var campaignId = Guid.NewGuid().ToString();

            var result = await _controller.GetClicks(invalidAdId, campaignId);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.NotNull(badRequestResult);

            _loggerMock.Verify(l => l.LogError(
                It.IsAny<Exception>(),
                It.IsAny<string>(),
                It.IsAny<object[]>()), Times.Once);
        }

        [Fact]
        public async Task TC03_GetClicks_WhenMediatorThrowsException_ReturnsBadRequest()
        {
            var adId = Guid.NewGuid().ToString();
            var campaignId = Guid.NewGuid().ToString();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetAdClicksQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("Database connection failed"));

            var result = await _controller.GetClicks(adId, campaignId);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
            _loggerMock.Verify(l => l.LogError(
                It.IsAny<Exception>(),
                It.IsAny<string>(),
                It.IsAny<object[]>()), Times.Once);
        }

        [Fact]
        public async Task TC04_GetImpressions_WithValidParameters_ReturnsOkResultWithImpressionCount()
        {
            var adId = Guid.NewGuid().ToString();
            var campaignId = Guid.NewGuid().ToString();
            var expectedImpressions = 1500L;

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetAdImpressionQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedImpressions);

            var result = await _controller.GetImpressions(adId, campaignId);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
        }

        [Fact]
        public async Task TC05_GetClickToBasket_WithValidParameters_ReturnsOkResultWithCount()
        {
            var adId = Guid.NewGuid().ToString();
            var campaignId = Guid.NewGuid().ToString();
            var expectedClickToBasket = 50L;

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetAdClicksToBasketQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedClickToBasket);

            var result = await _controller.GetClickToBasket(adId, campaignId);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
        }

        [Fact]
        public async Task TC06_GetAdPerformance_WithValidParameters_ReturnsOkResultWithAdPerformance()
        {
            var adId = Guid.NewGuid();
            var campaignId = Guid.NewGuid().ToString();
            var expectedPerformance = new AdPerformance
            {
                AdId = adId,
                Clicks = 200,
                Impressions = 2000,
                ClickToBasket = 50
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetAdMetricsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedPerformance);

            var result = await _controller.GetAdPerformance(adId.ToString(), campaignId);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("2024-01-01", null)]
        [InlineData(null, "2024-01-31")]
        [InlineData("2024-01-01", "2024-01-31")]
        public async Task TC07_GetClicks_WithVariousDateParameters_HandlesCorrectly(string? startDateStr, string? endDateStr)
        {
            var adId = Guid.NewGuid().ToString();
            var campaignId = Guid.NewGuid().ToString();
            DateTime? startDate = startDateStr != null ? DateTime.Parse(startDateStr) : null;
            DateTime? endDate = endDateStr != null ? DateTime.Parse(endDateStr) : null;

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetAdClicksQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(100L);

            var result = await _controller.GetClicks(adId, campaignId, startDate, endDate);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
            _mediatorMock.Verify(m => m.Send(
                It.Is<GetAdClicksQuery>(q =>
                    q.StartTime == startDate &&
                    q.EndTime == endDate),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}