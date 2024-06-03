using CollegeManagementSystem.API.Validators.Disciplines;
using CollegeManagementSystem.API.Validators.Employees;
using CollegeManagementSystem.API.Validators.Grops;
using CollegeManagementSystem.API.Validators.Specializations;
using CollegeManagementSystem.API.Validators.Students;
using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Domain.Students;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Helpers;

public static class AbstractValidatorExtensions
{
    public static IRuleBuilderOptions<T, GroupId> Exists<T>(this IRuleBuilder<T, GroupId> ruleBuilder, CollegeManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new GroupExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, EmployeeId> Exists<T>(this IRuleBuilder<T, EmployeeId> ruleBuilder, CollegeManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new EmployeeExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, StudentId> Exists<T>(this IRuleBuilder<T, StudentId> ruleBuilder, CollegeManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new StudentExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, DisciplineId> Exists<T>(this IRuleBuilder<T, DisciplineId> ruleBuilder, CollegeManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new DisciplineExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, SpecializationId> Exists<T>(this IRuleBuilder<T, SpecializationId> ruleBuilder, CollegeManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new SpecializationExistsValidator(context));
    }
}
