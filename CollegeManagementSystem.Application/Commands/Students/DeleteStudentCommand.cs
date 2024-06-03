using CollegeManagementSystem.Domain.Students;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Students;

public sealed record DeleteStudentCommand : IRequest
{
    public StudentId StudentId { get; init; }
}
