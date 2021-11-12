using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace VirtoCommerce.Platform.Web.Infrastructure
{
    /// <summary>
    /// https://github.com/openiddict/openiddict-core/issues/594
    /// This custom provider allows able to use just [Authorize] instead of having to define [Authorize(AuthenticationSchemes = "Bearer")] above every API controller
    /// without this Bearer authorization will not work
    /// </summary>
    public class CustomAuthenticationSchemeProvider : AuthenticationSchemeProvider
    {
        private const string message = "The HTTP request cannot be retrieved.";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomAuthenticationSchemeProvider(IHttpContextAccessor httpContextAccessor, IOptions<AuthenticationOptions> options)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private Task<AuthenticationScheme> GetRequestSchemeAsync(string message)
        {
            var request = _httpContextAccessor.HttpContext?.Request;

            if (request == null)
            {
                throw new ArgumentNullException(message);
            }

            if (request.Headers.ContainsKey("Authorization"))
            {
                return getSchemaSeparatedAsync(JwtBearerDefaults.AuthenticationScheme);
            }

            return null;
        }

        public async Task<AuthenticationScheme> getSchemaSeparatedAsync(string AuthenticationScheme)
        {
            return await GetSchemeAsync(AuthenticationScheme);
        }

        public override async Task<AuthenticationScheme> GetDefaultAuthenticateSchemeAsync() =>
                    await GetRequestSchemeAsync(message) ??
                    await base.GetDefaultAuthenticateSchemeAsync();

        public override async Task<AuthenticationScheme> GetDefaultChallengeSchemeAsync() =>
            await GetRequestSchemeAsync(message) ??
            await base.GetDefaultChallengeSchemeAsync();

        public override async Task<AuthenticationScheme> GetDefaultForbidSchemeAsync() =>
            await GetRequestSchemeAsync(message) ??
            await base.GetDefaultForbidSchemeAsync();

        public override async Task<AuthenticationScheme> GetDefaultSignInSchemeAsync() =>
            await GetRequestSchemeAsync(message) ??
            await base.GetDefaultSignInSchemeAsync();

        public override async Task<AuthenticationScheme> GetDefaultSignOutSchemeAsync() =>
            await GetRequestSchemeAsync(message) ??
            await base.GetDefaultSignOutSchemeAsync();
    }
}
