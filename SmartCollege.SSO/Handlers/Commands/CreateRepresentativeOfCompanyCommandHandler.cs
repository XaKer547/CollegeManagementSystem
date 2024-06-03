using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands;
using SmartCollege.SSO.Models.Events;
using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Handlers.Commands
{
    public class CreateRepresentativeOfCompanyCommandHandler : IRequestHandler<CreateRepresentativeOfCompanyCommand, HandleResult>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        private readonly AuthorizationDbContext _authorizationDbContext;

        private readonly ILogger<CreateRepresentativeOfCompanyCommandHandler> _logger;

        private readonly IMediator _mediator;

        public CreateRepresentativeOfCompanyCommandHandler(UserManager<AccountIdentity> userManager, ILogger<CreateRepresentativeOfCompanyCommandHandler> logger, IMediator mediator, AuthorizationDbContext authorizationDbContext)
        {
            _userManager = userManager;
            _logger = logger;
            _mediator = mediator;
            _authorizationDbContext = authorizationDbContext;
        }

        public async Task<HandleResult> Handle(CreateRepresentativeOfCompanyCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Account.Email);
            if (user is not null)
                return HandleResult.Failure(StatusCodes.Status409Conflict, "Email уже занят!");

            try
            {
                var account = new AccountIdentity
                {
                    Email = request.Account.Email,
                    UserName = request.Account.Email,
                    EmailConfirmed = false,
                    ChangeTempPassword = true,
                    LockoutEnabled = true,
                };

                var result = await _userManager.CreateAsync(account, request.Account.Password);

                if (!result.Succeeded)
                    return HandleResult.Failure(StatusCodes.Status400BadRequest, string.Concat(',', result.Errors
                        .Select(x => x.Description)));

                try
                {
                    await _userManager.AddToRoleAsync(account, Roles.RepresentativeOfTheCompany.ToString());
                }
                catch
                {
                    await _userManager.DeleteAsync(account);

                    throw;
                }

                await _authorizationDbContext.RepresentationOfTheCompanies.AddAsync(new RepresentationOfTheCompany
                {
                    Company = request.Company,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.MiddleName,
                    Phone = request.Phone,
                    Account = account
                });

                await _authorizationDbContext.SaveChangesAsync();

                await _mediator.Publish(new CreateAccountEvent(
                    request.Account.Email,
                    $"{request.MiddleName} {request.FirstName} {request.LastName}",
                    request.Phone,
                    request.Company));

                return HandleResult.Success(StatusCodes.Status201Created, "Пользователь успешно создан!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "При создании аккаунта с почтой {@request} произошла ошибка", request);

                return HandleResult.Failure(StatusCodes.Status500InternalServerError, "Неизвестная ошибка!");
            }
        }
    }
}
