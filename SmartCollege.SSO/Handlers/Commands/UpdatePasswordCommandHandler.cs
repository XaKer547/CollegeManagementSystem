using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands;

namespace SmartCollege.SSO.Handlers.Commands
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, HandleResult>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        public UpdatePasswordCommandHandler(UserManager<AccountIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<HandleResult> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return HandleResult.Failure(StatusCodes.Status404NotFound, "Пользователь не найден!");

            var resetPasswordResult = await _userManager.ChangePasswordAsync(user, request.TempPassword, request.Password);
            if (!resetPasswordResult.Succeeded)
                return HandleResult.Failure(StatusCodes.Status403Forbidden, "Ошибка смены пароля!");

            return HandleResult.Success(StatusCodes.Status200OK, "Пароль успешно сменил!");
        }
    }
}
