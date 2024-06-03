namespace SharedKernel.DTOs.Specializations;

public sealed record SpecializationDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}
