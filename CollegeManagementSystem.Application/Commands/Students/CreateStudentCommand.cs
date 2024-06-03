using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Students;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Students;

public sealed record CreateStudentCommand : IRequest<StudentId>
{
    public GroupId GroupId { get; init; }
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string LastName { get; init; }
}
