using MassTransit;
using Microsoft.AspNetCore.Identity;
using SmartCollege.RabbitMQ.Contracts.Users;
using SmartCollege.SSO.Data.Entities;

namespace SmartCollege.SSO.Consumers
{
    public class UpdateAccountContractConsumer : IConsumer<IUserUpdated>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        public UpdateAccountContractConsumer(UserManager<AccountIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task Consume(ConsumeContext<IUserUpdated> context)
        {
            var message = context.Message;

            var account = await _userManager.FindByEmailAsync(message.Email);
            if (account is null)
                return;

            if (message.Password.Length != 0)
            {
                var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(account);
                await _userManager.ResetPasswordAsync(account, resetPasswordToken, message.Password);
            }

            await _userManager.AddToRolesAsync(account, message.Roles);
        }
    }
}
