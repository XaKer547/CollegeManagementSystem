using MassTransit;
using Microsoft.AspNetCore.Identity;
using SmartCollege.RabbitMQ.Contracts.Users;
using SmartCollege.SSO.Data.Entities;

namespace SmartCollege.SSO.Consumers
{
    public class CreateAccountContractConsumer : IConsumer<IUserCreated>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        public CreateAccountContractConsumer(UserManager<AccountIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task Consume(ConsumeContext<IUserCreated> context)
        {
            var message = context.Message;

            var account = new AccountIdentity
            {
                Email = message.Email,
                UserName = message.Email,
                ChangeTempPassword = false,
                EmailConfirmed = true,
            };

            await _userManager.CreateAsync(account, message.Password);

            await _userManager.AddToRolesAsync(account, message.Roles);
        }
    }
}
