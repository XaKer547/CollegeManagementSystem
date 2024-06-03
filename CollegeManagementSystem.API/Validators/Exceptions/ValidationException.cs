using CollegeManagementSystem.API.Validators.Models;

namespace CollegeManagementSystem.API.Validators.Exceptions;

public sealed class ValidationException(List<ValidationError> errors) : Exception
{
    public List<ValidationError> Errors { get; } = errors;
}
