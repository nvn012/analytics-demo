using AnalyticsDemo.Domain.ClaimsData;
using System.Security.Claims;

namespace AnalyticsDemo.Application.Claims
{
    public interface IClaimsAccessor
    {
        ClaimsPrincipal Claims { get; }

        ClaimsData ClaimsData { get; }

        string TenantToken { get; }
    }
}
