namespace SmartCollege.RabbitMQ.Contracts.Users;

public interface IUserRolesUpdated
{
    public Guid UserId { get; }
    public string[] Roles { get; }
}
