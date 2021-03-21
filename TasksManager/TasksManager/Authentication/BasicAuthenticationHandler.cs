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
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.Components.Authorization;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries;
using TaskManager.DataAccess.CQRS.Queries.Managers;
using TaskManager.DataAccess.Entities;

namespace TasksManager.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher passwordHasher;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IQueryExecutor queryExecutor,
            IPasswordHasher passwordHasher)
            : base(options, logger, encoder, clock)
        {
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
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

            AppRole enumRole = (AppRole)Enum.Parse(typeof(AppRole),
                Request.Headers.Where(x => x.Key == "Role").Select(x => x.Value).FirstOrDefault().FirstOrDefault());
            if (enumRole == AppRole.Manager)
            {
                return await ManagerAuthorization(enumRole);
            }
            else if (enumRole == AppRole.Employee)
            {
                return await EmployeeAuthorization(enumRole);
            }
            else
            {
                return AuthenticateResult.Fail("Missing Authorization");
            }            
        }

        private async Task<AuthenticateResult> ManagerAuthorization(AppRole enumRole)
        {
            Manager user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = passwordHasher.Hash(credentials[1]);

                var query = new GetUserQuery<Manager>()
                {
                    Login = username
                };

                user = await queryExecutor.Execute(query);

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
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, enumRole.ToString()),
                new Claim(ClaimTypes.UserData, user.Company.Id.ToString())
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }

        private async Task<AuthenticateResult> EmployeeAuthorization(AppRole enumRole)
        {
            Employee user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = passwordHasher.Hash(credentials[1]);
                var query = new GetUserQuery<Employee>()
                {
                    Login = username
                };

                user = await queryExecutor.Execute(query);

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
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, enumRole.ToString()),
                new Claim(ClaimTypes.UserData, user.Company.Id.ToString())
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
