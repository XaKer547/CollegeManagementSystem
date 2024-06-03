using SharedKernel;

namespace CollegeManagementSystem.Domain.Users.Events;

public sealed class UserCreatedEvent : IDomainEvent
{
    public UserCreatedEvent(string email, string password, string[] roles)
    {
        Email = email;
        Password = password;
        Roles = roles;
    }

    public string Email { get; }
    public string Password { get; }
    public string[] Roles { get; }
}
