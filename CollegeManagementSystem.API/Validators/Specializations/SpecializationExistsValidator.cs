using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Infrastucture.Common;

namespace CollegeManagementSystem.API.Validators.Specializations;

public class SpecializationExistsValidator(CollegeManagementSystemDbContext context) : EntityExistsValidator<SpecializationId, Specialization>(context)
{

}