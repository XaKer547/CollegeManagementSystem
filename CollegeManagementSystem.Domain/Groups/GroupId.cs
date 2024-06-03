using SharedKernel;

namespace CollegeManagementSystem.Domain.Groups;

public sealed class GroupId : EntityId
{
    public GroupId(Guid id) : base(id) { }
    public GroupId() : base() { }
}
