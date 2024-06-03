namespace SharedKernel.DTOs.Posts;

public sealed record PostDTO
{
    public int Id { get; init; }
    public string Name { get; init; }
}
