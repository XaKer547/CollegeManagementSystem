using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Infrastucture.Common;
using MassTransit;
using SmartCollege.RabbitMQ.Contracts.Users;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.API.Consumers;

public class UserRolesUpdatedConsumer(CollegeManagementSystemDbContext dbContext) : IConsumer<IUserRolesUpdated>
{
    private readonly CollegeManagementSystemDbContext dbContext = dbContext;

    public async Task Consume(ConsumeContext<IUserRolesUpdated> context)
    {
        var message = context.Message;

        var employeeId = new EmployeeId(message.UserId);

        var employee = dbContext.Employees.Single(e => e.Id == employeeId);

        var roles = message.Roles.Select(Enum.Parse<Roles>)
            .ToArray();

        employee.Update(roles);

        await dbContext.SaveChangesAsync();
    }
}
