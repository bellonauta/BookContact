using Microsoft.Owin.Security.OAuth;
using BookContactControl.Domain.Services;
//using BookContactControl.Resource.Resources;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace BookContactControl.Api.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IContactService _service;

        public AuthorizationServerProvider(IContactService service)
        {
            _service = service;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var contact = _service.AuthenticateConsumer(context.UserName);

                if (contact == null)
                {
                    context.SetError("invalid_grant", "Credenciais inválidas.");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, contact.Email));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, contact.Name));

                GenericPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
            }
        }
    }
}
