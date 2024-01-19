using AutoMapper;
using Domain.Authentication.Interfaces;
using Domain.Authentication.Models;
using Microsoft.Extensions.Logging;

namespace Domain.Authentication.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IMapper _mapper;
        public AuthenticationService(ILogger<AuthenticationService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public Task<AuthenticationResponseModel> GetAuthenticationTokenAsync(AuthenticationRequestModel authenticationRequestModel, 
                                                                             CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
