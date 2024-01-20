namespace Infra.External.Authentication.Support.Options
{
    public record KeyCloakConfig
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Realm { get; set; }
        public string Protocol { get; set; }
        public string HostName { get; set; }
        public string Port { get; set; }
    }
}
