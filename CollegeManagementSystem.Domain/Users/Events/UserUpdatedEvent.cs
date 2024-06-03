using SharedKernel;

namespace CollegeManagementSystem.Domain.Users.Events;

public sealed class UserUpdatedEvent : IDomainEvent
{
    public UserUpdatedEvent(string email, string password, string[] roles, bool blocked)
    {
        Email = email;
        Password = password;
        Roles = roles;
        Blocked = blocked;
    }

    public string Email { get; init; }
    public string Password { get; init; }
    public string[] Roles { get; init; }
    public bool Blocked { get; init; }
}