using MassTransit;
using Microsoft.AspNetCore.Identity;
using SmartCollege.RabbitMQ.Contracts.Users;
using SmartCollege.SSO.Data.Entities;

namespace SmartCollege.SSO.Consumers
{
    public class DeleteAccountContractConsumer : IConsumer<IUserDeleted>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        public DeleteAccountContractConsumer(UserManager<AccountIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task Consume(ConsumeContext<IUserDeleted> context)
        {
            var message = context.Message;

            var account = await _userManager.FindByEmailAsync(message.Email);
            if (account is null)
                return;

            account.LockoutEnabled = true;
        
            await _userManager.UpdateAsync(account);
        }
    }
}
