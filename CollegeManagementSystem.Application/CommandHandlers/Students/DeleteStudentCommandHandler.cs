using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed record DeleteStudentCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteStudentCommand> validator) : IRequestHandler<DeleteStudentCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<DeleteStudentCommand> validator = validator;

    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var student = unitOfWork.Repository.Students.Single(s => s.Id == request.StudentId);

        student.Delete();

        unitOfWork.Repository.DeleteEntity(student);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
