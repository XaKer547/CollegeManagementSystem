using MediatR;

namespace SmartCollege.SSO.Models.Commands
{
    public record UpdatePasswordCommand(string Email, string TempPassword, string Password) : IRequest<HandleResult>;
}
