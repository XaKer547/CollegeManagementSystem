namespace SharedKernel.DTOs.Projects;

public sealed record ProjectDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string SubjectArea { get; init; }

    public int ProjectTypeId { get; init; }
    public string ProjectType { get; init; }

    public Guid DisciplineId { get; init; }
    public string DisciplineName { get; init; }

    public bool Completed { get; init; }
    public int Mark { get; init; }
}
