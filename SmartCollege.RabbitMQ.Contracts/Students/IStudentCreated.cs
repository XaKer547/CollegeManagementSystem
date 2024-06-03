namespace SmartCollege.RabbitMQ.Contracts.Students;

public interface IStudentCreated : IStudent
{
    Guid Id { get; }
    Guid GroupId { get; }
}
