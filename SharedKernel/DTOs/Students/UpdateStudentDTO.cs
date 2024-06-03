namespace SharedKernel.DTOs.Students;

public sealed record UpdateStudentDTO
{
    public string Firstname { get; init; }
    public string Middlename { get; init; }
    public string Lastname { get; init; }
    public Guid GroupId { get; init; }
}
