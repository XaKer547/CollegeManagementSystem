using SharedKernel;

namespace CollegeManagementSystem.Domain.Groups.Events;

public sealed record GroupUpdatedEvent : IDomainEvent
{
    public GroupUpdatedEvent(Group group)
    {
        Group = group;
    }

    public Group Group { get; init; }
}
