using Domain.Authentication.Models;
using Infra.Common;

namespace Domain.Authentication.Interfaces
{
    public interface IAuthentication
    {
        Task<Result<AuthenticationResponseModel>> GetAuthenticationTokenAsync(AuthenticationRequestModel authenticationRequestModel, CancellationToken cancellationToken);
    }
}
