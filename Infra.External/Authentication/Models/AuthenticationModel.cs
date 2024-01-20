using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Infra.External.Authentication.Models
{
    public record AuthenticationModel
    {
        public record Request
        {
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
            public IDictionary<string, string>? KeyValuePairs { get; set; }
           
            public Request(string clientId, string clientSecret, IDictionary<string, string>? keyValuePairs)
            {
                ClientId = clientId;
                ClientSecret = clientSecret;
                KeyValuePairs = keyValuePairs;
            }
        }
        public record Response
        {
            [JsonPropertyName("access_token")]
            public string? AccessToken { get; set; }

            [JsonPropertyName("expires_in")]
            public int? ExpiresIn { get; set; }

            [JsonPropertyName("refresh_token")]
            public string? RefreshToken { get; set; }

            [JsonPropertyName("refresh_expires_in")]
            public int? RefreshExpiresIn { get; set; }

            [JsonPropertyName("token_type")]
            public string? TokenType { get; set; }

            [JsonPropertyName("not-before-policy")]
            public int? NotBeforePolicy { get; set; }

            [JsonPropertyName("session_state")]
            public string? SessionState { get; set; }

            [JsonPropertyName("scope")]
            public string? Scope { get; set; }
        }
    }
}
