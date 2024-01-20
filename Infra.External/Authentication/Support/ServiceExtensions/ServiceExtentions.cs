using Infra.External.Authentication.Interfaces;
using Infra.External.Authentication.Services;
using Infra.External.Authentication.Support.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.External.Authentication.Support.ServiceExtensions
{
    public static class ServiceExtention
    {
        public static IServiceCollection AddInfraExternalServiceCollection(this IServiceCollection services, 
                                                                           IConfiguration configuration)
        {
            var authServer = configuration.GetSection("AuthServerConfig");
            var authServerConfig = authServer.Get<KeyCloakConfig>();
            
            services.AddHttpClient<IAuthenticationService, AuthenticationService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(
                    uriString: $"{authServerConfig.Protocol}://{authServerConfig.HostName}:{authServerConfig.Port}"
                );
                httpClient.DefaultRequestHeaders.Accept.Clear();
            }).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            return services;
        }
    }
}
