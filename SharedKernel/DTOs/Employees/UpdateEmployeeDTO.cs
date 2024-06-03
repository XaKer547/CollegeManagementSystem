namespace SharedKernel.DTOs.Employees;

public sealed record UpdateEmployeeDTO
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? MiddleName { get; init; }
}
