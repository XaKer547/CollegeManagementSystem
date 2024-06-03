using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Users;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Employees;

public sealed class Employee : User<EmployeeId>
{
    private Employee()
    {
        Id = new EmployeeId();
    }

    public Roles[] Roles { get; private set; }

    public static Employee Create(string firstName, string middleName, string lastName, Roles[] roles)
    {
        var employee = new Employee()
        {
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            Roles = roles
        };

        return employee;
    }

    public void Update(string firstName, string middlename, string lastName, Roles[] roles)
    {
        FirstName = firstName;
        MiddleName = middlename;
        LastName = lastName;
        Roles = roles;

        var employeeeUpdatedEvent = new EmployeeUpdatedEvent(this);

        AddEvent(employeeeUpdatedEvent);
    }
    public void Update(Roles[] roles)
    {
        Roles = roles;
    }

    public void Block(string password, Roles[] roles, bool blocked)
    {
        Blocked = blocked;

        var employeeeUpdatedEvent = new EmployeeUpdatedEvent(this);

        AddEvent(employeeeUpdatedEvent);

        //UpdateAccount(password, Roles, Blocked);
    }

    public void Delete()
    {
        DeleteAccount();

        var employeeDeletedEvent = new EmployeeDeletedEvent(Id);

        AddEvent(employeeDeletedEvent);
    }
}