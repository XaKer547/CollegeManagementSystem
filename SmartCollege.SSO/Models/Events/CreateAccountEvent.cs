using MediatR;

namespace SmartCollege.SSO.Models.Events
{
    public record CreateAccountEvent(
        string Email,
        string FullName,
        string Phone,
        string Company) : INotification;
}
