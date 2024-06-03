namespace SharedKernel.DTOs.Disciplines;

public sealed record DisciplineDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}
