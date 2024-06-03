namespace SharedKernel.DTOs.ProjectStages;

public sealed record GradeProjectStageDTO
{
    public Guid StudentId { get; init; }
    public int Grade { get; init; }
}
