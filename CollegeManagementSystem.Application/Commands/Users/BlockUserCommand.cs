namespace CollegeManagementSystem.Application.Commands.Users;

public sealed record BlockUserCommand
{
    public string Email { get; init; }
    public bool Blocked { get; init; }
}
