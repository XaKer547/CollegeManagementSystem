using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Students;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class CreateStudentCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateStudentCommand> validator) : IRequestHandler<CreateStudentCommand, StudentId>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<CreateStudentCommand> validator = validator;

    public async Task<StudentId> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var group = unitOfWork.Repository.Groups.Single(g => g.Id == request.GroupId);

        var student = Student.Create(request.FirstName, request.MiddleName, request.LastName, group);

        unitOfWork.Repository.AddEntity(student);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return student.Id;
    }
}