using AutoMapper;
using Domain.Authentication.Interfaces;
using Domain.Authentication.Models;
using Infra.Common;
using Infra.External.Authentication.Interfaces;
using Infra.External.Authentication.Models;
using Microsoft.Extensions.Logging;

namespace Domain.Authentication.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IMapper _mapper;
        public AuthenticationService(IAuthenticationService authenticationService,
                                     ILogger<AuthenticationService> logger, 
                                     IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        public async Task<Result<AuthenticationResponseModel>> GetAuthenticationTokenAsync(AuthenticationRequestModel authenticationRequestModel, 
                                                                                           CancellationToken cancellationToken)
        {

            var model = _mapper.Map<AuthenticationModel.Request>(authenticationRequestModel);
            var request = await _authenticationService.Authenticate(model, cancellationToken).ConfigureAwait(false);    

            if (request.IsFailure)
                return Result.Failure<AuthenticationResponseModel>(request.Error);
            
            return _mapper.Map<AuthenticationResponseModel>(request.Value);
        }
    }
}
