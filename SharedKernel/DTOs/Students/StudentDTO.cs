namespace SharedKernel.DTOs.Students;

public sealed record StudentDTO
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string LastName { get; init; }
    public bool Graduated { get; init; }
    public bool Blocked { get; init; }
}
