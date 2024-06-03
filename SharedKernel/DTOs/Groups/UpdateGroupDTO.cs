
namespace SharedKernel.DTOs.Groups;

public sealed record UpdateGroupDTO
{
    public string Name { get; init; }
    public Guid SpecializationId { get; set; }
}