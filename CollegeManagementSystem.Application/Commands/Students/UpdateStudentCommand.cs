using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Students;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Students;

public sealed record UpdateStudentCommand : IRequest
{
    public StudentId StudentId { get; init; }
    public string? FirstName { get; init; }
    public string? MiddleName { get; init; }
    public string? LastName { get; init; }
    public GroupId? GroupId { get; init; }
}
