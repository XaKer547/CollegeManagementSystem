namespace SharedKernel.DTOs.Students;

public sealed record CreateStudentDTO
{
    public string Firstname { get; init; }
    public string Middlename { get; init; }
    public string Lastname { get; init; }
}