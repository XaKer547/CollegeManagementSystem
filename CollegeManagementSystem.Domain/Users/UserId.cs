using SharedKernel;

namespace CollegeManagementSystem.Domain.Users;

public class UserId : EntityId
{
    public UserId(Guid id) : base(id) { }
    public UserId() : base() { }
}
