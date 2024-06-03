using SharedKernel;

namespace CollegeManagementSystem.Domain.Groups.Events;

public sealed record GroupCreatedEvent : IDomainEvent
{
    public GroupCreatedEvent(Group group)
    {
        Group = group;
    }

    public Group Group { get; init; }
}
