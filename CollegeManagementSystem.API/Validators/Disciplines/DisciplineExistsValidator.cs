using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Infrastucture.Common;

namespace CollegeManagementSystem.API.Validators.Disciplines;

public class DisciplineExistsValidator(CollegeManagementSystemDbContext context) : EntityExistsValidator<DisciplineId, Discipline>(context)
{

}
