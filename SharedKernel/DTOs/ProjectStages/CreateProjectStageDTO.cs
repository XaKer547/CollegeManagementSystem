
namespace SharedKernel.DTOs.ProjectStages;

public sealed record CreateProjectStageDTO
{
    public DateTime Deadline { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
}
