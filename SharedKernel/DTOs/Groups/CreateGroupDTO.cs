namespace SharedKernel.DTOs.Groups;

public sealed record CreateGroupDTO
{
    public string Name { get; init; }
    public Guid SpecializationId { get; init; }
}
