namespace ApiRequest
{
    public class AuthenticationConfig
    {
        public string ClientId { get; set; }
        public string AuthUrl { get; set; }
        public string TokenUrl { get; set; }
        public string ClientSecret { get; set; }

        public AuthenticationConfig Copy()
        {
            return new AuthenticationConfig
            {
                ClientId = ClientId,
                AuthUrl = AuthUrl,
                TokenUrl = TokenUrl,
                ClientSecret = ClientSecret
            };
        }

    }
}