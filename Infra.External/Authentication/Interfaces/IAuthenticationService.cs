using Infra.Common;
using Infra.External.Authentication.Models;

namespace Infra.External.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Result<AuthenticationModel.Response>> Authenticate(AuthenticationModel.Request requestBody, CancellationToken cancellationToken);
    }
}
