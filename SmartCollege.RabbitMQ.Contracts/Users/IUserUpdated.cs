namespace SmartCollege.RabbitMQ.Contracts.Users;

public interface IUserUpdated
{
    string Email { get; }
    string Password { get; }
    string[] Roles { get; }
    bool Blocked { get; }
}
