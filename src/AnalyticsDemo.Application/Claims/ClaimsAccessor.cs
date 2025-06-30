using AnalyticsDemo.Domain.ClaimsData;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AnalyticsDemo.Application.Claims
{
    public class ClaimsAccessor : IClaimsAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string TENANT_TOKEN = "TenantToken";

        public ClaimsAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal Claims
        {
            get
            {
                ClaimsPrincipal claimsPrincipal = _httpContextAccessor?.HttpContext?.User;

                if (claimsPrincipal?.Claims == null || !claimsPrincipal.Claims.Any())
                {
                    return null;
                }

                return claimsPrincipal;
            }
        }

        public ClaimsData ClaimsData
        {
            get
            {
                if (Claims != null)
                {
                    return new ClaimsData
                    {
                        NameIdentifier = Claims.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                        ClientId = Claims.FindFirst("ClientId")?.Value,
                        AuthTime = Convert.ToInt64(Claims.FindFirst("AuthenticationTime")?.Value),
                        TenantDisplayName = Claims.FindFirst("TenantDisplayName")?.Value,
                        TenantId = Claims.FindFirst("TenantId")?.Value,
                        Role = Claims.FindFirst(ClaimTypes.Role)?.Value,
                        Email = Claims.FindFirst("EmailAddress")?.Value,
                        EmailVerified = Convert.ToBoolean(Claims.FindFirst("EmailVerified")?.Value),
                        ProductName = Claims.FindFirst("ProductName")?.Value,
                        TenantRegistrationName = Claims.FindFirst("TenantRegistrationName")?.Value
                    };
                }
                return null;
            }
        }

        public string TenantToken
        {
            get
            {
                if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
                {
                    return authHeader.ToString().Substring(TENANT_TOKEN.Length).Trim();
                }
                return string.Empty;
            }
        }
    }
}
