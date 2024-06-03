using CollegeManagementSystem.Domain.Users;

namespace CollegeManagementSystem.Domain.CompanyRepresentatives;

public sealed class CompanyRepresentativeId : UserId
{
    public CompanyRepresentativeId(Guid id) : base(id) { }
    public CompanyRepresentativeId() : base() { }
}
