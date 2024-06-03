namespace SharedKernel.DTOs.ProjectStages;

public sealed record ProjectStageDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public DateTime Deadline { get; init; }
    public string[]? PinnedFiles { get; init; } //TODO: посмотрим что он ответит
    public string? StudentWork { get; init; }
    public string Remark { get; init; }
}
