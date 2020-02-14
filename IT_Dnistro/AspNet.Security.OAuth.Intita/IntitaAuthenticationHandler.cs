using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using ApiRequest;

namespace AspNet.Security.OAuth.Intita
{
    public class IntitaAuthenticationHandler : OAuthHandler<IntitaAuthenticationOptions>
    {
        public IntitaAuthenticationHandler(
            [NotNull] IOptionsMonitor<IntitaAuthenticationOptions> options,
            [NotNull] ILoggerFactory logger,
            [NotNull] UrlEncoder encoder,
            [NotNull] ISystemClock clock)
            : base(options, logger, encoder, clock)
        {

        }
        
        protected override Task<object> CreateEventsAsync() => Task.FromResult<object>(new OAuthEvents());

        protected override string FormatScope()
        {
            // OAuth2 3.3 space separated
            return string.Join(" ", Options.Scope);
        }

        protected override async Task<HandleRequestResult> HandleRemoteAuthenticateAsync()
        {
            var query = Request.Query;

            var state = query["state"];
            var properties = Options.StateDataFormat.Unprotect(state);

            if (properties == null)
            {
                return HandleRequestResult.Fail("The oauth state was missing or invalid.");
            }

            var error = query["error"];
            if (!StringValues.IsNullOrEmpty(error))
            {
                var failureMessage = new StringBuilder();
                failureMessage.Append(error);
                var errorDescription = query["error_description"];
                if (!StringValues.IsNullOrEmpty(errorDescription))
                {
                    failureMessage.Append(";Description=").Append(errorDescription);
                }
                var errorUri = query["error_uri"];
                if (!StringValues.IsNullOrEmpty(errorUri))
                {
                    failureMessage.Append(";Uri=").Append(errorUri);
                }

                return HandleRequestResult.Fail(failureMessage.ToString());
            }

            var code = query["code"];

            if (StringValues.IsNullOrEmpty(code))
            {
                return HandleRequestResult.Fail("Code was not found.");
            }

            var tokens = await ExchangeCodeAsync(code, BuildRedirectUri(Options.CallbackPath));

            if (tokens.Error != null)
            {
                return HandleRequestResult.Fail(tokens.Error);
            }

            if (string.IsNullOrEmpty(tokens.AccessToken))
            {
                return HandleRequestResult.Fail("Failed to retrieve access token.");
            }

            if (Options.SaveTokens)
            {
                var authTokens = new List<AuthenticationToken>();

                authTokens.Add(new AuthenticationToken { Name = "access_token", Value = tokens.AccessToken });
                if (!string.IsNullOrEmpty(tokens.RefreshToken))
                {
                    authTokens.Add(new AuthenticationToken { Name = "refresh_token", Value = tokens.RefreshToken });
                }

                if (!string.IsNullOrEmpty(tokens.TokenType))
                {
                    authTokens.Add(new AuthenticationToken { Name = "token_type", Value = tokens.TokenType });
                }

                if (!string.IsNullOrEmpty(tokens.ExpiresIn))
                {
                    int value;
                    if (int.TryParse(tokens.ExpiresIn, NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
                    {
                        var expiresAt = Clock.UtcNow + TimeSpan.FromSeconds(value);
                        authTokens.Add(new AuthenticationToken
                        {
                            Name = "expires_at",
                            Value = expiresAt.ToString("o", CultureInfo.InvariantCulture)
                        });
                    }
                }

                properties.StoreTokens(authTokens);
            }

            ApiRequest<IntitaUser> apiRequest = new ApiRequest<IntitaUser>();
            var response = apiRequest.Url("https://sso.intita.com/api/user/") //API url
                .Authenticate(tokens.AccessToken) //add default or own authenticate
                .Get() //GET, POST, PUT, DELETE
                .Send(); //send request

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, response.Response.FirstName),
            };

            if (response.Response.Id == 1294)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin"));
            }

            ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);


            var ticket = await CreateTicketAsync(identity, properties, tokens);
            if (ticket != null)
            {
                Response.Cookies.Append("IntitaKey", tokens.AccessToken);
                ticket.Properties.RedirectUri = "/Home/Dnistro";

                return HandleRequestResult.Success(ticket);
            }
            else
            {
                return HandleRequestResult.Fail("Failed to retrieve user information from remote server.");
            }
        }
    }
}
