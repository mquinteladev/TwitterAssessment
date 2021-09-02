using Interfaces;
using Microsoft.Extensions.Configuration;

namespace Domain
{
    public class AppConfiguration : IAppConfiguration
    {
        readonly IConfiguration _configuration;

        public AppConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ApiKey => _configuration["twitter:api_key"];
        public string ApiKeySecret => _configuration["twitter:api_key_secret"];
        public string ApiUrl => _configuration["twitter:api_url"];
        public object BearerToken => _configuration["twitter:bearer_token"];
    }
}
