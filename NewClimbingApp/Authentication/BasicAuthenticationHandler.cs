namespace Pharmacy.Authentication;

using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NewClimbingApp.DataAccess.CQRS.Queries;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IQueryExecutor queryExecutor;
    private readonly IPasswordHasher passwordHasher;

    //private readonly IPasswordHasher<User> passwordHasher;


    public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IQueryExecutor queryExecutor,
            IPasswordHasher passwordHasher)
          //  IPasswordHasher<User> passwordHasher)
            : base(options, logger, encoder, clock)
    {
        this.queryExecutor = queryExecutor;
        this.passwordHasher = passwordHasher;
        // this.passwordHasher = passwordHasher;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // skip authentication if endpoint has [AllowAnonymous] attribute
        var endpoint = Context.GetEndpoint();
        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        {
            return AuthenticateResult.NoResult();
        }

        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Missing Authorization Header");
        }

        User user = null;
        try
      {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
            var username = credentials[0];
            var password = credentials[1];
          //  var hashedPassword = passwordHasher.HashPassword(password);
            var query = new GetUserQuery()
            {
                UserName = username
            };
            user = await this.queryExecutor.Execute(query);

            if (user == null)
            {
                return AuthenticateResult.Fail("Resource does not exist");
            }

            passwordHasher.VerifyHashedPassword(user.PasswordHash, password);
            /*  var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
              if (result == PasswordVerificationResult.Failed)
              {
                  return AuthenticateResult.Fail("Wrong password");
              }*/
            if (user == null || password != user.PasswordHash)
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
        }

        catch
        {
            return AuthenticateResult.Fail("Invalid Authorization Header");
        }

        var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        return AuthenticateResult.Success(ticket);
    }
}