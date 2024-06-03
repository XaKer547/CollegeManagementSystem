using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCollege.SSO.Data;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands;

namespace SmartCollege.SSO.Handlers.Commands
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateRepresentativeOfCompanyWithEmailCommand, HandleResult>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        private readonly AuthorizationDbContext _authorizationDbContext;

        private readonly ILogger<UpdateAccountCommandHandler> _logger;

        public UpdateAccountCommandHandler(UserManager<AccountIdentity> userManager, AuthorizationDbContext authorizationDbContext, ILogger<UpdateAccountCommandHandler> logger)
        {
            _userManager = userManager;
            _authorizationDbContext = authorizationDbContext;
            _logger = logger;
        }

        public async Task<HandleResult> Handle(UpdateRepresentativeOfCompanyWithEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.CurrentEmail);
                if (user is null)
                    return HandleResult.Failure(StatusCodes.Status404NotFound, "Пользователь не найден!");

                var representative = await _authorizationDbContext.RepresentationOfTheCompanies.SingleAsync(x => x.Account.Email == request.CurrentEmail);

                representative.FirstName = request.FirstName is not null ? request.FirstName : representative.FirstName;
                representative.LastName = request.LastName is not null ? request.LastName : representative.LastName;
                representative.MiddleName = request.MiddleName is not null ? request.MiddleName : representative.MiddleName;
                representative.Phone = request.Phone is not null ? request.Phone : representative.Phone;
                representative.Company = request.Company is not null ? request.Company : representative.Company;

                if (request.Account?.Password is not null)
                {
                    var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    await _userManager.ResetPasswordAsync(user, resetPasswordToken, request.Account.Password);

                    await _userManager.UpdateAsync(user);
                }

                return HandleResult.Success(StatusCodes.Status204NoContent, "Пользователь обновлен!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления: {@request}", request);

                return HandleResult.Failure(StatusCodes.Status204NoContent, "Ошибка обновления!");
            }
        }
    }
}
