using SharedKernel;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Users;

public abstract class User<TEntityId> : User
    where TEntityId : UserId
{
    public TEntityId Id { get; protected set; }
}

public abstract class User : Entity
{
    public string FirstName { get; protected set; }
    public string MiddleName { get; protected set; }
    public string LastName { get; protected set; }
    public bool Blocked { get; protected set; } = false;
    protected void DeleteAccount()
    {
        Deleted = true;

        //var userDeletedEvent = new UserDeletedEvent(Email);

        //AddEvent(userDeletedEvent);
    }
}