using FluentValidation;
using SmartCollege.SSO.Models.Commands;

namespace SmartCollege.SSO.Validators.AccountCommands
{
    public class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
    {
        public UpdatePasswordCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.TempPassword).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(8);
        }
    }
}
