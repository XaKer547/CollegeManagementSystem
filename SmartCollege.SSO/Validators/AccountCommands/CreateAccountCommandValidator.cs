using FluentValidation;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands;

namespace SmartCollege.SSO.Validators.AccountCommands
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateRepresentativeOfCompanyCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Company).NotEmpty();
            RuleFor(x => x.MiddleName).NotEmpty();
            //Matches +79261234567 | 8(926)123-45-67 | +7 926 123 45 67
            RuleFor(x => x.Phone).Matches("^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$");

            RuleFor(x => x.Account.Email).EmailAddress();
            RuleFor(x => x.Account.Password).MinimumLength(8);
        }
    }
}
