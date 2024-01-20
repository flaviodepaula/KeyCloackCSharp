using Infra.Common;
using Infra.External.Authentication.Errors;
using Infra.External.Authentication.Interfaces;
using Infra.External.Authentication.Models;
using Infra.External.Authentication.Support.Options;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;

namespace Infra.External.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly KeyCloakConfig _KeyCloackOptions;

        public AuthenticationService(ILogger<AuthenticationService> logger, KeyCloakConfig keyCloackOptions, HttpClient httpClient)
        {
            _logger = logger;
            _KeyCloackOptions = keyCloackOptions;
            _httpClient = httpClient;
        }

        public async Task<Result<AuthenticationModel.Response>> Authenticate(AuthenticationModel.Request requestBody, CancellationToken cancellationToken)
        {
            try
            {
                var keyValuePairs = requestBody.KeyValuePairs;
                keyValuePairs ??= new Dictionary<string, string>();

                keyValuePairs.Add("client_id", requestBody.ClientId);
                keyValuePairs.Add("client_secret", requestBody.ClientSecret);

                if (!keyValuePairs.ContainsKey("grant_type"))
                    keyValuePairs.Add("grant_type", "client_credentials");

                var content = new FormUrlEncodedContent(keyValuePairs);

                var result = await _httpClient.PostAsync(_KeyCloackOptions.Authority, content, cancellationToken);

                if (!result.IsSuccessStatusCode)
                    return Result.Failure<AuthenticationModel.Response>(ExternalServiceAuthenticationErrors.UnsuccessfulRequest);

                using var stream = await result.Content.ReadAsStreamAsync(cancellationToken);

                var resposta = await JsonSerializer.DeserializeAsync<AuthenticationModel.Response>(
                    stream,
                    cancellationToken: cancellationToken
                );

                return Result.Sucess(resposta!);
            }            
            catch (Exception ex)
            {
                _logger.LogError($"Generic Error on trying to connect to KeyCloack. Message: {ex.Message} \n InnerException: {ex.InnerException}");

                return Result.Failure<AuthenticationModel.Response>
                        (ExternalServiceAuthenticationErrors.KeyCloackRequestAccessError(ex.Message, ex.InnerException!.ToString()));

            }
        }
    }
}
