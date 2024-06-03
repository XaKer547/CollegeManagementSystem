using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class UpdateStudentCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateStudentCommand> validator) : IRequestHandler<UpdateStudentCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<UpdateStudentCommand> validator = validator;

    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var student = unitOfWork.Repository.Students.Single(s => s.Id == request.StudentId);

        var group = unitOfWork.Repository.Groups.SingleOrDefault(g => g.Id == request.GroupId);

        student.Update(request.FirstName ?? student.FirstName, request.MiddleName ?? student.MiddleName, request.LastName ?? student.LastName, group ?? student.Group);

        unitOfWork.Repository.UpdateEntity(student);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
