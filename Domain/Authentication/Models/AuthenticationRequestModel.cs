namespace Domain.Authentication.Models
{
    public class AuthenticationRequestModel
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public IDictionary<string, string>? KeyValuePairs { get; set; }

        public AuthenticationRequestModel(string clientId, string clientSecret, IDictionary<string, string>? keyValuePairs)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.KeyValuePairs = keyValuePairs;

            //todo: check if all values are valid on the constructor
        }        
    }
}