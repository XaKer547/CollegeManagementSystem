namespace SmartCollege.RabbitMQ.Contracts.Groups;

public interface IGroupCreated
{
    Guid Id { get; }
    string Name { get; }
}
