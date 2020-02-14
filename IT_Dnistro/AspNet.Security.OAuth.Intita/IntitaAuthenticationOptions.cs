using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace AspNet.Security.OAuth.Intita
{
    /// <summary>
    /// Defines a set of options used by <see cref="IntitaAuthenticationHandler"/>.
    /// </summary>
    public class IntitaAuthenticationOptions : OAuthOptions
    {
        public IntitaAuthenticationOptions()
        {
            //ClaimsIssuer = IntitaAuthenticationDefaults.Issuer;

            CallbackPath = new PathString(IntitaAuthenticationDefaults.CallbackPath);

            AuthorizationEndpoint = IntitaAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = IntitaAuthenticationDefaults.TokenEndpoint;
            
            //UserInformationEndpoint = IntitaAuthenticationDefaults.UserInformationEndpoint;
            //
            //ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            //ClaimActions.MapJsonKey(ClaimTypes.Name, "firstName");
            //ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
            //ClaimActions.MapJsonKey("urn:intita:name", "name");
            //ClaimActions.MapJsonKey("urn:intita:url", "url");

            //Events = new OAuthEvents();
        }
        
    }
}
