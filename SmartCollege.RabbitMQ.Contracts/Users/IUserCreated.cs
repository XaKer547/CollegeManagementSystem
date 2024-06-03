namespace SmartCollege.RabbitMQ.Contracts.Users;

public interface IUserCreated
{
    string Email { get; }
    string Password { get; }
    string[] Roles { get; }
}
