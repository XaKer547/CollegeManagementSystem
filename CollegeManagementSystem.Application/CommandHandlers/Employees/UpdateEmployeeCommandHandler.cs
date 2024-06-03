using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateEmployeeCommand> validator) : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<UpdateEmployeeCommand> validator = validator;

    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var employee = unitOfWork.Repository.Employees.Single(e => e.Id == request.EmployeeId);

        employee.Update(request.FirstName ?? employee.FirstName, request.MiddleName ?? employee.MiddleName, request.LastName ?? employee.LastName, request.Roles ?? employee.Roles);

        unitOfWork.Repository.UpdateEntity(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}