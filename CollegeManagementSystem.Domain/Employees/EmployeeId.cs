using CollegeManagementSystem.Domain.Users;

namespace CollegeManagementSystem.Domain.Employees;

public sealed class EmployeeId : UserId
{
    public EmployeeId() : base() { }
    public EmployeeId(Guid employeeId) : base(employeeId) { }
}
