using MassTransit;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Shared;
using SmartCollege.SSO.Shared.Contracts;

namespace SmartCollege.SSO.Consumers
{
    public class UpdateBlockingRepresentativeOfTheCompanyAccountContractConsumer : IConsumer<IUpdateBlockingRepresentativeOfTheCompanyAccountContract>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        public UpdateBlockingRepresentativeOfTheCompanyAccountContractConsumer(UserManager<AccountIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task Consume(ConsumeContext<IUpdateBlockingRepresentativeOfTheCompanyAccountContract> context)
        {
            var message = context.Message;

            var user = await _userManager.FindByEmailAsync(message.Email);
            if (user is null)
                return;

            var isInRole = await _userManager.IsInRoleAsync(user, Roles.RepresentativeOfTheCompany.ToString());
            if (!isInRole)
                return;

            user.LockoutEnabled = message.IsBlocked;

            await _userManager.UpdateAsync(user);
        }
    }
}
