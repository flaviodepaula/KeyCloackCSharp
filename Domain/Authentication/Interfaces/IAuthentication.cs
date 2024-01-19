using Domain.Authentication.Models;

namespace Domain.Authentication.Interfaces
{
    public interface IAuthentication
    {
        Task<AuthenticationResponseModel> GetAuthenticationTokenAsync(AuthenticationRequestModel authenticationRequestModel, CancellationToken cancellationToken);
    }
}
