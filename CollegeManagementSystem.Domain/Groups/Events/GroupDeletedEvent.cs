using SharedKernel;

namespace CollegeManagementSystem.Domain.Groups.Events;

public sealed record GroupDeletedEvent : IDomainEvent
{
    public GroupDeletedEvent(GroupId groupId)
    {
        GroupId = groupId;
    }

    public GroupId GroupId { get; init; }
}
