namespace Domain.Authentication.Models
{
    public record AuthenticationResponseModel
    {
        public string? Scope { get; set; }
        public string? AccessToken { get; set; }
        public string? TokenType { get; set; }
        public int NotBeforePolicy { get; set; }
        public int ExpiresIn { get; set; }
        public int RefreshExpiresIn { get; set; }

    }
}