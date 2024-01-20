using Infra.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.External.Authentication.Errors
{
    public static class ExternalServiceAuthenticationErrors
    {
        public static Error KeyCloackRequestAccessError(string errorMessage, string stackTrace)
        {
            return new Error("Infra.External.Authentication.ExternalServiceAuthenticationErrors", 
                            $"Request API error . Error Message:{errorMessage}. InnerException: {stackTrace}");
        }

        public static readonly Error UnsuccessfulRequest= new("Infra.External.Authentication.ExternalServiceAuthenticationErrors", 
                                                        "Request to KeyCloack was not successful.");
    }
}
