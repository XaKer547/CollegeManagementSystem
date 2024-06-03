using CollegeManagementSystem.Domain.Students;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Students;

public sealed record GraduateStudentCommand : IRequest
{
    public StudentId StudentId { get; init; }
    public bool Graduated { get; init; }
}
