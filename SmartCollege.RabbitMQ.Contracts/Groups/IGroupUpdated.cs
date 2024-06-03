namespace SmartCollege.RabbitMQ.Contracts.Groups;

public interface IGroupUpdated
{
    Guid Id { get; }
    string Name { get; }
}
