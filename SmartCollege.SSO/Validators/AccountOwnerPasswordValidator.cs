using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data.Entities;
using static IdentityModel.OidcConstants;

namespace SmartCollege.SSO.Validators
{
    public class AccountOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<AccountIdentity> _userManager;
        private readonly SignInManager<AccountIdentity> _signInManager;

        public AccountOwnerPasswordValidator(UserManager<AccountIdentity> userManager, SignInManager<AccountIdentity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var result = await _signInManager.PasswordSignInAsync(context.UserName, context.Password, true, false);
            if (result.Succeeded && !result.IsLockedOut)
            {
                var user = await _userManager.FindByEmailAsync(context.UserName);
                if (user != null)
                {
                    if (!user.ChangeTempPassword)
                    {
                        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Client need set new password!");
                        return;
                    }

                    var claims = await _userManager.GetClaimsAsync(user);

                    context.Result = new GrantValidationResult(
                        subject: user.Id.ToString(),
                        authenticationMethod: AuthenticationMethods.Password,
                        DateTime.Now.AddMinutes(5),
                        claims: claims
                    );
                    return;
                }
            }

            context.Result = new GrantValidationResult(TokenRequestErrors.UnauthorizedClient, "Invalid Credentials");
        }
    }
}
