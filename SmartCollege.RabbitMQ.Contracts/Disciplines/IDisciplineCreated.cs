namespace SmartCollege.RabbitMQ.Contracts.Disciplines;

public interface IDisciplineCreated
{
    Guid Id { get; }
    string Name { get; }
}
