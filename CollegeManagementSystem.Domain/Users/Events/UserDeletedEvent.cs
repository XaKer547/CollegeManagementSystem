using SharedKernel;

namespace CollegeManagementSystem.Domain.Users.Events;

public sealed class UserDeletedEvent : IDomainEvent
{
    public UserDeletedEvent(string email)
    {
        Email = email;
    }

    public string Email { get; }
}
