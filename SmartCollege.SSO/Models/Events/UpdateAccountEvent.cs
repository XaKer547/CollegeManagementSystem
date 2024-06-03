using MediatR;

namespace SmartCollege.SSO.Models.Events
{
    public record UpdateAccountEvent(
        string Email,
        string FullName,
        string Phone,
        string Company) : INotification;
}
