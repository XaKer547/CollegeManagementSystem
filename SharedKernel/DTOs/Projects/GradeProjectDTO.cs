namespace SharedKernel.DTOs.Projects;

public sealed record GradeProjectDTO
{
    public Guid StudentId { get; init; }
    public int Grade { get; init; }
}

