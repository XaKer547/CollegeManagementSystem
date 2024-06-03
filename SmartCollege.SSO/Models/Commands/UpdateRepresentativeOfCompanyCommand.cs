using MediatR;

namespace SmartCollege.SSO.Models.Commands
{
    public record UpdateRepresentativeOfCompanyCommand(
        string? MiddleName,
        string? FirstName,
        string? LastName,
        string? Phone,
        string? Company,
        UpdateAccountDto? Account) : IRequest<HandleResult>;

    public record UpdateAccountDto(
        string? Password);

    public record UpdateRepresentativeOfCompanyWithEmailCommand(
        string CurrentEmail,
        UpdateRepresentativeOfCompanyCommand Origin) : UpdateRepresentativeOfCompanyCommand(Origin);
}
