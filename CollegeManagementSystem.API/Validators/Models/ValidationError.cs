namespace CollegeManagementSystem.API.Validators.Models;

public sealed class ValidationError(string propertyName, string errorMessage, string errorCode)
{
    public string PropertyName { get; } = propertyName;
    public string ErrorMessage { get; } = errorMessage;
    public string ErrorCode { get; } = errorCode;
}
