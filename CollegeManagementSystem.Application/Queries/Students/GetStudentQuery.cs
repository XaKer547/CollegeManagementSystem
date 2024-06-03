using CollegeManagementSystem.Domain.Students;
using MediatR;
using SharedKernel.DTOs.Students;

namespace CollegeManagementSystem.Application.Queries.Students;

public sealed record GetStudentQuery : IRequest<StudentDTO>
{
    public StudentId StudentId { get; init; }
}
