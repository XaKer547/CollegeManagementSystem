using CollegeManagementSystem.Domain.Users;

namespace CollegeManagementSystem.Domain.Students;

public sealed class StudentId : UserId
{
    public StudentId(Guid id) : base(id) { }
    public StudentId() : base() { }
}