using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Users;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateEmployeeCommand> validator) : IRequestHandler<CreateEmployeeCommand, EmployeeId>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<CreateEmployeeCommand> validator = validator;

    public async Task<EmployeeId> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var employee = Employee.Create(request.FirstName, request.MiddleName, request.LastName, request.Roles);

        unitOfWork.Repository.AddEntity(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}