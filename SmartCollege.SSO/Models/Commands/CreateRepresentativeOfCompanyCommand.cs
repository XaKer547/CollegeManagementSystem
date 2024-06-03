using MediatR;

namespace SmartCollege.SSO.Models.Commands
{
    public record CreateRepresentativeOfCompanyCommand(
        string MiddleName,
        string FirstName,
        string LastName,
        string Phone,
        string Company,
        CreateAccountDto Account) : IRequest<HandleResult>;

    public record CreateAccountDto(
        string Email,
        string Password);
}
