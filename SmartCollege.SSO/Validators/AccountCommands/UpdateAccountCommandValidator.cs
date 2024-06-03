using FluentValidation;
using SmartCollege.SSO.Models.Commands;
using System.Text.RegularExpressions;

namespace SmartCollege.SSO.Validators.AccountCommands
{
    public partial class UpdateAccountCommandValidator : AbstractValidator<UpdateRepresentativeOfCompanyCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(x => x.FirstName).Custom((param, context) =>
            {
                if (param is null)
                    return;

                if (param.Length == 0)
                    context.AddFailure(nameof(UpdateRepresentativeOfCompanyCommand.FirstName), "Имя не указано!");
            });

            RuleFor(x => x.Company).Custom((param, context) =>
            {
                if (param is null)
                    return;

                if (param.Length == 0)
                    context.AddFailure(nameof(UpdateRepresentativeOfCompanyCommand.Company), "Компания не указана!");
            });

            RuleFor(x => x.MiddleName).Custom((param, context) =>
            {
                if (param is null)
                    return;

                if (param.Length == 0)
                    context.AddFailure(nameof(UpdateRepresentativeOfCompanyCommand.MiddleName), "Фамилия не указана!");
            });

            RuleFor(x => x.Phone).Custom((param, context) =>
            {
                if (param is null)
                    return;

                var regex = PhoneRegex();

                if (regex.IsMatch(param))
                    context.AddFailure(nameof(UpdateRepresentativeOfCompanyCommand.Phone), "Телефон введен некорректно!");
            });

            RuleFor(x => x.Account).Custom((param, context) =>
            {
                if (param is null)
                    return;

                if (param.Password is not null)
                {
                    if (param.Password.Length < 8)
                        context.AddFailure(nameof(UpdateRepresentativeOfCompanyCommand.Account.Password), "Пароль не может быть меньше 8 символов!");
                }
            });
        }

        //Matches +79261234567 | 8(926)123-45-67 | +7 926 123 45 67
        [GeneratedRegex("^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$")]
        private static partial Regex PhoneRegex();
    }
}
