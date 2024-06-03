using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class GraduateStudentCommandHandler(IUnitOfWork unitOfWork, IValidator<GraduateStudentCommand> validator) : IRequestHandler<GraduateStudentCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GraduateStudentCommand> validator = validator;

    public async Task Handle(GraduateStudentCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var student = unitOfWork.Repository.Students.Single(s => s.Id == request.StudentId);

        student.Graduate(request.Graduated);

        unitOfWork.Repository.UpdateEntity(student);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
