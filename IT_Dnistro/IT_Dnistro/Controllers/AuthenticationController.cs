using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using IT_Dnistro.Extensions;
using IT_Dnistro.ViewModels;

namespace IT_Dnistro.Controllers
{
    public class AuthenticationController : Controller
    {
        public async Task<IActionResult> SignIn()
        {
            return View(await HttpContext.GetExternalProvidersAsync().ConfigureAwait(true));
        }

        [HttpGet("/signin")]
        public async Task<IActionResult> SignIn([FromQuery]string returnUrl, string message)
        {
            if (returnUrl != null)
            {
                string myCookie = Request.Cookies["RoomIdCookie"];
                Regex regex = new Regex(@"\d+$");
                Match match = regex.Match(returnUrl);
                if (match != null)
                {
                    myCookie = match.Value;
                    Response.Cookies.Append("RoomIdCookie", myCookie);
                }
            }

            // myCookie = "https://localhost:44310/Schedule/ByRoom?roomId=4"; FYI : this how should look like path to a concrete room schedule
            return View(await HttpContext.GetExternalProvidersAsync().ConfigureAwait(true));
        }

        [HttpPost("/signin")]
        public async Task<IActionResult> SignIn([FromForm] string provider)
        {
            // Note: the "provider" parameter corresponds to the external
            // authentication provider choosen by the user agent.
            if (string.IsNullOrWhiteSpace(provider))
            {
                return BadRequest();
            }

            if (!await HttpContext.IsProviderSupportedAsync(provider))
            {
                return BadRequest();
            }

            // Instruct the middleware corresponding to the requested external identity
            // provider to redirect the user agent to its own authorization endpoint.
            // Note: the authenticationScheme parameter must match the value configured in Startup.cs

            return Challenge(new AuthenticationProperties { RedirectUri = "/api/home/welcome" }, provider);
        }

        [HttpGet("~/signout"), HttpPost("~/signout")]
        public IActionResult SignOut()
        {
            // Instruct the cookies middleware to delete the local cookie created
            // when the user agent is redirected from the external identity provider
            // after a successful authentication flow (e.g Google or Facebook).
            Response.Cookies.Delete("IntitaKey");
            return SignOut(new AuthenticationProperties { RedirectUri = "/" },
                CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
