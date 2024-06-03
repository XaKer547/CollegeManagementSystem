using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Infrastucture.Common;

namespace CollegeManagementSystem.API.Validators.Grops;

public class GroupExistsValidator(CollegeManagementSystemDbContext context) : EntityExistsValidator<GroupId, Group>(context)
{

}