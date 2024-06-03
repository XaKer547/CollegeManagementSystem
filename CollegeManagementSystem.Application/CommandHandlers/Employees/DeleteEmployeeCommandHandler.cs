using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteEmployeeCommand> validator) : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<DeleteEmployeeCommand> validator = validator;

    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var employee = unitOfWork.Repository.Employees.Single(e => e.Id == request.EmployeeId);

        employee.Delete();

        unitOfWork.Repository.DeleteEntity(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
