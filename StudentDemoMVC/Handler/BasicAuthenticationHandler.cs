using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;


namespace StudentDemoMVC.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
             IOptionsMonitor<AuthenticationSchemeOptions> options,
             ILoggerFactory logger,
             UrlEncoder encoder,
             ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
                return AuthenticateResult.NoResult();

            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
            var username = credentials[0];
            var password = credentials[1];


            if (!IsAuthorizedUser(username,password))
            {
                return AuthenticateResult.Fail("Incorrect password or username");
            }

            var claims = new[] {
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Name,credentials[0]),
            };

            var identity = new ClaimsIdentity(claims, "Basic");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }



        public static bool IsAuthorizedUser(string Username, string Password)
        {
            // In this method we can handle our database logic here.
            return Username == "oguzhan" && Password == "demo";
        }
    }
}
