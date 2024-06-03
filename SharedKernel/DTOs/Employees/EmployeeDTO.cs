using SharedKernel.DTOs.Posts;

namespace SharedKernel.DTOs.Employees;

public sealed record EmployeeDTO
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string MiddleName { get; init; }
    public bool Blocked { get; init; }
    public IReadOnlyCollection<PostDTO> Posts { get; init; }
}
