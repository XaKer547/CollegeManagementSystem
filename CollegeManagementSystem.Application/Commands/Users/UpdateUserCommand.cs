using MediatR;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Application.Commands.Users;

public sealed record UpdateUserCommand : IRequest
{
    public Guid UserId { get; init; }
    public Roles[]? Roles { get; init; }
    public bool? Blocked { get; init; }
}