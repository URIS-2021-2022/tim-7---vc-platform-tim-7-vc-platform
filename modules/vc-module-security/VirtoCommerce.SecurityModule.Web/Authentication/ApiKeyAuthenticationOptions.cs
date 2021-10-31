using Microsoft.AspNetCore.Authentication;

namespace VirtoCommerce.SecurityModule.Web.Authentication
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "API Key";

        public string Scheme { get; set; } = DefaultScheme;
        public string ApiKeyParamName { get; set; } = "api_key";
    }
}
