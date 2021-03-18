using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries;
using TaskManager.DataAccess.CQRS.Queries.Managers;
using TaskManager.DataAccess.Entities;

namespace TasksManager.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IQueryExecutor queryExecutor;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IQueryExecutor queryExecutor)
            : base(options, logger, encoder, clock)
        {
            this.queryExecutor = queryExecutor;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return AuthenticateResult.NoResult();
            }

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization");
            }

            if (!Request.Headers.ContainsKey("Role"))
            {
                return AuthenticateResult.Fail("Missing Authorization");
            }

            var role = Request.Headers.Where(x => x.Key == "Role").Select(x => x.Value).FirstOrDefault().FirstOrDefault();

            if (role == "Manager")
            {
                return await ManagerAuthorization();
            }
            else if (role == "Employee")
            {
                return await EmployeeAuthorization();
            }
            else
            {
                return AuthenticateResult.Fail("Missing Authorization");
            }            
        }

        private async Task<AuthenticateResult> ManagerAuthorization()
        {
            Manager user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];

                var query = new GetUserQuery<Manager>()
                {
                    Login = username
                };

                user = await queryExecutor.Execute(query);

                //TODO : HASH!
                if (user == null || user.Password != password)
                {
                    return AuthenticateResult.Fail("Invalid Authorization Header");
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }

        private async Task<AuthenticateResult> EmployeeAuthorization()
        {
            Employee user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];
                var query = new GetUserQuery<Employee>()
                {
                    Login = username
                };

                user = await queryExecutor.Execute(query);

                //TODO : HASH!
                if (user == null || user.Password != password)
                {
                    return AuthenticateResult.Fail("Invalid Authorization Header");
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
