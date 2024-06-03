namespace SmartCollege.RabbitMQ.Contracts.Students;

public interface IStudentUpdated : IStudent
{
    Guid Id { get; }
    Guid GroupId { get; }
}