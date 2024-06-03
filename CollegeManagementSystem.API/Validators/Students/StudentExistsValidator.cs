using CollegeManagementSystem.Domain.Students;
using CollegeManagementSystem.Infrastucture.Common;

namespace CollegeManagementSystem.API.Validators.Students;

public class StudentExistsValidator(CollegeManagementSystemDbContext context) : UserExistsValidator<StudentId, Student>(context)
{

}
